using Huawei.E3372.Manager.Logic.Constants;

namespace Huawei.E3372.Manager.Logic.Entities;

public record ModemStatusThic : ModemStatus
{
    public string? MCC { get; set; }
    public TimeZoneInfo? TimeZoneInfo { get; set; }

    public DateTimeOffset LastUpdatedAtLocal { get; set; }

    public ModemStatusThic() : base() { }
    public ModemStatusThic(ModemStatus modemStatus) : base(modemStatus)
    {
        if (!string.IsNullOrEmpty(IMSI))
        {
            MCC = IMSI.Substring(0, 3);
            TimeZoneInfo = MobileCountyCodeConstants.MobileCountyCodeToTimeZone[MCC];
            LastUpdatedAtLocal = TimeZoneInfo.ConvertTimeFromUtc(LastUpdatedAt, TimeZoneInfo);
        }
        else
        {
            LastUpdatedAtLocal = new DateTimeOffset(LastUpdatedAt, TimeSpan.Zero);
        }
    }

    public virtual bool Equals(ModemStatusThic status)
    {
        if (status == null) return false;

        if (base.Equals(status) == false) return false;
        if (MCC != status.MCC) return false;

        return true;
    }
}