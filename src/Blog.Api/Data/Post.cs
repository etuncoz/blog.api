namespace Blog.Api.Data;

public class Post
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
}