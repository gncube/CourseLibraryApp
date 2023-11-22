using System.ComponentModel.DataAnnotations;

namespace Blogifier.Domain;
public class BlogPost
{
    public int Id { get; set; }
    public int BlogId { get; set; }

    [Required]
    [StringLength(160)]
    public string Title { get; set; } = "";

    [Required]
    [StringLength(160)]
    public string Slug { get; set; } = "";

    [Required]
    [StringLength(450)]
    public string Description { get; set; } = "";
    [Required]
    public string Content { get; set; } = "";
    public int PostViews { get; set; }
    public double Rating { get; set; }
    public bool IsFeatured { get; set; }
    public bool Selected { get; set; }
    public DateTime PublishedOnDate { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

    public BlogContentType ContentType { get; set; }
    public ICollection<BlogCategory> BlogCategories { get; set; }
}

