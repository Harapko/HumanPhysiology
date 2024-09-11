using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HumPsi.Infrastructure.Repositories;

public class ArticleRepository(
    AppDbContext context,
    IRedisRepository redis,
    ILogger<ArticleRepository> logger,
    IConfiguration configuration,
    IPhotoRepository photoRepository) : IArticleRepository
{
    public async Task<List<ArticleEntity>> Get()
    {
        var articleCache = await redis.GetData<List<ArticleEntity>>(configuration["ArticleCache"]!);
        if (articleCache is not null)
        {
            logger.LogInformation("Get Article from cache");
            return articleCache;
        }
        
        var articleDb = await context.Article
            .AsNoTracking()
            .ToListAsync();

        await redis.SetData(configuration["ArticleCache"]!, articleDb);

        logger.LogInformation("Get Article from db");
        return articleDb;
    }

    public async Task<List<ArticleEntity>> GetFromHeadlineId(Guid headlineId)
    {
        var articleList = await Get();
        
        var result = articleList
            .Where(a => a.HeadlineId == headlineId)
            .ToList();

        if (result.Count == 0)
            return [];

        return result;
    }

    public async Task<(int code, string text)> CreateArticle(ArticleEntity article, IFormFile? file)
    {
        if (await CheckExistItem(article.Title))
            return (0, $"Article {article.Title} already exist");

        article.PhotoPath = await photoRepository.UpdateImage(article.Id, file, "Article");
            
        await context.Article.AddAsync(article);
        await context.SaveChangesAsync();

        await redis.AddItemToCollection(configuration["ArticleCache"]!, article);

        return (1, $"Article {article.Title} was create");
    }

    public async Task<(int code, string text)> UpdateArticle(ArticleEntity article, IFormFile? file)
    {
        if(await CheckExistItem(article.Title))
            return (0, $"Article {article.Title} already exist");

        try
        {
            await context.Article
                .Where(a => a.Id == article.Id)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(a => a.Title, article.Title)
                    .SetProperty(a => a.Content, article.Content)
                    .SetProperty(a => a.CreateAt, article.CreateAt)
                    .SetProperty(a => a.HeadlineId, article.HeadlineId));
            
            await photoRepository.UpdateImage(article.Id, file, "Article");

            await redis.UpdateItemToCollection(configuration["ArticleCache"]!, a=>a.Id == article.Id, article);
        }
        catch (InvalidOperationException e)
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return (1, $"Article {article.Title} was update");
    }

    public async Task<Guid> DeleteArticle(Guid id)
    {
        try
        {
            await context.Article
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
            photoRepository.DeleteImage(id, "Article");

            await redis.DeleteItemToCollection<ArticleEntity>(configuration["ArticleCache"]!, a => a.Id == id);
        }
        catch (InvalidOperationException e)
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return id;
    }
    
    private async Task<bool> CheckExistItem(string articleTitle)
    {
        var headlineCacheList = await redis.GetData<List<ArticleEntity>>(configuration["ArticleCache"]!);
        
        if (headlineCacheList is not null)
        {
            if (headlineCacheList.FirstOrDefault(h=>h.Title == articleTitle) is not null)
            {
                logger.LogInformation("Check item from redis");
                return true;
            }
        }
    
        if (await context.Article.FirstOrDefaultAsync(h=>h.Title == articleTitle) != null)
        {
            logger.LogInformation("Check item from Db");
            return true;
        }
    
        return false;
    }
}