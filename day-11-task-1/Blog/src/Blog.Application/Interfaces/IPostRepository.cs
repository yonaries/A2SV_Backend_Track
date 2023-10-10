
namespace Blog.Application.Interfaces
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();
        Post GetPostById(int id);
        void CreatePost(Post Post);
        void UpdatePost(Post Post);
        void DeletePost(int id);
    }
}

