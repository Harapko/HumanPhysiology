using FluentAssertions;
using HumPsi.Application.Section.Commands.CreateSectionCommand;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Section.Commands;

public sealed class CreateSectionHandlerTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnSectionEntity_IfCreationIsTrue()
    {
        //Arrange
        var command = new CreateSectionCommand("TestSection2");

        var handler = new CreateSectionHandler(await CreateDbWithSection());

        //Act
        var result = await handler.Handle(command, default);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<SectionEntity>();
    }
}