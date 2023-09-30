using Blog.Application.Common.Interfaces;
using Blog.Domain.Posts;
using MediatR;

namespace Blog.Application.Posts.GetPosts;

public class GetAllPostsHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<Post>>
{
    private readonly IPostRepository _postRepository;

    public GetAllPostsHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        return await _postRepository.GetPostsAsync();
    }
}