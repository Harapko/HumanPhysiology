using HumPsi.Domain.Abstraction.IRepositories;
using MediatR;

namespace HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;

public class UpdateHeadlineHandler(IHeadlineRepository repository) : IRequestHandler<UpdateHeadlineCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(UpdateHeadlineCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.UpdateHeadline(request.headline, request.File);
        return result;
    }
}