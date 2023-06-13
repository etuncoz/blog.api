using Blog.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Repositories;

public class PostRepository : IPostRepository
{
    private readonly BlogContext _context;

    public PostRepository(BlogContext context)
    {
        _context = context;
    }
    
    public async Task<Post> CreatePostAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();

        return post;
    }
    
    public async Task<Post?> GetPostByIdAsync(int id)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Post[]> GetPostsAsync()
    {
        return await _context.Posts.ToArrayAsync();
    }

    public async Task<Post?> UpdatePostAsync(int id, Post post)
    {
        var existingPost = await this.GetPostByIdAsync(id);
        if (existingPost is null) return null;

        existingPost.Title = post.Title;
        existingPost.Description = post.Description;
        existingPost.UpdatedAt = post.UpdatedAt;
        existingPost.UpdatedBy = -1;
        
        _context.Posts.Update(existingPost);
        await _context.SaveChangesAsync();

        return existingPost;
    }
}