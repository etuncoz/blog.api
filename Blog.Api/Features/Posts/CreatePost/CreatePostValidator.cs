using Blog.Api.Models.Posts;
using FluentValidation;

namespace Blog.Api.Features.Posts.CreatePost;

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