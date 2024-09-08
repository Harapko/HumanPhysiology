using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Infrastructure.Repositories;

public class ArticleRepository(AppDbContext context) : IArticleRepository
{
    public async Task<List<ArticleEntity>> Get()
    {
        var articleList = await context.Article
            .AsNoTracking()
            .ToListAsync();

        return articleList;
    }

    public async Task<List<ArticleEntity>> GetFromHeadlineId(Guid headlineId)
    {
        var articleList = await context.Article
            .Where(a => a.HeadlineId == headlineId)
            .ToListAsync();

        if (articleList.Count == 0)
            return [];

        return articleList;
    }

    public async Task<Guid> CreateArticle(ArticleEntity article)
    {
        await context.Article.AddAsync(article);
        await context.SaveChangesAsync();

        return article.Id;
    }

    public Task<Guid> UpdateArticle(Guid id, string title, string content, DateTime createAt, Guid headlineId)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> DeleteArticle(Guid id)
    {
        throw new NotImplementedException();
    }
}