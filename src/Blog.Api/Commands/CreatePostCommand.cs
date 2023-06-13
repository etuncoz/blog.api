using Blog.Api.Abstractions;
using Blog.Api.Data;
using Blog.Api.Models.Posts;

namespace Blog.Api.Commands;

public record CreatePostCommand(Post Post) : ICommand;