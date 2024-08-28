using Microsoft.AspNetCore.Http;

namespace HumPsi.Domain.Abstraction.IRepositories;

public interface IPhotoRepository
{
    public Task<string> CreateImage(Guid relationId, IFormFile file, string path);
    public Task<string> UpdateImage(Guid relationId, IFormFile file, string path);
    
    public void DeleteImage(Guid relationId, string path);
}