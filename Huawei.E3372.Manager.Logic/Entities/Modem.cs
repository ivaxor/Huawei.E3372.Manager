using Huawei.E3372.Manager.Logic.Modems.Models;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;

namespace Huawei.E3372.Manager.Logic.Entities;

public record Modem
{
    public Guid Id { get; init; }
    public Uri Host { get; init; }
    public string DeviceName { get; init; }
    public string SerialNumber { get; init; }
    public string Imei { get; init; }
    public string Imsi { get; init; }
    public string Iccid { get; init; }
    public string MacAddress { get; init; }
    public DateTime LastUpdatedAt { get; init; }

    public Modem() { }
    public Modem(
        Uri host,
        DeviceNameResponse deviceName,
        InformationResponse information)
    {
        Id = Guid.NewGuid();
        Host = host;
        DeviceName = deviceName.Name;
        SerialNumber = information.SerialNumber;
        Imei = information.Imei;
        Imsi = information.Imsi;
        Iccid = information.Iccid;
        MacAddress = information.MacAddress1 ?? information.MacAddress2;
        LastUpdatedAt = DateTime.UtcNow;
    }

    public virtual bool Equals(Modem modem)
    {
        if (Host != modem.Host) return false;
        if (DeviceName != modem.DeviceName) return false;
        if (SerialNumber != modem.SerialNumber) return false;
        if (Imei != modem.Imei) return false;
        if (Imsi != modem.Imsi) return false;
        if (Iccid != modem.Iccid) return false;
        if (MacAddress != modem.MacAddress) return false;

        return true;
    }
}