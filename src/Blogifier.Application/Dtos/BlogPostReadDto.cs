using Blogifier.Domain;
using System.ComponentModel.DataAnnotations;

namespace Blogifier.Application.Dtos;
public class BlogPostReadDto
{
    public int Id { get; set; }
    public int BlogId { get; set; }

    [Required]
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
    public bool Featured { get; set; }
    public bool Selected { get; set; }
    public DateTime PublishedOnDate { get; set; }
    public bool IsPublished { get { return PublishedOnDate > DateTime.MinValue; } }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

    public BlogContentType ContentType { get; set; }
    public ICollection<BlogCategory> BlogCategories { get; set; }
}

