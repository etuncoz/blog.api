using System.Reflection;
using Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Infrastructure.Common.Persistence;

public class BlogContext : DbContext
{
    public DbSet<Post> Posts { get; set; } = null!;
    public BlogContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}