namespace Blog.Api.Models.Posts;

public class PostModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}