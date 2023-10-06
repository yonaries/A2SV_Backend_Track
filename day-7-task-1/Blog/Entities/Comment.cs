namespace Blog.Entities;

public class Comment
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public required string Text { get; set; }

    public required DateTime CreatedAt { get; set; }

    public Post Post { get; set; }
}