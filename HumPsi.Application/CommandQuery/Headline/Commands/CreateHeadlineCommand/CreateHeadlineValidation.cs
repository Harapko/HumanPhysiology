using FluentValidation;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public class CreateHeadlineValidation : AbstractValidator<CreateHeadlineCommand>
{
    public CreateHeadlineValidation()
    {
        RuleFor(h => h.request.title)
            .NotEmpty().WithMessage("Headline title isn`t be empty")
            .MaximumLength(25).WithMessage("Maximum Length is 25");

        RuleFor(h => h.request.sectionId)
            .NotEmpty().WithMessage("Headline must have SectionId");
    }
}