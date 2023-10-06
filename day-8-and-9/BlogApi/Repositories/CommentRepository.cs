using Blog.Data;
using Blog.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories;

public class CommentRepository
{
    private readonly BlogContext _dbContext;

    public CommentRepository(BlogContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE operation (async)
    public async Task CreateCommentAsync(Comment comment)
    {
        _dbContext.Comments.Add(comment);
        await _dbContext.SaveChangesAsync();
    }

    // READ operations (async)
    public async Task<Comment> GetCommentByIdAsync(int commentId)
    {
        return await _dbContext.Comments.FindAsync(commentId);
    }

    public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        return await _dbContext.Comments.Where(c => c.PostId == postId).ToListAsync();
    }

    // UPDATE operation (async)
    public async Task UpdateCommentAsync(Comment updatedComment)
    {
        var existingComment = await _dbContext.Comments.FindAsync(updatedComment.Id);

        if (existingComment == null)
        {
            throw new InvalidOperationException("Comment not found");
        }

        // Update the properties of the existing comment
        existingComment.Text = updatedComment.Text;

        await _dbContext.SaveChangesAsync();
    }

    // DELETE operation (async)
    public async Task DeleteCommentAsync(int commentId)
    {
        var comment = await _dbContext.Comments.FindAsync(commentId);

        if (comment != null)
        {
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
