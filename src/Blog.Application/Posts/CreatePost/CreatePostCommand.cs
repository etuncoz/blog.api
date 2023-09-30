using MediatR;

namespace Blog.Application.Posts.CreatePost;

public record CreatePostCommand(string Title, string Description) : IRequest<Guid>;