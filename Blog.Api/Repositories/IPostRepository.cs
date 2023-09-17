using Blog.Api.Data;

namespace Blog.Api.Repositories;

public interface IPostRepository
{
    Task AddPostAsync(Post post);
    Task<Post?> GetPostByIdAsync(Guid id);
    Task<Post[]> GetPostsAsync();
    Task<bool> UpdatePostAsync(Guid id, Post post);
}