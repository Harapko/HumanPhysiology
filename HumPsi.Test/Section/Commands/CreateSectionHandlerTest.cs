using FluentAssertions;
using HumPsi.Application.Section.Commands.CreateSectionCommand;
using HumPsi.Domain.Entities;
using HumPsi.Infrastructure.Repositories;
using Xunit;

namespace HumPsi.Test.Section.Commands;

public sealed class CreateSectionHandlerTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnSectionEntity_IfCreationIsTrue()
    {
        //Arrange
        var repository = await SectionRepository();
        var section = new SectionEntity
        {
            Id = Guid.NewGuid(),
            SectionName = "TestSection2"
        };

        //Act
        var result = await repository.CreateSection(section);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<SectionEntity>();
    }
}