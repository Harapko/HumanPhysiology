using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Headline.Queries;

public class GetAllHeadlineQuery : IRequest<List<HeadlineEntity>>
{
    
}