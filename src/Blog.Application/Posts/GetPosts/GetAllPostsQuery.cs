using Blog.Domain.Posts;
using MediatR;

namespace Blog.Application.Posts.GetPosts;

public record GetAllPostsQuery() : IRequest<IEnumerable<Post>>;