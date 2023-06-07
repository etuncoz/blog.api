using Blog.Api.Data;

namespace Blog.Api.Repositories;

public interface IPostRepository
{
    Task<Post> CreatePostAsync(Post post);
    Task<Post?> GetPostByIdAsync(int id);
    Task<Post[]> GetPostsAsync();
    Task<Post?> UpdatePostAsync(int id, Post post);
}