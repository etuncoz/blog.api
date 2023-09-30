using FluentValidation;

namespace Blog.Application.Comments.CreateComment;

public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentValidator()
    {
        RuleFor(r => r.Text.Length)
            .InclusiveBetween(1, 500);

        RuleFor(r => r.PostId)
            .NotEmpty();
    }
}