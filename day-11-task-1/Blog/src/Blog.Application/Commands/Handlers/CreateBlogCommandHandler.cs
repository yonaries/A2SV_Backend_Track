public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;

    public CreateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = new Blog
        {
            Title = request.Title,
            Content = request.Content
        };

        await _blogRepository.CreateBlog(blog);

        return blog.Id;
    }
}