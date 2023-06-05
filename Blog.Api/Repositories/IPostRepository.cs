using Blog.Api.Data;

namespace Blog.Api.Repositories;

public interface IPostRepository
{
    Task AddPostAsync(Post post);
    Task<Post?> GetPostByIdAsync(int id);
    Task<Post[]> GetPostsAsync();
    Task UpdatePostAsync(int id, Post post);
}