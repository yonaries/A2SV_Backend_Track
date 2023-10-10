public class GetBlogByIdQuery : IRequest<Blog>
{
    public int Id { get; set; }
}