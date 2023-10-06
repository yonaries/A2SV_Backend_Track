using Blog.Entities;
using Blog.Repositories;

namespace Blog.Services;

public class CommentService
{
    private readonly CommentRepository _commentRepository;

    public CommentService(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task CreateNewCommentAsync(Comment newComment)
    {
        await _commentRepository.CreateCommentAsync(newComment);
    }

    public async Task<Comment> GetCommentByIdAsync(int commentId)
    {
        return await _commentRepository.GetCommentByIdAsync(commentId);
    }

    public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        return await _commentRepository.GetCommentsByPostIdAsync(postId);
    }

    public async Task UpdateExistingCommentAsync(Comment updatedComment)
    {
        await _commentRepository.UpdateCommentAsync(updatedComment);
    }

    public async Task DeleteCommentAsync(int commentId)
    {
        await _commentRepository.DeleteCommentAsync(commentId);
    }
}
