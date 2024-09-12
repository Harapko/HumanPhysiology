using FluentAssertions;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Article.Queries;

public class GetAllArticleQueryTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnAllArticle()
    {
        //Arrange
        var repository = await ArticleRepository();

        //Act
        var result = await repository.Get();

        //Assert
        result.Should().NotBeEmpty();
        result.Should().BeOfType<List<ArticleEntity>>();
    }
}