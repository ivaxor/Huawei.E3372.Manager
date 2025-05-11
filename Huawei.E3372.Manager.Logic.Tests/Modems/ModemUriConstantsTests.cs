using Huawei.E3372.Manager.Logic.Modems;
using Huawei.E3372.Manager.Logic.Modems.Models;

namespace Huawei.E3372.Manager.Logic.Tests.Modems;

[TestClass]
public sealed class ModemUriConstantsTests
{
    [TestMethod]
    public void TypeToRelativeUri_Keys_IsAssignableToIModemGetResponse_IsAssignableToIModemPostResponse()
    {
        foreach (var kvp in ModemUriConstants.TypeToRelativeUri)
            Assert.IsTrue(kvp.Key.IsAssignableTo(typeof(IModemGetResponse)) || kvp.Key.IsAssignableTo(typeof(IModemPostResponse)), $"{kvp.Key.Name} is not assignable to {nameof(IModemGetResponse)} or {nameof(IModemPostResponse)}");
    }

    [TestMethod]
    public void TypeToRelativeUri_Values_IsNotNullOrWhiteSpace()
    {
        foreach (var kvp in ModemUriConstants.TypeToRelativeUri)
            Assert.IsFalse(string.IsNullOrWhiteSpace(kvp.Value), $"{kvp.Key} uri is null or white space");
    }
}