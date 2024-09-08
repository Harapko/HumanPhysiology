using Microsoft.AspNetCore.Http;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public record CreateHeadlineDtoRequest(
    string title,
    IFormFile? file,
    Guid sectionId
    );