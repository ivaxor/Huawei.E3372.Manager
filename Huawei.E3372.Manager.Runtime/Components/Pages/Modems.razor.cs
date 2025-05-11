using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Runtime.Components.Pages;

public partial class Modems
{
    [Inject] IDiscoveryService DiscoveryService { get; set; }
    [Inject] ApplicationDbContext DbContext { get; set; }

    protected DiscoveryModel Model { get; set; } = new DiscoveryModel();
    protected ModalComponent Modal { get; set; }
    protected EditContext EditContext { get; set; }
    protected ValidationMessageStore ValidationMessageStore { get; set; }
    protected bool IsSubmited { get; set; } = false;


    protected Modem[] ModemsInfo { get; set; }

    protected override async Task OnInitializedAsync()
    {
        EditContext ??= new EditContext(Model);
        EditContext.OnValidationRequested += OnValidationRequested;
        ValidationMessageStore = new ValidationMessageStore(EditContext);

        ModemsInfo ??= await DbContext.Modems
            .OrderByDescending(m => m.CreatedAt)
            .Include(m => m.Status)            
            .ToArrayAsync();

        await base.OnInitializedAsync();
    }

    protected async Task OnSubmit(EditContext context)
    {
        IsSubmited = true;

        var uri = new Uri(Model.RawUri, UriKind.Absolute);
        var result = await DiscoveryService.DiscoverAsync(uri);
        if (result.IsSuccess)
        {
            ModemsInfo = await DbContext.Modems
                .OrderByDescending(m => m.CreatedAt)
                .Include(m => m.Status)
                .ToArrayAsync();

            Modal!.Close();
            Model.RawUri = default;
        }
        else
        {
            switch (result.ErrorCode)
            {
                case ServiceResultErrorCode.Duplicate:
                    ValidationMessageStore.Add(() => Model.RawUri, "Modem with this URI already exists");
                    break;
                default:
                    ValidationMessageStore.Add(() => Model.RawUri, result.ErrorMessage ?? "Failed to discover modem");
                    break;
            }
            EditContext.NotifyValidationStateChanged();
        }

        IsSubmited = false;
    }

    protected void OnValidationRequested(object sender, ValidationRequestedEventArgs e)
    {
        ValidationMessageStore.Clear();

        if (!Uri.TryCreate(Model.RawUri, UriKind.Absolute, out var uri))
            ValidationMessageStore.Add(() => Model.RawUri, "Only absolute URI are accepted");
    }

    public record DiscoveryModel
    {
        public string RawUri { get; set; }
    }
}