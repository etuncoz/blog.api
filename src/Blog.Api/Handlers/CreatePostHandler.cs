using Blog.Api.Abstractions;
using Blog.Api.Commands;
using Blog.Api.Mapping;
using Blog.Api.Models.Posts;
using Blog.Api.Models.Shared;
using Blog.Api.Repositories;
using MediatR;

namespace Blog.Api.Handlers;

public class CreatePostHandler : ICommandHandler<CreatePostCommand>
{
    private readonly ILogger<CreatePostHandler> _logger;
    private readonly IPostRepository _postRepository;

    public CreatePostHandler(IPostRepository postRepository, ILogger<CreatePostHandler> logger)
    {
        _logger = logger;
        _postRepository = postRepository;
    }
    public async Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        await _postRepository.CreatePostAsync(request.Post);
        
        return Result.Success();
    }
}