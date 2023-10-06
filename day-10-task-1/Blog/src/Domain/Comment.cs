// Blog.Domain/Comment.cs
namespace Blog.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Text { get; set; }
    }
}