using FluentValidation;

namespace HumPsi.Application.Headline.Commands.CreateHeadlineCommand;

public class CreateHeadlineValidation : AbstractValidator<CreateHeadlineCommand>
{
    public CreateHeadlineValidation()
    {
        RuleFor(h => h.Id)
            .NotEmpty().WithMessage("Headline id isn`t be empty");
        
        RuleFor(h => h.Title)
            .NotEmpty().WithMessage("Headline title isn`t be empty")
            .MaximumLength(25).WithMessage("Maximum Length is 25");

        RuleFor(h => h.SectionId)
            .NotEmpty().WithMessage("Headline must have SectionId");
    }
}