using Blog.Domain.Comments;

namespace Blog.Application.Common.Interfaces;

public interface ICommentRepository
{
    Task AddCommentAsync(Comment comment);
    Task<Comment[]> GetCommentsByPostIdAsync(Guid postId);
    Task UpdateCommentAsync(Comment comment);
}