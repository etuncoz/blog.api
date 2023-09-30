using Blog.Application.Common.Interfaces;
using Blog.Application.Common.Validation;
using Blog.Domain.Comments;
using FluentValidation;
using MediatR;
using OneOf;
using OneOf.Types;

namespace Blog.Application.Comments.CreateComment;

public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, OneOf<Comment, NotFound,ValidationFailed>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    private readonly IValidator<CreateCommentCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateCommentHandler(ICommentRepository commentRepository,  IPostRepository postRepository, IValidator<CreateCommentCommand> validator, IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _validator = validator;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
    }
    
    public async Task<OneOf<Comment, NotFound, ValidationFailed>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }

        var post = await _postRepository.GetPostByIdAsync(request.PostId);

        if (post is null)
        {
            return new NotFound();
        }

        var comment = Comment.Create(post.Id, request.Text);

        await _commentRepository.AddCommentAsync(comment);
        await _unitOfWork.CommitChangesAsync();

        return comment;
    }
}