using Blog.Application.Common.Interfaces;
using Blog.Application.Common.Validation;
using Blog.Domain.Posts;
using FluentValidation;
using MediatR;
using OneOf;

namespace Blog.Application.Posts.CreatePost;

public class CreatePostHandler : IRequestHandler<CreatePostCommand, OneOf<Post, ValidationFailed>>
{
    private readonly IPostRepository _postRepository;
    private readonly IValidator<CreatePostCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostHandler(IPostRepository postRepository, IValidator<CreatePostCommand> validator, IUnitOfWork unitOfWork)
    {
        _postRepository = postRepository;
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<OneOf<Post, ValidationFailed>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }

        var post = Post.Create(request.Title, request.Description);

        await _postRepository.AddPostAsync(post);
        await _unitOfWork.CommitChangesAsync();
        
        return post;
    }
}