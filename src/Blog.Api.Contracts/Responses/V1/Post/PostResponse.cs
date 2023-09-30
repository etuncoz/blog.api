namespace Blog.Api.Contracts.Responses.V1.Post;

public class PostResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}