using FluentValidation;

namespace Blog.Application.Posts.CreatePost;

public class CreatePostValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostValidator()
    {
        RuleFor(r => r.Title.Length)
            .InclusiveBetween(1, 100);
        
        RuleFor(r => r.Description.Length)
            .InclusiveBetween(1, 500);
    }
}