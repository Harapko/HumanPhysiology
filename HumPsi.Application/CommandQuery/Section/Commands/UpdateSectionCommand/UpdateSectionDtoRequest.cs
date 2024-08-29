namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public record UpdateSectionDtoRequest(
    Guid id,
    string sectionName
    );