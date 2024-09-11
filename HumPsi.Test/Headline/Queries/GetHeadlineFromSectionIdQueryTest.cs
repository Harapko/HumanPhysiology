using FluentAssertions;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Headline.Queries;

public class GetHeadlineFromSectionIdQueryTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnHeadlineFromSectionId()
    {
        //Arrange
        var repository = await HeadlineRepository();

        //Act
        var result = await repository.GetHeadlineFromSectionId(Guid.Parse("0C345C9D-543F-48A5-AEE8-59ACCD0B95E8"));

        //Assert
        result.Should().NotBeEmpty();
        result.Should().BeOfType<List<HeadlineEntity>>();
    }
}