using HumPsi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Application.Section.Commands.DeleteSectionCommand;

public class DeleteSectionHandler(AppDbContext context) : IRequestHandler<DeleteSectionCommand, Guid>
{
    public async Task<Guid> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await context.Section
                .Where(s => s.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken: cancellationToken);
            
        }
        catch (InvalidOperationException e)
        {
            var objFromDb = await context.Section
                .FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
            if (objFromDb is null) return Guid.Empty;

            context.Section.Remove(objFromDb);
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