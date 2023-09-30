using Blog.Application.Common.Validation;
using Blog.Domain.Posts;
using MediatR;
using OneOf;

namespace Blog.Application.Posts.CreatePost;

public record CreatePostCommand(string Title, string Description) : IRequest<OneOf<Post, ValidationFailed>>;