using Huawei.E3372.Manager.Logic.Modems;
using Huawei.E3372.Manager.Logic;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Huawei.E3372.Manager.Logic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Runtime.Components.Pages;

public partial class ModemPage
{
    [Parameter] public Guid Id { get; set; }

    [Inject] protected IModemService ModemService { get; set; }
    [Inject] protected ApplicationDbContext DbContext { get; set; }

    protected Modem? Modem { get; set; }

    protected DeleteModemModel Model { get; set; } = new DeleteModemModel();
    protected ModalComponent Modal { get; set; }
    protected EditContext EditContext { get; set; }
    protected ValidationMessageStore ValidationMessageStore { get; set; }
    protected bool IsSubmitted { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        EditContext = new EditContext(new { });
        ValidationMessageStore = new ValidationMessageStore(EditContext);

        Modem = await DbContext.Modems
            .Include(m => m.Status)
            .Include(m => m.Settings)
            .SingleOrDefaultAsync(m => m.Id == Id);

        await base.OnInitializedAsync();
    }

    protected async Task OnSettingsFieldChanged(ModemSettings modemSettings)
    {
        await DbContext.SaveChangesAsync();
    }

    protected void OnClose()
    {
        EditContext = new EditContext(new { });
        ValidationMessageStore = new ValidationMessageStore(EditContext);
    }

    protected record DeleteModemModel
    {
        public string Name { get; set; }
    }
}