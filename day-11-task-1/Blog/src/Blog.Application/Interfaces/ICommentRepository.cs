namespace Blog.Application.Interfaces
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsByBlogId(int blogId);
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int id);
    }
}