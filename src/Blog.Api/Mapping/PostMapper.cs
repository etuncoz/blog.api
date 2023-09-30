using Blog.Api.Contracts.Responses.V1.Post;
using Blog.Api.Helpers;
using Blog.Domain.Posts;

namespace Blog.Api.Mapping;

public static class PostMapper
{
    private static IDateTimeProvider? _dateTimeProvider;
    
    public static void Configure(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
    }
    
    public static PostResponse? MapToModel(this Post? source)
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