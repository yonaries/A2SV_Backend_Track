using Blog.Entities;
using Blog.Repositories;

namespace Blog.Services;

public class PostService
{
    private readonly PostRepository _postRepository;

    public PostService(PostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _postRepository.GetAllPostsAsync();
    }

    public async Task<Post> GetPostByIdAsync(int postId)
    {
        return await _postRepository.GetPostByIdAsync(postId);
    }

    public async Task CreateNewPostAsync(Post newPost)
    {
        await _postRepository.CreatePostAsync(newPost);
    }

    public async Task UpdateExistingPostAsync(Post updatedPost)
    {
        await _postRepository.UpdatePostAsync(updatedPost);
    }

    public async Task DeletePostAsync(int postId)
    {
        await _postRepository.DeletePostAsync(postId);
    }
}

