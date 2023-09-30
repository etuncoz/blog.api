using FluentValidation;

namespace Blog.Application.Posts.UpdatePost;

public class UpdatePostValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostValidator()
    {
        RuleFor(r => r.Title.Length)
            .InclusiveBetween(1, 100);
        
        RuleFor(r => r.Description.Length)
            .InclusiveBetween(1, 500);
    }
}