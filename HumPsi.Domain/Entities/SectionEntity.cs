namespace HumPsi.Domain.Entities;

public class SectionEntity
{
    public Guid Id { get; init; }
    public string SectionName { get; set; } = string.Empty;
    public List<HeadlineEntity> Headlines { get; set; } = [];
}