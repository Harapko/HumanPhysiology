using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;
using HumPsi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumPsi.Infrastructure.Repositories;

public class SectionRepository(AppDbContext context) : ISectionRepository
{
    public async Task<List<SectionEntity>> GetSection()
    {
        var sectionList = await context.Section
            .AsNoTracking()
            .ToListAsync();

        return sectionList;
    }

    public async Task<SectionEntity> CreateSection(SectionEntity section)
    {
        await context.Section.AddAsync(section);
        await context.SaveChangesAsync();
        return section;
    }

    public async Task<Guid> UpdateSection(Guid id, string sectionName)
    {
        try
        {
            await context.Section
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(s => s.SectionName, sectionName));
        }
        catch (InvalidOperationException e)
        {
            var objFromDb = await context.Section
                .FindAsync(id);
            if (objFromDb is null) return Guid.Empty;

            objFromDb.SectionName = sectionName;

            context.Update(objFromDb);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return id;
    }

    public async Task<Guid> DeleteSection(Guid id)
    {
        try
        {
            await context.Section
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();
            
        }
        catch (InvalidOperationException e)
        {
            var objFromDb = await context.Section
                .FindAsync(id);
            if (objFromDb is null) return Guid.Empty;

            context.Section.Remove(objFromDb);
            await context.SaveChangesAsync();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return id;
    }
}