public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, List<Blog>>
{
    private readonly IBlogRepository _blogRepository;

    public GetAllBlogsQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<List<Blog>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {
        return await _blogRepository.GetAllBlogs();
    }
}
