using FluentAssertions;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Article.Queries;

public class GetArticleFromHeadlineIdQueryTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnArticleFromHeadlineId()
    {
        //Arrange
        var repository = await ArticleRepository();

        //Act
        var result = await repository.GetFromHeadlineId(Guid.Parse("59655C2F-AE2B-4054-B553-6E9A3CFEBE91"));

        //Assert
        result.Should().NotBeEmpty();
        result.Should().BeOfType<List<ArticleEntity>>();
    }
}