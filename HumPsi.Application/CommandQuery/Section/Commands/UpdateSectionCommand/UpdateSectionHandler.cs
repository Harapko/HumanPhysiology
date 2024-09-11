using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public class UpdateSectionHandler(ISectionRepository repository, IMapper mapper) : IRequestHandler<UpdateSectionCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var section = mapper.Map<SectionEntity>(request.request);
        
        var result = await repository.UpdateSection(section);

        return result;
    }
}