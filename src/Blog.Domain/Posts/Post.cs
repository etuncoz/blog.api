using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Common;

namespace Blog.Domain.Posts;

public class Post : BaseEntity
{
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;


    public Post()
    {
    }

    private Post(
        string title,
        string description,
        Guid? id = null
    )
        : base(id)
    {
        Title = title;
        Description = description;
    }

    public static Post Create(string title, string description)
    {
        return new Post(title, description);
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