using Blog.Api.Data;
using MediatR;

namespace Blog.Api.Features.Posts.GetPost;

public record GetPostByIdQuery(Guid Id) : IRequest<Post?>;