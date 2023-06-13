using Blog.Api.Abstractions;
using Blog.Api.Data;

namespace Blog.Api.Commands;

public record UpdatePostCommand(int PostId, Post Post) : ICommand;