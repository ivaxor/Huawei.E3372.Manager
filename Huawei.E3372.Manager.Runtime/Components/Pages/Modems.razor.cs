using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Huawei.E3372.Manager.Runtime.Components.Pages;

public partial class Modems
{
    [Inject] protected IDiscoveryService DiscoveryService { get; set; }
    [Inject] protected ApplicationDbContext DbContext { get; set; }

    protected Modem[] ModemsInfo { get; set; }

    protected DiscoveryModel Model { get; set; } = new DiscoveryModel();
    protected ModalComponent Modal { get; set; }
    protected EditContext EditContext { get; set; }
    protected ValidationMessageStore ValidationMessageStore { get; set; }
    protected bool IsSubmitted { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        EditContext = new EditContext(Model);
        EditContext.OnValidationRequested += OnValidationRequested!;
        ValidationMessageStore = new ValidationMessageStore(EditContext);

        ModemsInfo = await DbContext.Modems
            .OrderByDescending(m => m.CreatedAt)
            .Include(m => m.Status)
            .ToArrayAsync();

        await base.OnInitializedAsync();
    }

    protected void OnValidationRequested(object sender, ValidationRequestedEventArgs e)
    {
        ValidationMessageStore.Clear();

        if (!Uri.TryCreate(Model.RawUri, UriKind.Absolute, out var uri))
            ValidationMessageStore.Add(() => Model.RawUri, "Invalid URI. Only absolute URI is accepted.");

        if (!string.IsNullOrEmpty(Model.PhoneNumber) && !DiscoveryModel.PhoneNumberRegex.IsMatch(Model.PhoneNumber))
            ValidationMessageStore.Add(() => Model.PhoneNumber, "Invalid phone number.");
    }

    protected void OnClose()
    {
        EditContext.OnValidationRequested -= OnValidationRequested;

        Model = new DiscoveryModel();
        EditContext = new EditContext(Model);
        EditContext.OnValidationRequested += OnValidationRequested!;
        ValidationMessageStore = new ValidationMessageStore(EditContext);
    }

    protected async Task OnValidSubmit(EditContext context)
    {
        IsSubmitted = true;

        var uri = new Uri(Model.RawUri, UriKind.Absolute);
        var result = await DiscoveryService.DiscoverAsync(uri, Model.PhoneNumber);
        if (result.IsSuccess)
        {
            ModemsInfo = await DbContext.Modems
                .OrderByDescending(m => m.CreatedAt)
                .Include(m => m.Status)
                .ToArrayAsync();

            Modal.Close();
        }
        else
        {
            switch (result.ErrorCode)
            {
                case ServiceResultErrorCode.Duplicate:
                    ValidationMessageStore.Add(() => Model.RawUri, "Duplicate URI. Modem with this URI already exists.");
                    break;
                default:
                    ValidationMessageStore.Add(() => Model.RawUri, result.ErrorMessage ?? "Failed to discover modem.");
                    break;
            }
        }

        IsSubmitted = false;
    }

    public record DiscoveryModel
    {
        public static readonly Regex PhoneNumberRegex = new Regex("\\+\\d{8,15}");

        [Required(ErrorMessage = "URI field is required.")]
        public string RawUri { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    }
}