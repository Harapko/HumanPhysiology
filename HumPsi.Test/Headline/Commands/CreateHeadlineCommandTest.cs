using FluentAssertions;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Headline.Commands;

public class CreateHeadlineCommandTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnOne_IfCreationIsTrue()
    {
        //Arrange
        var repository = await HeadlineRepository();

        var headline = new HeadlineEntity
        {
            Id = Guid.Parse("9d4095b3-e386-4f8e-9a27-d3c04a3cc127"),
            Title = "HeadlineCreateTest",
            PhotoPath = "",
            SectionId = Guid.Parse("0C345C9D-543F-48A5-AEE8-59ACCD0B95E8")
        };

        
        //Act
        var result = await repository.CreateHeadline(CreateFormFileFromDisk("/Users/maks/RiderProjects/HumanPhysiology/HumPsi.Api/wwwroot/headlinePhoto/9d4095b3-e386-4f8e-9a27-d3c04a3cc127.png"), headline);

        //Assert
        result.code.Should().Be(1);
    }
    
    
}