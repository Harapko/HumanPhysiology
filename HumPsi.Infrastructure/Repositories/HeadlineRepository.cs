using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HumPsi.Infrastructure.Repositories;

public class HeadlineRepository(
    AppDbContext context,
    IRedisRepository redis,
    ILogger<HeadlineRepository> logger,
    IPhotoRepository photoRepository) : IHeadlineRepository
{
    public async Task<List<HeadlineEntity>> GetHeadline()
    {
        var headline = await redis.GetData<List<HeadlineEntity>>("Headline");

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

    public async Task<HeadlineEntity> CreateHeadline(IFormFile? file, HeadlineEntity headline)
    {
        if (string.IsNullOrWhiteSpace(headline.PhotoPath)) 
            headline.PhotoPath = await photoRepository.UpdateImage(headline.Id, file, "headlinePhoto");
        
        await context.Headline.AddAsync(headline);
        await context.SaveChangesAsync();
         
         return headline;
    }

    public async Task<Guid> UpdateHeadline(Guid id, string title, IFormFile file)
    {
        var updateDirectory = await photoRepository.UpdateImage(id, file, "headlinePhoto");
        await context.Headline
            .Where(h => h.Id == id)
            .ExecuteUpdateAsync(set => set
                .SetProperty(h => h.Title, title)
                .SetProperty(h => h.PhotoPath, updateDirectory));

        return id;
    }

    public async Task<Guid> DeleteHeadline(Guid id)
    {
        throw new NotImplementedException();
    }
}