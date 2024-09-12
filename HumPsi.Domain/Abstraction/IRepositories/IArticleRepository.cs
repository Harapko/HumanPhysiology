using HumPsi.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Domain.Abstraction.IRepositories;

public interface IArticleRepository
{
    public Task<List<ArticleEntity>> Get();
    public Task<List<ArticleEntity>> GetFromHeadlineId(Guid headlineId);
    public Task<(int code, string text)> CreateArticle(ArticleEntity article, IFormFile? file);
    public Task<(int code, string text)> UpdateArticle(ArticleEntity article, IFormFile? file);
    public Task<string> DeleteArticle(Guid id);
    
}