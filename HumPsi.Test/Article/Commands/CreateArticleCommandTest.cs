using FluentAssertions;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Article.Commands;

public class CreateArticleCommandTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnOne_IfCreationIsTrue()
    {
        //Arrange
        var repository = await ArticleRepository();
        var article = new ArticleEntity
        {
            Id = Guid.NewGuid(),
            Title = "NewArticle",
            Content = "Content",
            CreateAt = DateTime.Now,
            HeadlineId = Guid.Parse("59655C2F-AE2B-4054-B553-6E9A3CFEBE91")
        };

        //Act
        var result = await repository.CreateArticle(article,
            CreateFormFileFromDisk(
                "/Users/maks/RiderProjects/HumanPhysiology/HumPsi.Api/wwwroot/Article/0db9b491-8f90-45ee-b500-c5ef30050c68.png"));

        //Assert
        result.code.Should().Be(1);
    }
}