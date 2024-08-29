using FluentValidation;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public class UpdateSectionValidation : AbstractValidator<UpdateSectionCommand>
{
    public UpdateSectionValidation()
    {
        RuleFor(s => s.id)
            .NotNull().WithMessage("Id isn`t be bull");
        
        RuleFor(s => s.sectionName)
            .NotNull().WithMessage("Section title isn`t be bull")
            .MaximumLength(20).WithMessage("Max length is 20");
    }
}