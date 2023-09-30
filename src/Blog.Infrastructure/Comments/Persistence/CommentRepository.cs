using Blog.Application.Common.Interfaces;
using Blog.Domain.Comments;
using Blog.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Comments.Persistence;

public class CommentRepository : ICommentRepository
{    
    private readonly BlogContext _context;

    public CommentRepository(BlogContext context)
    {
        _context = context;
    }
    
    public async Task AddCommentAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
    }

    public async Task<Comment[]> GetCommentsByPostIdAsync(Guid postId)
    {
        return await _context.Comments.Where(c => c.PostId == postId).ToArrayAsync();
    }

    public Task UpdateCommentAsync(Comment comment)
    {
        _context.Comments.Update(comment);
        return Task.CompletedTask;
    }
}