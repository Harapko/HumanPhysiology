using HumPsi.Domain;
using HumPsi.Domain.Entities;
using HumPsi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Test;

public class TestDbContext
{
    private static async Task<AppDbContext> CreateDatabase()
    {
        var option = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var databaseContext = new AppDbContext(option);
        await databaseContext.Database
            .EnsureCreatedAsync();

        return databaseContext;
    }

    private static async Task<AppDbContext> CreateDbWithSection()
    {
        var context = await CreateDatabase();
        
        List<SectionEntity> sectionList = [
            new SectionEntity{Id = Guid.Parse("0C345C9D-543F-48A5-AEE8-59ACCD0B95E8"), SectionName = "Test"},
            new SectionEntity{Id = Guid.Parse("A5C8DB17-CDDC-4E9D-8C23-4B0C89A94AF9"), SectionName = "Test3"}
        ];

        await context.AddRangeAsync(sectionList);
        await context.SaveChangesAsync();
        
        return context;
    }

    protected static async Task<SectionRepository> SectionRepository() =>
        new SectionRepository(await CreateDbWithSection(), null, null);
}