using FluentAssertions;
using HumPsi.Application.Section.Queries.GetAllSectionQuery;
using HumPsi.Domain.Entities;
using Xunit;

namespace HumPsi.Test.Section.Queries;

public class GetAllSectionQueryTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnAllSection()
    {
        //Arrange
        var query = new GetAllSectionQuery();
        var handler = new GetAllSectionHandler(await CreateDbWithSection());

        //Act
        var result = await handler.Handle(query, default);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<SectionEntity>>();
    }
}