using FluentAssertions;
using HumPsi.Application.Section.Commands.DeleteSectionCommand;
using Xunit;

namespace HumPsi.Test.Section.Commands;

public class DeleteSectionHandlerTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnGuid_IfDeleteIsTrue()
    {
        //Arrange
        var command = new DeleteSectionCommand(Guid.Parse("185A38F0-0F23-4FD2-A45F-DD2DEB722412"));
        var handler = new DeleteSectionHandler(await CreateDbWithSection());

        //Act
        var result = await handler.Handle(command, default);

        //Asser
        result.Should().NotBeEmpty();
    }
}