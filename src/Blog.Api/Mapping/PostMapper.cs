using System.Runtime.CompilerServices;
using Blog.Api.Data;
using Blog.Api.Helpers;
using Blog.Api.Models.Posts;

namespace Blog.Api.Mapping;

public static class PostMapper
{
    private static IDateTimeProvider? _dateTimeProvider;
    
    public static void Configure(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
    }
    
    public static PostModel ToModel(this Post source)
    {
        var destination = new PostModel
        {
            Id = source.Id,
            CreatedAt = source.CreatedAt,
            UpdatedAt = source.UpdatedAt,
            Description = source.Description,
            Title = source.Title
        };

        return destination;
    }
    
    public static Post ToDomain(this PostModel source)
    {
        var destination = new Post
        {
            Id = source.Id,
            CreatedAt = source.CreatedAt,
            UpdatedAt = source.UpdatedAt,
            Description = source.Description,
            Title = source.Title
        };

        return destination;
    }
    
    public static Post ToDomain(this UpdatePostRequest source)
    {
        var destination = new Post
        {
            UpdatedAt = _dateTimeProvider!.DateTimeNow(),
            Description = source.Description,
            Title = source.Title,
            UpdatedBy = -1
        };
        return destination;
    }
    
    public static Post ToDomain(this CreatePostRequest source)
    {
        var destination = new Post
        {
            CreatedAt = _dateTimeProvider!.DateTimeNow(),
            UpdatedAt = _dateTimeProvider!.DateTimeNow(),
            Description = source.Description,
            Title = source.Title,
            CreatedBy = -1,
            UpdatedBy = -1
        };
        return destination;
    }
}