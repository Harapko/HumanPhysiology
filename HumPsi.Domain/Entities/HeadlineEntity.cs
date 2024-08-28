namespace HumPsi.Domain.Entities;

public class HeadlineEntity
{
    public Guid Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public string PhotoPath { get; set; } = string.Empty;
    public Guid SectionId { get; set; }
    public SectionEntity SectionEntity { get; set; }
}