using Huawei.E3372.Manager.Logic.Constants;
using Huawei.E3372.Manager.Logic.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Huawei.E3372.Manager.Runtime.Components.Pages;

public partial class ModemStatusComponent
{
    [Parameter] public Modem Modem { get; set; }

    [Parameter] public EventCallback<ModemStatus> OnChanged { get; set; }

    protected ModemStatusThic Model { get; set; }
    protected EditContext EditContext { get; set; }
    protected ValidationMessageStore ValidationMessageStore { get; set; }


    protected override void OnInitialized()
    {
        Model = new ModemStatusThic(Modem.Status!);

        EditContext = new EditContext(Model);
        EditContext.OnFieldChanged += OnFieldChangedAsync;
        ValidationMessageStore = new ValidationMessageStore(EditContext);

        base.OnInitialized();
    }

    protected async void OnFieldChangedAsync(object? sender, FieldChangedEventArgs e)
    {
        ValidationMessageStore.Clear();

        if (string.IsNullOrEmpty(Model.PhoneNumber) || RegexConstants.PhoneNumberRegex.IsMatch(Model.PhoneNumber))
            await OnChanged.InvokeAsync(Model);
        else
            ValidationMessageStore.Add(() => Model.PhoneNumber, $"Invalid phone number.");
    }
}