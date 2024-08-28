using FluentAssertions;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Headline.Queries;

public class GetAllHeadlineQueryTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnAllHeadline()
    {
        //Arrange
        var repository = await HeadlineRepository();
        
        //Act
        var headline = await repository.GetHeadline();

        //Assert
        headline.Should().NotBeNull();
        headline.Should().BeOfType<List<HeadlineEntity>>();
    }
}