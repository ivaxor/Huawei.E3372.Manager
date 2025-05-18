using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Huawei.E3372.Manager.Runtime.Components.Pages;

public partial class ModemsPage
{
    [Inject] protected IDiscoveryService DiscoveryService { get; set; }
    [Inject] protected ApplicationDbContext DbContext { get; set; }

    protected Modem[]? Modems { get; set; }

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

        Modems = await DbContext.Modems
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
        var result = await DiscoveryService.DiscoverAsync(uri);
        if (result.IsSuccess)
        {
            Modems = await DbContext.Modems
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
        [Required(ErrorMessage = "URI field is required.")]
        public string RawUri { get; set; } = string.Empty;
    }
}