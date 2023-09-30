namespace Blog.Api.Contracts.Requests.V1.Post;

public class UpdatePostRequest
{
    public string Title { get; init; }
    public string Description { get; init; }
}