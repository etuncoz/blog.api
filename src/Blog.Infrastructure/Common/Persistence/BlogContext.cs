using Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Infrastructure.Common.Persistence;

public class BlogContext : DbContext
{
    private readonly IConfiguration _configuration;

    public BlogContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("BlogApi"));
    }

    public DbSet<Post> Posts { get; set; } = null!;
}