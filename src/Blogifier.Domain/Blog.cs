namespace Blogifier.Domain;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string SubTitle { get; set; } = "";
    public string Description { get; set; } = "";

    public virtual List<BlogPost> BlogPosts { get; set; }
}
