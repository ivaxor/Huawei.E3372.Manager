using Huawei.E3372.Manager.Domain.Modem;
using Huawei.E3372.Manager.Logic.ModemClients;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Huawei.E3372.Manager.Logic.Tests;

[TestClass]
public sealed class E3372hClientTests
{
    private static readonly IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
    private static readonly ILogger<E3372hClient> logger = NullLogger<E3372hClient>.Instance;
    private static readonly E3372hClient client = new E3372hClient(memoryCache, logger);

    [DataTestMethod]
    [DataRow(typeof(BasicInformation))]
    [DataRow(typeof(StateLogin))]
    [DataRow(typeof(Status))]
    public async Task GetAsync(Type type)
    {
        var methodInfo = typeof(E3372hClient).GetMethod("GetAsync").MakeGenericMethod(type);

        var baseUri = new Uri("http://192.168.41.1");
        var response = await (Task<IModemResponse>)methodInfo.Invoke(client, [baseUri, default(CancellationToken)])!;

        Assert.IsTrue(response.GetType() == type);
    }
}