using Blog.Application.Common.Interfaces;
using Blog.Domain.Posts;
using Blog.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Posts.Persistence;

public class PostRepository : IPostRepository
{
    private readonly BlogContext _context;

    public PostRepository(BlogContext context)
    {
        _context = context;
    }
    
    public async Task AddPostAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Post?> GetPostByIdAsync(Guid id)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Post[]> GetPostsAsync()
    {
        return await _context.Posts.ToArrayAsync();
    }

    public async Task<bool> UpdatePostAsync(Post post)
    {
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();

        return true;
    }
}