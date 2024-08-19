using FluentAssertions;
using HumPsi.Application.Section.Commands.UpdateSectionCommand;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Section.Commands;

public class UpdateSectionHandlerTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnGuid_IfUpdatingIsTrue()
    {
        //Arrange
        var repository = await SectionRepository();

        //Act
        var result = await repository.UpdateSection(Guid.Parse("A5C8DB17-CDDC-4E9D-8C23-4B0C89A94AF9"), "SectionTestUpdate");

        //Assert
        result.Should().NotBeEmpty();
    }
    
}