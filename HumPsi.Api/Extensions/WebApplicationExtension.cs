using HumPsi.Domain;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Api.Extensions;

public static class WebApplicationExtension
{
    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        try
        {
            var humPsiDbContext = scope.ServiceProvider.GetRequiredService<HumPsiDbContext>();
            await humPsiDbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occured during startup migration");

        }
    }
}