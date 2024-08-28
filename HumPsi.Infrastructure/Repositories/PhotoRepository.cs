using HumPsi.Domain.Abstraction.IRepositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HumPsi.Infrastructure.Repositories;

public class PhotoRepository(IWebHostEnvironment env) : IPhotoRepository
{
    public async Task<string> CreateImage(Guid relationId, IFormFile file, string path)
    {
        try
        {
            var fileName = relationId + ".png";
            var filePath = Path.Combine($"{env.WebRootPath}/{path}", fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return filePath;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<string> UpdateImage(Guid relationId, IFormFile file, string path)
    {
        DeleteImage(relationId, path);
        var fileDirectory = await CreateImage(relationId, file, path);
        return fileDirectory;
    }

    public void DeleteImage(Guid relationId, string path)
    {
        var filePath = Path.Combine($"{env.WebRootPath}/{path}", relationId + ".png");
        File.Delete(filePath);
    }
    
}