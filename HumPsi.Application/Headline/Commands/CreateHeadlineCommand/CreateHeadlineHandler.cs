using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public class CreateHeadlineHandler(IHeadlineRepository repository) : IRequestHandler<CreateHeadlineCommand, HeadlineEntity>
{
    public async Task<HeadlineEntity> Handle(CreateHeadlineCommand request, CancellationToken cancellationToken)
    {
        var headline = new HeadlineEntity
        {
            Id = request.Id,
            Title = request.Title,
            SectionId = request.SectionId
        };

        var result = await repository.CreateHeadline(request.File, headline);

        return result;
    }
}