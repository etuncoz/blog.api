using Blog.Application.Common.Interfaces;
using Blog.Domain.Posts;
using FluentValidation;
using MediatR;

namespace Blog.Application.Posts.CreatePost;

public class CreatePostHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IPostRepository _postRepository;
    private readonly IValidator<CreatePostCommand> _validator;

    public CreatePostHandler(IPostRepository postRepository, IValidator<CreatePostCommand> validator)
    {
        _postRepository = postRepository;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var post = new Post
        {
            Id = new Guid(),
            Title = request.Title,
            Description = request.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            CreatedBy = Guid.Empty,
            UpdatedBy = Guid.Empty
        };

        await _postRepository.AddPostAsync(post);

        return post.Id!;
    }
}