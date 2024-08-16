using HumPsi.Domain;
using HumPsi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public class UpdateSectionHandler(AppDbContext context) : IRequestHandler<UpdateSectionCommand, Guid>
{
    public async Task<Guid> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await context.Section
                .Where(s => s.Id == request.Id)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(s => s.SectionName, request.SectionName), cancellationToken: cancellationToken);
        }
        catch (InvalidOperationException e)
        {
            var objFromDb = await context.Section
                .FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
            if (objFromDb is null) return Guid.Empty;

            objFromDb.SectionName = request.SectionName;

            context.Update(objFromDb);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        

        return request.Id;
    }
}