using FluentAssertions;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Article.Commands;

public class UpdateArticleCommandTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnOne_IfUpdateIsTrue()
    {
        //Arrange
        var repository = await ArticleRepository();
        var updateArticle = new ArticleEntity
        {
            Id = Guid.Parse("65DA9F0B-64DE-4774-8D56-A17EBF7A2FD8"),
            Title = "UpdateArticle",
            Content = "UpdateContent",
            HeadlineId = Guid.Parse("59655C2F-AE2B-4054-B553-6E9A3CFEBE91")
        };

        //Act
        var result = await repository.UpdateArticle(updateArticle, CreateFormFileFromDisk(
            "/Users/maks/RiderProjects/HumanPhysiology/HumPsi.Api/wwwroot/Article/0db9b491-8f90-45ee-b500-c5ef30050c68.png"));

        //Assert
        result.code.Should().Be(1);
    }
}