using FluentAssertions;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Headline.Commands;

public class UpdateHeadlineCommandTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnString_IfUpdateIsTrue()
    {
        //Arrange
        var repository = await HeadlineRepository();

        var headlineUpdate = new HeadlineEntity
        {
            Id = Guid.Parse("FB7D0A97-E478-4042-81F2-C63AA2E02891"),
            Title = "Headline1UpdateTest",
            SectionId = Guid.Parse("A5C8DB17-CDDC-4E9D-8C23-4B0C89A94AF9")
        };

        //Act
        var result = await repository.UpdateHeadline(
            headlineUpdate,
            CreateFormFileFromDisk("/Users/maks/RiderProjects/HumanPhysiology/HumPsi.Api/wwwroot/headlinePhoto/9d4095b3-e386-4f8e-9a27-d3c04a3cc127.png")
            );

        //Assert
        result.code.Should().Be(1);

    }
}