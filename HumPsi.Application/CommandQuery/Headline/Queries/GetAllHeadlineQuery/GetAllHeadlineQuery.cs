using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Headline.Queries;

public record GetAllHeadlineQuery : IRequest<List<HeadlineEntity>>
{
    
}