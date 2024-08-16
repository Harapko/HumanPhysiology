using HumPsi.Domain;
using HumPsi.Domain.Entities;
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

    protected static async Task<AppDbContext> CreateDbWithSection()
    {
        var context = await CreateDatabase();

        var section = new SectionEntity
        {
            Id = Guid.Parse("185A38F0-0F23-4FD2-A45F-DD2DEB722412"),
            SectionName = "TestSection"
        };

        await context.AddAsync(section);
        await context.SaveChangesAsync();
        
        return context;
    }
}