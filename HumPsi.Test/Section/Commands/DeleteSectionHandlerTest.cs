using FluentAssertions;
using HumPsi.Application.Section.Commands.DeleteSectionCommand;
using Xunit;

namespace HumPsi.Test.Section.Commands;

public class DeleteSectionHandlerTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnString_IfDeleteIsTrue()
    {
        //Arrange
        var repository = await SectionRepository();

        //Act
        var result = await repository.DeleteSection(Guid.Parse("0C345C9D-543F-48A5-AEE8-59ACCD0B95E8"));

        //Asser
        result.Should().NotBeEmpty();
    }
}