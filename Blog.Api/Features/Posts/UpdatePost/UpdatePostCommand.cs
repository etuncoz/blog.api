using MediatR;

namespace Blog.Api.Features.Posts.UpdatePost;

public record UpdatePostCommand(Guid Id, string Title, string Description) : IRequest<bool>;