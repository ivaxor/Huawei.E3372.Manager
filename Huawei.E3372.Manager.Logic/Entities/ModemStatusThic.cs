using Huawei.E3372.Manager.Logic.Constants;

namespace Huawei.E3372.Manager.Logic.Entities;

public record ModemStatusThic : ModemStatus
{
    public string? MCC => IMSI?.Substring(0, 3);
    public TimeZoneInfo? TimeZoneInfo => MCC == null ? null : MobileCountyCodeConstants.MobileCountyCodeToTimeZone[MCC];

    public ModemStatusThic() : base() { }
    public ModemStatusThic(ModemStatus status) : base(status) { }

    public virtual bool Equals(ModemStatusThic status)
    {
        if (status == null) return false;

        if (base.Equals(status) == false) return false;
        if (MCC != status.MCC) return false;

        return true;
    }
}