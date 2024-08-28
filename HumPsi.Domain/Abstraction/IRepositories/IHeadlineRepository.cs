using HumPsi.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Domain.Abstraction.IRepositories;

public interface IHeadlineRepository
{
    public Task<List<HeadlineEntity>> GetHeadline();
    public Task<HeadlineEntity> CreateHeadline(IFormFile file, HeadlineEntity headline);
    public Task<Guid> UpdateHeadline(Guid id, string title, IFormFile file);
    public Task<Guid> DeleteHeadline(Guid id);
}