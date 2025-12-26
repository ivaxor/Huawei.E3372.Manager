using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Constants;
using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Huawei.E3372.Manager.Runtime.Components.Pages;

public partial class SmsPage
{
    [Inject] protected ApplicationDbContext DbContext { get; set; }
    [Inject] protected ISmsService SmsService { get; set; }

    protected ModemSms[] Sms { get; set; }
    protected Dictionary<Guid, Modem> ModemById { get; set; }

    protected SendSmsModel Model { get; set; } = new SendSmsModel();
    protected ModalComponent Modal { get; set; }
    protected EditContext EditContext { get; set; }
    protected ValidationMessageStore ValidationMessageStore { get; set; }
    protected bool IsSubmitted { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        EditContext = new EditContext(Model);
        EditContext.OnValidationRequested += OnValidationRequested!;
        ValidationMessageStore = new ValidationMessageStore(EditContext);

        Sms = await DbContext.ModemSms
            .OrderByDescending(m => m.CreatedAt)
            .ToArrayAsync();

        ModemById = await DbContext.Modems
            .Include(m => m.Status)
            .ToDictionaryAsync(m => m.Id, m => m);

        await base.OnInitializedAsync();
    }

    protected void OnValidationRequested(object sender, ValidationRequestedEventArgs e)
    {
        ValidationMessageStore.Clear();

        var phoneNumbers = Model.ToPhoneNumbers.Split(",");
        foreach (var phoneNumber in phoneNumbers)
        {
            if (!RegexConstants.PhoneNumberRegex.IsMatch(phoneNumber))
                ValidationMessageStore.Add(() => Model.ToPhoneNumbers, $"Invalid phone number: {phoneNumber}.");
        }
    }

    protected void OnClose()
    {
        EditContext.OnValidationRequested -= OnValidationRequested;

        Model = new SendSmsModel();
        EditContext = new EditContext(Model);
        EditContext.OnValidationRequested += OnValidationRequested!;
        ValidationMessageStore = new ValidationMessageStore(EditContext);
    }

    protected async Task OnValidSubmit(EditContext context)
    {
        IsSubmitted = true;

        var modemId = Guid.Parse(Model.FromModemId);
        var modem = ModemById[modemId];

        var phoneNumbers = Model.ToPhoneNumbers.Split(",");

        var result = await SmsService.SendAsync(modem, phoneNumbers, Model.Content);
        if (result.IsSuccess)
            Modal.Close();
        else
            ValidationMessageStore.Add(() => Model.FromModemId, result.ErrorMessage ?? "Failed to send SMS.");

        IsSubmitted = false;
    }

    protected async Task MarkAsRead(ModemSms sms)
    {
        var modem = ModemById[sms.ModemId];
        var result = await SmsService.MarkAsReadAsync(modem, sms);
        // if(result.IsSuccess)
            // TODO: Add alert
    }

    protected async Task Delete(ModemSms sms)
    {
        var modem = ModemById[sms.ModemId];
        var result = await SmsService.DeleteAsync(modem, sms);
    }

    public record SendSmsModel
    {
        [Required(ErrorMessage = "From field is required.")]
        public string FromModemId { get; set; } = string.Empty;

        [Required(ErrorMessage = "To field is required.")]
        public string ToPhoneNumbers { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content field is required.")]
        public string Content { get; set; } = string.Empty;
    }
}