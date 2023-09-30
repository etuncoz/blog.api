using Blog.Application.Common.Interfaces;
using Blog.Domain.Posts;
using MediatR;
using OneOf;
using OneOf.Types;

namespace Blog.Application.Posts.UpdatePost;

public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, OneOf<Post, NotFound>>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<OneOf<Post, NotFound>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetPostByIdAsync(request.Id);

        if (existingPost is null)
        {
            return new NotFound();
        }

        existingPost.SetTitle(request.Title);
        existingPost.SetDescription(request.Description);

        await _postRepository.UpdatePostAsync(existingPost);

        return existingPost;
    }
}