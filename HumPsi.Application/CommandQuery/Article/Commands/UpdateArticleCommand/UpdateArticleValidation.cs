using FluentValidation;

namespace HumPsi.Application.CommandQuery.Article.Commands.UpdateArticleCommand;

public class UpdateArticleValidation : AbstractValidator<UpdateArticleCommand>
{
    public UpdateArticleValidation()
    {
        RuleFor(a => a.request.id)
            .NotEmpty().WithMessage("Article id isn`t be empty");
        
        RuleFor(a => a.request.title)
            .MaximumLength(25).WithMessage("Maximum length is 25");

        
    }
}