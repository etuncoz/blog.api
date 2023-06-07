using Blog.Api.Abstractions;
using Blog.Api.Commands;
using Blog.Api.Mapping;
using Blog.Api.Models.Shared;
using Blog.Api.Repositories;

namespace Blog.Api.Handlers;

public class UpdatePostHandler : ICommandHandler<UpdatePostCommand>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.UpdatePostAsync(request.PostId, request.Post);
        
        if (post is null)
        {
            return Result.Failure(new Error(
                "Post.NotFound",
                $"The post with Id {request.PostId} was not found"));
        }

        return Result.Success();
    }
}