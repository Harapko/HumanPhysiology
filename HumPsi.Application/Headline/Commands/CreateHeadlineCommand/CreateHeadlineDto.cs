using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public record CreateHeadlineDto(
    string title,
    IFormFile file,
    Guid sectionId
    );