using FluentAssertions;
using HumPsi.Application.Section.Commands.UpdateSectionCommand;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Section.Commands;

public class UpdateSectionHandlerTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnString_IfUpdatingIsTrue()
    {
        //Arrange
        var repository = await SectionRepository();
        var updatedSection = new SectionEntity
        {
            Id = Guid.Parse("0C345C9D-543F-48A5-AEE8-59ACCD0B95E8"),
            SectionName = "SectionTestUpdate"
        };

        //Act
        var result = await repository.UpdateSection(updatedSection);

        //Assert
        result.code.Should().Be(1);
    }
    
}