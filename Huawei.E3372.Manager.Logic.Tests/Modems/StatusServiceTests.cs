using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Huawei.E3372.Manager.Logic.Tests.Modems;

[TestClass]
public sealed class StatusServiceTests
{
    internal static readonly IMemoryCache MemoryCache = TestDependencyFactory.CreateMemoryCache();
    internal static readonly ApplicationDbContext DbContext = TestDependencyFactory.CreateDbContext();
    internal static readonly ModemClient modemClient = new ModemClient(MemoryCache, Options.Create(TestConstants.ApplicationSettings), NullLogger<ModemClient>.Instance);
    internal static readonly StatusService statusService = new StatusService(modemClient, DbContext);

    [TestMethod]
    public async Task PollAsync()
    {
        var modem = new Modem() { Uri = TestConstants.ModemUri };

        await statusService.PollAsync(modem);
    }
}