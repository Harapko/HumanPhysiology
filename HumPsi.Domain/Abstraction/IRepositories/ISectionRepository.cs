using HumPsi.Domain.Entities;

namespace HumPsi.Domain.Abstraction.IRepositories;

public interface ISectionRepository
{
    Task<List<SectionEntity>> GetSection();
    Task<SectionEntity> CreateSection(SectionEntity section);
    Task<Guid> UpdateSection(Guid id, string sectionName);
    Task<Guid> DeleteSection(Guid id);
}