using HumPsi.Domain.Entities;

namespace HumPsi.Domain.Abstraction.IRepositories;

public interface IArticleRepository
{
    public Task<List<ArticleEntity>> Get();
    public Task<List<ArticleEntity>> GetFromHeadlineId(Guid headlineId);
    public Task<Guid> CreateArticle(ArticleEntity article);
    public Task<Guid> UpdateArticle(Guid id, string title, string content, DateTime createAt, Guid headlineId);
    public Task<Guid> DeleteArticle(Guid id);
}