using FluentValidation;

namespace HumPsi.Application.Section.Commands.CreateSectionCommand;

public class CreateSectionValidation : AbstractValidator<CreateSectionCommand>
{
    public CreateSectionValidation()
    {
        RuleFor(s => s.request.title)
            .NotNull().WithMessage("Section title isn`t be bull")
            .MaximumLength(20).WithMessage("Max length is 20");
    }
}