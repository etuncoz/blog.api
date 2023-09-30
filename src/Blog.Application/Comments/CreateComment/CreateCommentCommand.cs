using Blog.Application.Common.Validation;
using Blog.Domain.Comments;
using MediatR;
using OneOf;
using OneOf.Types;

namespace Blog.Application.Comments.CreateComment;

public record CreateCommentCommand(Guid PostId, string Text) : IRequest<OneOf<Comment, NotFound, ValidationFailed>>;