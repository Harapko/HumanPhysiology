using FluentValidation;

namespace HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;

public class CreateArticleValidation : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleValidation()
    {
        RuleFor(a => a.article.Id)
            .NotEmpty().WithMessage("Article id isn`t be empty");
        
        RuleFor(a => a.article.Title)
            .NotEmpty().WithMessage("Article title isn`t be empty")
            .MaximumLength(25).WithMessage("Maximum Length is 25");

        RuleFor(a => a.article.Content)
            .NotEmpty().WithMessage("Article content can`t be empty");
        
        RuleFor(a => a.article.HeadlineId)
            .NotEmpty().WithMessage("Article must have headline id");
    }
}