using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HumPsi.Infrastructure.Repositories;

public class HeadlineRepository(
    AppDbContext context,
    IRedisRepository redis,
    ILogger<HeadlineRepository> logger,
    IPhotoRepository photoRepository,
    IConfiguration configuration) : IHeadlineRepository
{
    public async Task<List<HeadlineEntity>> GetHeadline()
    {
        var headline = await redis.GetData<List<HeadlineEntity>>(configuration["HeadlineCache"]!);
        
        if (headline is not null)
        {
            logger.LogInformation("Get Headline from redis");
            return headline;
        }

        var headlineDb = await context.Headline
            .AsNoTracking()
            .ToListAsync();

        await redis.SetData("Headline", headlineDb);
        
        logger.LogInformation("Get Headline from db");
        return headlineDb;
    }

    public async Task<List<HeadlineEntity>> GetHeadlineFromSectionId(Guid sectionId)
    {
        var headlineList = await GetHeadline();
        
        var result = headlineList
            .Where(h => h.SectionId == sectionId)
            .ToList();

        if (result.Count == 0)
            return [];

        return result;
    }

    public async Task<(int code, string text)> CreateHeadline(IFormFile? file, HeadlineEntity headline)
    {
        if (await CheckExistItem(headline.Title))
            return (0, $"Headline {headline.Title} already exist");
        
        headline.PhotoPath = await photoRepository.UpdateImage(headline.Id, file, "headlinePhoto");
        
        await context.Headline.AddAsync(headline);
        await context.SaveChangesAsync();

        await redis.AddItemToCollection(configuration["HeadlineCache"]!, headline);
         
        return (1, $"Headline {headline.Title} was create");
    }

    public async Task<(int code, string text)> UpdateHeadline(HeadlineEntity headline, IFormFile? file)
    {
        if (await CheckExistItem(headline.Title))
            return (0, $"Headline {headline.Title} already exist");
        
        var updateDirectory = await photoRepository.UpdateImage(headline.Id, file, "headlinePhoto");
        try
        {
            await context.Headline
                .Where(h => h.Id == headline.Id)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(h => h.Title, headline.Title)
                    .SetProperty(h => h.PhotoPath, updateDirectory));

            await redis.UpdateItemToCollection(configuration["HeadlineCache"]!, h => h.Id == headline.Id, headline);
        }
        catch (InvalidOperationException e)
        {
            var objFromDb = await context.Headline.FindAsync(headline.Id);
            
            if (objFromDb is null) return default;
            
            objFromDb.Title = headline.Title;
            objFromDb.PhotoPath = updateDirectory;
            context.Headline.Update(objFromDb);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        

        return (1, $"Headline {headline.Title} was update");
    }

    public async Task<Guid> DeleteHeadline(Guid id)
    {
        photoRepository.DeleteImage(id, "headlinePhoto");
        try
        {
            await context.Headline
                .Where(h => h.Id == id)
                .ExecuteDeleteAsync();

            await redis.DeleteItemToCollection<HeadlineEntity>(configuration["HeadlineCache"]!, h => h.Id == id);
            
        }
        catch (InvalidOperationException e)
        {
            var objFromDb = await context.Headline.FindAsync(id);
            
            if (objFromDb is null) return default;
            
            context.Headline.Remove(objFromDb);
            await context.SaveChangesAsync();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return id;
    }
    
    private async Task<bool> CheckExistItem(string headlineTitle)
    {
        var headlineCacheList = await redis.GetData<List<HeadlineEntity>>(configuration["HeadlineCache"]!);
        
        if (headlineCacheList is not null)
        {
            if (headlineCacheList.FirstOrDefault(h=>h.Title == headlineTitle) is not null)
            {
                logger.LogInformation("Check item from redis");
                return true;
            }
        }
    
        if (await context.Headline.FirstOrDefaultAsync(h=>h.Title == headlineTitle) != null)
        {
            logger.LogInformation("Check item from Db");
            return true;
        }
    
        return false;
    }
}