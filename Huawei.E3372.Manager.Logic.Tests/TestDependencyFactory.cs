using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Huawei.E3372.Manager.Logic.Tests;

public static class TestDependencyFactory
{
    public static IMemoryCache CreateMemoryCache()
    {
        var options = new MemoryCacheOptions();
        return new MemoryCache(options);
    }

    public static ApplicationDbContext CreateDbContext()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(nameof(ApplicationDbContext))
            .UseInternalServiceProvider(serviceProvider)
            .Options;

        var dbContext = new ApplicationDbContext(options);
        dbContext.Database.EnsureCreated();

        return dbContext;
    }
}