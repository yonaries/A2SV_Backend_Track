using Blog.Data;
using Blog.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories;

public class PostRepository
{
    private readonly BlogContext _dbContext;

    public PostRepository(BlogContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE operation (async)
    public async Task CreatePostAsync(Post post)
    {
        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();
    }

    // READ operations (async)
    public async Task<Post> GetPostByIdAsync(int postId)
    {
        return await _dbContext.Posts.FindAsync(postId);
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _dbContext.Posts.ToListAsync();
    }

    // UPDATE operation (async)
    public async Task UpdatePostAsync(Post updatedPost)
    {
        var existingPost = await _dbContext.Posts.FindAsync(updatedPost.Id);

        if (existingPost == null)
        {
            throw new InvalidOperationException("Post not found");
        }

        // Update the properties of the existing post
        existingPost.Title = updatedPost.Title;
        existingPost.Content = updatedPost.Content;

        await _dbContext.SaveChangesAsync();
    }

    // DELETE operation (async)
    public async Task DeletePostAsync(int postId)
    {
        var post = await _dbContext.Posts.FindAsync(postId);

        if (post != null)
        {
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }
    }
}
