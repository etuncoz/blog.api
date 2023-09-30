using Blog.Domain.Common;

namespace Blog.Domain.Comments;


public class Comment : BaseEntity
{
    public Guid PostId { get; private set; }
    public string Text { get; private set; } = null!;
    
    public Comment()
    {
    }

    private Comment(
        Guid postId,
        string text,
        Guid? id = null
    )
        : base(id)
    {
        PostId = postId;
        Text = text;
    }

    public static Comment Create(Guid postId, string text)
    {
        return new Comment(postId, text);
    }

    public void SetText(string text)
    {
        Text = text;
    }
}