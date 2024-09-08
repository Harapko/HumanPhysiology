using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;

public record UpdateHeadlineDtoRequest(
    Guid id,
    string title,
    IFormFile? file,
    Guid sectionId
    );