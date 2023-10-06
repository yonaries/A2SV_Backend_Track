using Blog.Infrastructure;
using Blog.Domain;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private DbContext _dbContext;

        public PostRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreatePost(Post post)
        {
            _dbContext.Add(post);
            _dbContext.SaveChanges();
        }
        public List<Post> GetAllPosts()
        {
            return _dbContext.Posts.OrderBy(p => p.PostId).ToList();
        }
        public void UpdatePost(Post post)
        {
            post.Title = T;
            post.Content = C;
            _dbContext.SaveChanges();
        }
        public void DeletePost(int I)
        {
            var post = _dbContext.Posts.Where(p => p.PostId == I).First();
            _dbContext.Remove(post);
            _dbContext.SaveChanges();
        }
    }
}

