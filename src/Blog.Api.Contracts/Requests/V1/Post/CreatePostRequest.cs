namespace Blog.Api.Contracts.Requests.V1.Post;

public class CreatePostRequest
{
    public required string Title { get; init; }
    public required string Description { get; init; }
}