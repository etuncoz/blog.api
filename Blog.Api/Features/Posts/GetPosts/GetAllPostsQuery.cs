using Blog.Api.Data;
using MediatR;

namespace Blog.Api.Features.Posts.GetPosts;

public record GetAllPostsQuery() : IRequest<IEnumerable<Post>>;