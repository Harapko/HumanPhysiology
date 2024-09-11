namespace HumPsi.Domain.Entities;

public class ArticleEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public string PhotoPath { get; set; } = string.Empty;
    public Guid HeadlineId { get; set; }
    public HeadlineEntity HeadlineEntity { get; set; }
}