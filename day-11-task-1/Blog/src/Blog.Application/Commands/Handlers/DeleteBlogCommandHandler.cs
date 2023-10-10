public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand>
{
    private readonly IBlogRepository _blogRepository;

    public DeleteBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetBlogById(request.Id);

        if (blog == null)
        {
            throw new NotFoundException(nameof(Blog), request.Id);
        }

        await _blogRepository.DeleteBlog(request.Id);

        return Unit.Value;
    }
}