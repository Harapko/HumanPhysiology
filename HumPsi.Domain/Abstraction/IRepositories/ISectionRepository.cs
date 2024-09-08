using HumPsi.Domain.Entities;

namespace HumPsi.Domain.Abstraction.IRepositories;

public interface ISectionRepository
{
    Task<List<SectionEntity>> GetSection();
    Task<(int code, string text)> CreateSection(SectionEntity section);
    Task<(int code, string text)> UpdateSection(SectionEntity section);
    Task<Guid> DeleteSection(Guid id);
}