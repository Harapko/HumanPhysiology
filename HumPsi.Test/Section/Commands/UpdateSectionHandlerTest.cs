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
        var command = new UpdateSectionCommand(Guid.Parse("185A38F0-0F23-4FD2-A45F-DD2DEB722412"), "SectionTestUpdate");
        var handler = new UpdateSectionHandler(await CreateDbWithSection());

        //Act
        var result = await handler.Handle(command, default);

        //Assert
        result.Should().NotBeEmpty();
    }
    
}