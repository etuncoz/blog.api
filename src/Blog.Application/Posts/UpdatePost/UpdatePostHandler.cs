using Blog.Application.Common.Interfaces;
using Blog.Domain.Posts;
using MediatR;

namespace Blog.Application.Posts.UpdatePost;

public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, bool>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Title = request.Title,
            Description = request.Description
        };
        
        var result = await _postRepository.UpdatePostAsync(request.Id, post);

        return result;
    }


}