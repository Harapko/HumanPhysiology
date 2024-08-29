using FluentValidation;

namespace HumPsi.Application.Headline.Commands.UpdateHeadlineCommand;

public class UpdateHeadlineValidation : AbstractValidator<UpdateHeadlineCommand>
{
    public UpdateHeadlineValidation()
    {
        RuleFor(h => h.Id)
            .NotEmpty().WithMessage("Headline id isn`t be empty");
        
        RuleFor(h => h.Title)
            .NotEmpty().WithMessage("Headline title isn`t be empty")
            .MaximumLength(25).WithMessage("Maximum Length is 25");
        
    }
}