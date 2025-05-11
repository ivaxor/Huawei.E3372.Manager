using Huawei.E3372.Manager.Logic.Modems.Models;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;

namespace Huawei.E3372.Manager.Logic.Entities;

public record Modem
{
    public Guid Id { get; init; }

    public Uri Uri { get; init; }
    public string DeviceName { get; init; }
    public string SerialNumber { get; init; }
    public string Imei { get; init; }

    public string MacAddress { get; init; }

    public virtual IEnumerable<ModemSms>? Sms { get; init; }
    public virtual ModemStatus? Status { get; init; }

    public DateTime CreatedAt { get; init; }
    public DateTime LastUpdatedAt { get; init; }

    public Modem() { }
    public Modem(
        Uri uri,
        DeviceNameResponse deviceName,
        InformationResponse information)
    {
        Uri = uri;

        DeviceName = deviceName.Name;

        SerialNumber = information.SerialNumber;
        Imei = information.Imei;
        MacAddress = information.MacAddress1 ?? information.MacAddress2;

        CreatedAt = DateTime.UtcNow;
        LastUpdatedAt = DateTime.UtcNow;
    }

    public virtual bool Equals(Modem modem)
    {
        if (modem == null) return false;

        if (Uri != modem.Uri) return false;

        if (DeviceName != modem.DeviceName) return false;

        if (SerialNumber != modem.SerialNumber) return false;
        if (Imei != modem.Imei) return false;
        if (MacAddress != modem.MacAddress) return false;

        return true;
    }
}