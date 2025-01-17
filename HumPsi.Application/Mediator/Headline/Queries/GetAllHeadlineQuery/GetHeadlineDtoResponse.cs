namespace HumPsi.Application.Headline.Queries;

public record GetHeadlineDtoResponse(
    Guid id,
    string title,
    string photoPath,
    Guid sectionId
    );