using Huawei.E3372.Manager.Logic.Modems.Models;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;
using System.Web;

namespace Huawei.E3372.Manager.Logic.Entities;

public record ModemStatus
{
    public Guid Id { get; init; }
    public Guid ModemId { get; init; }

    public virtual Modem? Modem { get; init; }

    public string? IMSI { get; init; }
    public string? ICCID { get; init; }

    public string? OperatorName { get; init; }
    public string? OperatorNumber { get; init; }

    public int? CellId { get; init; }
    public string? RSRQ { get; init; }
    public string? RSRP { get; init; }
    public string? RSSI { get; init; }
    public string? SINR { get; init; }

    public bool SmsStorageFull { get; init; }

    public DateTime LastUpdatedAt { get; init; }

    public ModemStatus() { }
    public ModemStatus(
        Modem modem,
        InformationResponse information,
        OperatorResponse operatorInfo,
        SignalResponse signal,
        CheckNotificationResponse checkNotification)
    {
        ModemId = modem.Id;

        IMSI = information.Imsi;
        ICCID = information.Iccid;

        OperatorName = HttpUtility.HtmlDecode(operatorInfo.FullName);
        OperatorNumber = operatorInfo.Numeric;

        CellId = signal.CellId;
        RSRQ = HttpUtility.HtmlDecode(signal.Rsrq);
        RSRP = HttpUtility.HtmlDecode(signal.Rsrp);
        RSSI = HttpUtility.HtmlDecode(signal.Rssi);
        SINR = HttpUtility.HtmlDecode(signal.Sinr);

        SmsStorageFull = checkNotification.SmsStorageFull;

        LastUpdatedAt = DateTime.UtcNow;
    }

    public virtual bool Equals(ModemStatus status)
    {
        if (ModemId == status.ModemId) return false;

        if (IMSI == status.IMSI) return false;
        if (ICCID == status.ICCID) return false;

        if (OperatorName == status.OperatorName) return false;
        if (OperatorNumber == status.OperatorNumber) return false;

        if (CellId == status.CellId) return false;
        if (RSRQ == status.RSRQ) return false;
        if (RSRP == status.RSRP) return false;
        if (RSSI == status.RSSI) return false;
        if (SINR == status.SINR) return false;

        if (SmsStorageFull == status.SmsStorageFull) return false;

        return true;
    }
}