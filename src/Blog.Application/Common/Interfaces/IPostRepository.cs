using Blog.Domain.Posts;

namespace Blog.Application.Common.Interfaces;

public interface IPostRepository
{
    Task AddPostAsync(Post post);
    Task<Post?> GetPostByIdAsync(Guid id);
    Task<Post[]> GetPostsAsync();
    Task UpdatePostAsync(Post post);
}