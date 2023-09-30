using Blog.Domain.Posts;
using MediatR;

namespace Blog.Application.Posts.GetPost;

public record GetPostByIdQuery(Guid Id) : IRequest<Post?>;