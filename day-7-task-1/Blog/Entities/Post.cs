namespace Blog.Entities;

public class Post
{
    public int PostId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }

    public required DateTime CreatedAt { get; set; }

    public ICollection<Comment> Comments { get; }

}