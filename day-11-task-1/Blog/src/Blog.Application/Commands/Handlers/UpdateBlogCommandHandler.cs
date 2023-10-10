public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
{
    private readonly IBlogRepository _blogRepository;

    public UpdateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Unit> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetBlogById(request.Id);

        if (blog == null)
        {
            throw new NotFoundException(nameof(Blog), request.Id);
        }

        blog.Title = request.Title;
        blog.Content = request.Content;

        await _blogRepository.UpdateBlog(blog);

        return Unit.Value;
    }
}