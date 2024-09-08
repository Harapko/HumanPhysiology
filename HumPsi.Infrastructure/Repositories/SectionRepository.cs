using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HumPsi.Infrastructure.Repositories;

public class SectionRepository(
    AppDbContext context,
    IRedisRepository redis,
    ILogger<SectionRepository> logger,
    IConfiguration configuration) : ISectionRepository
{
    public async Task<List<SectionEntity>> GetSection()
    {
        var section = await redis.GetData<List<SectionEntity>>(configuration["SectionCache"]!);
        if (section is not null)
        {
            logger.LogInformation("Get Section from Redis");
            return section;
        }
        
        var sectionDb = await context.Section
            .AsNoTracking()
            .ToListAsync();

        await redis.SetData(configuration["SectionCache"]!, sectionDb);

        logger.LogInformation("Get Section From Database");
        return sectionDb;
    }

    public async Task<(int code, string text)> CreateSection(SectionEntity section)
    {
        if (await CheckExistItem(section.SectionName))
            return (0, $"Section {section.SectionName} already exist");
        
        await context.Section.AddAsync(section);
        await context.SaveChangesAsync();

        await redis.AddItemToCollection(configuration["SectionCache"]!, section);
        
        return (1, $"Section {section.SectionName} was create");
    }

    public async Task<(int code, string text)> UpdateSection(SectionEntity section)
    {
        try
        {
            if (await CheckExistItem(section.SectionName))
                return (0, $"Section {section.SectionName} already exist");
            
            await context.Section
                .Where(s => s.Id == section.Id)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(s => s.SectionName, section.SectionName));

            await redis.UpdateItemToCollection(configuration["SectionCache"]!, s => s.Id == section.Id, section);
        }
        catch (InvalidOperationException e)
        {
            var objFromDb = await context.Section
                .FindAsync(section.Id);
            if (objFromDb is null) return (0, "");

            objFromDb.SectionName = section.SectionName;
            
            context.Update(objFromDb);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return (1, $"Section was update on {section.SectionName}");
    }

    public async Task<Guid> DeleteSection(Guid id)
    {
        try
        {
            await context.Section
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();

            await redis.DeleteItemToCollection<SectionEntity>(configuration["SectionCache"]!, s => s.Id == id);

        }
        catch (InvalidOperationException e)
        {
            var objFromDb = await context.Section
                .FindAsync(id);
            if (objFromDb is null) return Guid.Empty;

            context.Section.Remove(objFromDb);
            await context.SaveChangesAsync();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return id;
    }

    private async Task<bool> CheckExistItem(string sectionName)
    {
        var sectionCacheList = await redis.GetData<List<SectionEntity>>(configuration["SectionCache"]!);
        
        if (sectionCacheList is not null)
        {
            if (sectionCacheList.FirstOrDefault(s => s.SectionName == sectionName) is not null)
            {
                logger.LogInformation("Check item from redis");
                return true;
            }
        }

        if (await context.Section.FirstOrDefaultAsync(s => s.SectionName == sectionName) != null)
        {
            logger.LogInformation("Check item from Db");
            return true;
        }

        return false;
    }
}