using HumPsi.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Domain.Abstraction.IRepositories;

public interface IHeadlineRepository
{
    public Task<List<HeadlineEntity>> GetHeadline();
    public Task<(int code, string text)> CreateHeadline(IFormFile file, HeadlineEntity headline);
    public Task<(int code, string text)> UpdateHeadline(HeadlineEntity headline, IFormFile file);
    public Task<Guid> DeleteHeadline(Guid id);
}