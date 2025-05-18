using Huawei.E3372.Manager.Logic.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Huawei.E3372.Manager.Runtime.Components.Pages;

public partial class ModemSettingsComponent
{
    [Parameter] public Modem Modem { get; set; }
    [Parameter] public EventCallback<ModemSettings> OnChanged { get; set; }

    protected ModemSettings Model { get; set; }
    protected EditContext EditContext { get; set; }
    protected ValidationMessageStore ValidationMessageStore { get; set; }

    protected override void OnInitialized()
    {
        Model = Modem.Settings;
        EditContext = new EditContext(Model);
        EditContext.OnFieldChanged += OnFieldChangedAsync;
        ValidationMessageStore = new ValidationMessageStore(EditContext);

        base.OnInitialized();
    }

    private async void OnFieldChangedAsync(object? sender, FieldChangedEventArgs e)
    {
        await OnChanged.InvokeAsync(Model);
    }
}