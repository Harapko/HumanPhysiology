using FluentAssertions;
using Xunit;

namespace HumPsi.Test.Headline.Commands;

public class UpdateHeadlineCommandTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnString_IfUpdateIsTrue()
    {
        //Arrange
        var repository = await HeadlineRepository();

        //Act
        var result = await repository.UpdateHeadline(
            Guid.Parse("FB7D0A97-E478-4042-81F2-C63AA2E02891"),
            "Headline1UpdateTest",
            CreateFormFileFromDisk("/Users/maks/RiderProjects/HumanPhysiology/HumPsi.Api/wwwroot/headlinePhoto/9d4095b3-e386-4f8e-9a27-d3c04a3cc127.png")
            );

        //Assert
        result.Should().NotBeEmpty();
    }
}