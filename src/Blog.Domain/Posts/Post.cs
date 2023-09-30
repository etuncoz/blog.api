using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Posts;

[Table("posts")]
public class Post
{
    private readonly Guid _adminId = Guid.Parse("6aa54ded-bfe1-428c-b381-20f4497bb513");
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid CreatedBy { get; private set; }
    public Guid UpdatedBy { get; private set; }

    public Post(){}
    
    public Post(string title, string description, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Title = title;
        Description = description;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        CreatedBy = _adminId;
        UpdatedBy = _adminId;
    }
    
    public void SetTitle(string title)
    {
        Title = title;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }
}