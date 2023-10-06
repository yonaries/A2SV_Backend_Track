using System;
using System.Linq;
using System.Collections.Generic;
using Blog.Entities;
using Blog.Data;

public class CommentController
{
    public BlogContext db = new BlogContext();
    public void Create(int PID, string text)
    {
        db.Posts.Where(p => p.PostId == PID).First().Comments.Add(
            new Comment
            {
                Text = text,
                CreatedAt = DateTime.Now
            }
        );
        db.SaveChanges();
    }
    public List<Comment> ReadAll(int PID)
    {
        return db.Posts.Where(p => p.PostId == PID).First().Comments.OrderBy(p => p.PostId).ToList();
    }
    public Comment Update(int id, string text)
    {
        var comment = db.Comments.Where(c => c.CommentId == id).First();
        comment.Text = text;
        db.SaveChanges();
        return comment;
    }
    public void Delete(int id)
    {
        var comment = db.Comments.Where(c => c.CommentId == id).First();
        db.Remove(comment);
        db.SaveChanges();
    }

}