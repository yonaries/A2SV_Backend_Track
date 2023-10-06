using Blog.Infrastructure;
using Blog.Domain;

namespace Blog.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private BlogContext _dbContext;

        public CommentRepository(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }
        public List<Comment> GetCommentsByBlogId(int PID)
        {
            return _dbContext.Comments..Where(p => p.Id == PID).ToList();
        }
        public void UpdatePost(Comment comment)
        {
            comment.Text = T;
            _dbContext.SaveChanges();
        }
        public void Delete(int I)
        {
            var comment = _dbContext.Comments.Where(c => c.Id == I).First();
            _dbContext.Remove(comment);
            _dbContext.SaveChanges();
        }
    }
}
