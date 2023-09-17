using Blog.Api.Data;
using Blog.Api.Repositories;
using MediatR;

namespace Blog.Api.Features.Posts.GetPost;

public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, Post?>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post?> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetPostByIdAsync(request.Id);

        return post;

    }
}