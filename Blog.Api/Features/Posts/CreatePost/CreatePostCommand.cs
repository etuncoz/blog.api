using MediatR;

namespace Blog.Api.Features.Posts.CreatePost;

public record CreatePostCommand(string Title, string Description) : IRequest<Guid>;