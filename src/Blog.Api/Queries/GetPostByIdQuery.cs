using Blog.Api.Abstractions;
using Blog.Api.Models.Posts;

namespace Blog.Api.Queries;
public record GetPostByIdQuery(int PostId) : IQuery<PostModel>;