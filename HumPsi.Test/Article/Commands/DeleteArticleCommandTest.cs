using FluentAssertions;
using Xunit;

namespace HumPsi.Test.Article.Commands;

public class DeleteArticleCommandTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnOne_IfDeleteIsTrue()
    {
        //Arrange
        var repository = await ArticleRepository();

        //Act
        var result = await repository.DeleteArticle(Guid.Parse("08B4D7E9-176D-4A71-BD1E-0C8A015CFC2D"));

        //Assert
        result.Should().Be("Article was delete");
    }
}