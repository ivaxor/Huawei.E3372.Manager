using Huawei.E3372.Manager.Domain.Modem;
using System.Collections.Frozen;

namespace Huawei.E3372.Manager.Logic.ModemClients;

internal static class ModemUriConstants
{
    public readonly static IReadOnlyDictionary<Type, string> TypeToRelativeUri = new Dictionary<Type, string>()
    {
        { typeof(SessionTokenInfo), "/api/webserver/SesTokInfo" },
        { typeof(BasicInformation), "/api/device/basic_information" },
        { typeof(StateLogin), "/api/user/state-login" },
        { typeof(Status), "/api/monitoring/status" },
    }.ToFrozenDictionary();
}