using FluentValidation;

namespace HumPsi.Application.Section.Commands.UpdateSectionCommand;

public class UpdateSectionValidation : AbstractValidator<UpdateSectionCommand>
{
    public UpdateSectionValidation()
    {
        RuleFor(s => s.section.Id)
            .NotNull().WithMessage("Id isn`t be bull");
        
        RuleFor(s => s.section.SectionName)
            .NotNull().WithMessage("Section title isn`t be bull")
            .MaximumLength(20).WithMessage("Max length is 20");
    }
}