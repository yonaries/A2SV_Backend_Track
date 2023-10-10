public class UpdateBlogCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}