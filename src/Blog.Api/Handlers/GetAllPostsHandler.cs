using Blog.Api.Abstractions;
using Blog.Api.Mapping;
using Blog.Api.Models.Posts;
using Blog.Api.Models.Shared;
using Blog.Api.Queries;
using Blog.Api.Repositories;

namespace Blog.Api.Handlers;

public class GetAllPostsHandler : IQueryHandler<GetAllPostsQuery, PostModel[]>
{
    private readonly IPostRepository _postRepository;

    public GetAllPostsHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result<PostModel[]>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetPostsAsync();

        var postModels = posts.Select(p => p.ToModel()).ToArray();

        return postModels;
    }
}