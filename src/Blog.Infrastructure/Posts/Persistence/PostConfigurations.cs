using Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Posts.Persistence;

public class PostConfigurations : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at");
        
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at");
        
        builder.Property(p => p.Title)
            .HasColumnName("title");
        
        builder.Property(p => p.Description)
            .HasColumnName("description");
        
        builder.Property(p => p.CreatedBy)
            .ValueGeneratedNever()
            .HasColumnName("created_by");
        
        builder.Property(p => p.UpdatedBy)
            .ValueGeneratedNever()
            .HasColumnName("updated_by");
        

        
    }
}