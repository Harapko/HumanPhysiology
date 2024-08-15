using FluentValidation;

namespace HumPsi.Application.Section.Commands.CreateSectionCommand;

public class CreateSectionValidation : AbstractValidator<CreateSectionCommand>
{
    public CreateSectionValidation()
    {
        RuleFor(s => s.Id)
            .NotNull().WithMessage("Id isn`t be bull");
        
        RuleFor(s => s.Title)
            .NotNull().WithMessage("Section title isn`t be bull")
            .MaximumLength(20).WithMessage("Max length is 20");
    }
}