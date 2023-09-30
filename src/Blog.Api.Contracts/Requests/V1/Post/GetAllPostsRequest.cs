using Blog.Api.Contracts.Requests.V1.Base;

namespace Blog.Api.Contracts.Requests.V1.Post;

public class GetAllPostsRequest : PagedRequest
{
    public required string? Title { get; init; }

    public required string? Desciption { get; init; }
    
    public required int? Year { get; init; }
    
    public required Guid? CreatedBy { get; init; }
}