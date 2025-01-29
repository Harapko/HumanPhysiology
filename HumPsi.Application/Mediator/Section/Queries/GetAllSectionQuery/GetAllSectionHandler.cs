using AutoMapper;
using MediatR;

namespace HumPsi.Application.Section.Queries.GetAllSectionQuery;

public class GetAllSectionHandler(IMapper mapper) : IRequestHandler<Mediator.Section.Queries.GetAllSectionQuery.GetAllSectionQuery, IEnumerable<GetSectionDtoResponse>>
{
    public async Task<IEnumerable<GetSectionDtoResponse>> Handle(Mediator.Section.Queries.GetAllSectionQuery.GetAllSectionQuery request, CancellationToken cancellationToken)
    {
        // await using var sqlConn = sqlConnFactory.GetConnection();
        //
        // var response = await sqlConn.QueryFirstOrDefaultAsync<GetSectionDtoResponse>(
        //     @""
        // );
        
        return [];
    }
}