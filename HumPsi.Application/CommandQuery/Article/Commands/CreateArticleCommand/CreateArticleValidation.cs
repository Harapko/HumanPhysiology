using FluentValidation;

namespace HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;

public class CreateArticleValidation : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleValidation()
    {
        RuleFor(a => a.request.title)
            .NotEmpty().WithMessage("Article title isn`t be empty")
            .MaximumLength(25).WithMessage("Maximum Length is 25");

        RuleFor(a => a.request.content)
            .NotEmpty().WithMessage("Article content can`t be empty");
        
        RuleFor(a => a.request.headlineId)
            .NotEmpty().WithMessage("Article must have headline id");
    }
}