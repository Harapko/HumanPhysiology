using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using HumPsi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace HumPsi.Test;

public class TestDbContext
{
    private static readonly Mock<IRedisRepository> MockRedis = new();
    private static readonly Mock<IWebHostEnvironment> MockIWebHost = new();

    private static async Task<AppDbContext> CreateDatabase()
    {
        var option = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var databaseContext = new AppDbContext(option);
        await databaseContext.Database
            .EnsureCreatedAsync();

        return databaseContext;
    }

    private static async Task<AppDbContext> CreateDb()
    {
        var context = await CreateDatabase();

        List<SectionEntity> sectionList =
        [
            new SectionEntity { Id = Guid.Parse("0C345C9D-543F-48A5-AEE8-59ACCD0B95E8"), SectionName = "Section1" },
            new SectionEntity { Id = Guid.Parse("A5C8DB17-CDDC-4E9D-8C23-4B0C89A94AF9"), SectionName = "Section2" }
        ];
        
        List<HeadlineEntity> headlineList =
        [
            new HeadlineEntity
            {
                Id = Guid.Parse("FB7D0A97-E478-4042-81F2-C63AA2E02891"),
                Title = "Headline1",
                PhotoPath = "",
                SectionId = Guid.Parse("0C345C9D-543F-48A5-AEE8-59ACCD0B95E8")
            },
            new HeadlineEntity
            {
                Id = Guid.Parse("59655C2F-AE2B-4054-B553-6E9A3CFEBE91"),
                Title = "Headline2",
                PhotoPath = "",
                SectionId = Guid.Parse("A5C8DB17-CDDC-4E9D-8C23-4B0C89A94AF9")
            }
        ];

        await context.Section.AddRangeAsync(sectionList);
        await context.Headline.AddRangeAsync(headlineList);
        await context.SaveChangesAsync();


        return context;
    }

    protected static async Task<SectionRepository> SectionRepository()
    {
        return new SectionRepository(await CreateDb(), MockRedis.Object,
            new Mock<ILogger<SectionRepository>>().Object, new Mock<IConfiguration>().Object);
    }

    protected static async Task<HeadlineRepository> HeadlineRepository()
    {
        return new HeadlineRepository(await CreateDb(), MockRedis.Object,
            new Mock<ILogger<HeadlineRepository>>().Object, PhotoRepository(), new Mock<IConfiguration>().Object);
    }

    private static PhotoRepository PhotoRepository()
    {
        MockIWebHost.Setup(env => env.WebRootPath).Returns("/Users/maks/RiderProjects/HumanPhysiology/HumPsi.Api/wwwroot");
        var repository = new PhotoRepository(MockIWebHost.Object);
        return repository;
    }
    
    
    
    
    
    protected static IFormFile CreateFormFileFromDisk(string filePath)
    {
        var fileStream = new FileStream(filePath, FileMode.Open);
        var fileName = Path.GetFileName(filePath);

        return new FormFile(fileStream, 0, fileStream.Length, "file", fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = GetContentType(filePath)
        };
    }

    private static string GetContentType(string path)
    {
        var extension = Path.GetExtension(path).ToLowerInvariant();
        return extension switch
        {
            ".jpg" => "image/jpeg",
            ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".pdf" => "application/pdf",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            _ => "application/octet-stream",
        };
    }
}