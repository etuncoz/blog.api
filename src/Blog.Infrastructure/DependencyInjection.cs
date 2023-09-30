using Blog.Application.Common.Interfaces;
using Blog.Infrastructure.Common.Persistence;
using Blog.Infrastructure.Posts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<BlogContext>();

        services.AddScoped<IPostRepository, PostRepository>();
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }

    public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<BlogContext>();
        Console.WriteLine("Migrating db...");
        await dbContext.Database.MigrateAsync();
    }
}