using AutoMapper;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using MediatR;

namespace HumPsi.Application.Section.Commands.CreateSectionCommand;

public class CreateSectionHandler(ISectionRepository repository, IMapper mapper) : IRequestHandler<CreateSectionCommand, (int code, string text)>
{
    public async Task<(int code, string text)> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        var section = mapper.Map<SectionEntity>(request.request);
        
        var result = await repository.CreateSection(section);
        
        return result;
    }
}