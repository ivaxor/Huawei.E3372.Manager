using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Huawei.E3372.Manager.Runtime.Components.Pages;
public partial class SMS
{
    [Inject] protected ApplicationDbContext DbContext { get; set; }
    [Inject] protected ISmsService SmsService { get; set; }

    protected ModemSms[] ModemSms { get; set; }
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

        (ModemSms, ModemById) = await ConcurrentTasks.AsParallel(
             DbContext.ModemSms.OrderByDescending(m => m.DateTime).ToArrayAsync(),
             DbContext.Modems.Include(m => m.Status).ToDictionaryAsync(m => m.Id, m => m));

        await base.OnInitializedAsync();
    }

    protected void OnValidationRequested(object sender, ValidationRequestedEventArgs e)
    {
        ValidationMessageStore.Clear();

        var phoneNumbers = Model.ToPhoneNumbers.Split(",");
        foreach (var phoneNumber in phoneNumbers)
        {
            if (!SendSmsModel.ToPhoneNumberRegex.IsMatch(phoneNumber))
                ValidationMessageStore.Add(() => Model.ToPhoneNumbers, $"Invalid phone number: {phoneNumber}");
        }
    }

    protected async Task OnSubmit(EditContext context)
    {
        IsSubmitted = true;

        var modemId = Guid.Parse(Model.FromModemId);
        var modem = ModemById[modemId];

        var phoneNumbers = Model.ToPhoneNumbers.Split(",");

        var result = await SmsService.SendAsync(modem, phoneNumbers, Model.Content);
        if (result.IsSuccess)
        {
            Modal!.Close();
            Model.FromModemId = string.Empty;
            Model.ToPhoneNumbers = string.Empty;
            Model.Content = string.Empty;
        }
        else
        {
            ValidationMessageStore.Add(() => Model.FromModemId, result.ErrorMessage ?? "Failed to send SMS");
        }

        IsSubmitted = false;
    }

    public record SendSmsModel
    {
        public static readonly Regex ToPhoneNumberRegex = new Regex("\\+\\d{8,15}");

        [Required]
        public string FromModemId { get; set; } = string.Empty;

        [Required]
        public string ToPhoneNumbers { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;
    }
}