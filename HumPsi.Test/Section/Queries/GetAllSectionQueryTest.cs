using FluentAssertions;
using HumPsi.Application.Section.Queries.GetAllSectionQuery;
using HumPsi.Domain.Entities;
using HumPsi.Infrastructure.Repositories;
using Xunit;

namespace HumPsi.Test.Section.Queries;

public class GetAllSectionQueryTest : TestDbContext
{
    [Fact]
    public async Task Handle_Should_ReturnAllSection()
    {
        //Arrange
        var repository = await SectionRepository();
        
        //Act
        var result = await repository.GetSection();

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<SectionEntity>>();
    }
}