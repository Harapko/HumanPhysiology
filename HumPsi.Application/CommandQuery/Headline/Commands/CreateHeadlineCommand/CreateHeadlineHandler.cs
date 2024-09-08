using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public class CreateHeadlineHandler(IHeadlineRepository repository) : IRequestHandler<CreateHeadlineCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(CreateHeadlineCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.CreateHeadline(request.file, request.headline);

        return result;
    }
}