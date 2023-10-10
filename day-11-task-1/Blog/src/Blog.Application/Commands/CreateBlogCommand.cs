public class CreateBlogCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Content { get; set; }
}