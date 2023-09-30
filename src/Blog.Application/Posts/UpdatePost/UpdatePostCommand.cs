using MediatR;

namespace Blog.Application.Posts.UpdatePost;

public record UpdatePostCommand(Guid Id, string Title, string Description) : IRequest<bool>;