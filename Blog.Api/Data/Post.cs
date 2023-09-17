using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Api.Data;

[Table("posts")]
public class Post
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("created_by")]
    public Guid CreatedBy { get; set; }
    
    [Column("updated_by")]
    public Guid UpdatedBy { get; set; }
}