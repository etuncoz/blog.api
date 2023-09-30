using Blog.Domain.Posts;
using MediatR;
using OneOf;
using OneOf.Types;

namespace Blog.Application.Posts.UpdatePost;

public record UpdatePostCommand(Guid Id, string Title, string Description) : IRequest<OneOf<Post, NotFound>>;