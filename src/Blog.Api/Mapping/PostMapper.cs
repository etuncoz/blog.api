using Blog.Api.Contracts.Responses.V1.Post;
using Blog.Domain.Posts;

namespace Blog.Api.Mapping;

public static class PostMapper
{
    public static PostResponse? MapToResponse(this Post? source)
    {
        if (source is null) return null;
        
        var destination = new PostResponse
        {
            Id = source.Id,
            CreatedAt = source.CreatedAt,
            UpdatedAt = source.UpdatedAt,
            Description = source.Description,
            Title = source.Title
        };

        return destination;
    }
}