using FluentAssertions;
using Xunit;

namespace HumPsi.Test.Headline.Commands;

public class DeleteHeadlineCommandTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnString_IfCreationIsTrue()
    {
        //Arrange
        var repository = await HeadlineRepository();

        //Act
        var result = await repository.DeleteHeadline(Guid.Parse("59655C2F-AE2B-4054-B553-6E9A3CFEBE91"));

        //Assert
        result.Should().NotBeEmpty();
    }
}