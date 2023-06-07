using Blog.Api.Abstractions;
using Blog.Api.Mapping;
using Blog.Api.Models.Posts;
using Blog.Api.Models.Shared;
using Blog.Api.Queries;
using Blog.Api.Repositories;

namespace Blog.Api.Handlers;

public class GetPostByIdHandler : IQueryHandler<GetPostByIdQuery, PostModel>
{
    private readonly ILogger<GetPostByIdHandler> _logger;
    private readonly IPostRepository _postRepository;

    public GetPostByIdHandler(IPostRepository postRepository, ILogger<GetPostByIdHandler> logger)
    {
        _logger = logger;
        _postRepository = postRepository;
    }
    public async Task<Result<PostModel>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetPostByIdAsync(request.PostId);
        if (post is null)
        {
            return Result.Failure<PostModel>(new Error(
                "Post.NotFound",
                $"The post with Id {request.PostId} was not found"));
        }
        return post.ToModel();
    }
}