using System;
using System.Linq;
using System.Collections.Generic;
using Blog.Entities;
using Blog.Data;

namespace Blog.Controllers;

public class PostController
{
    public BlogContext db = new BlogContext();
    public void Create(string title, string content)
    {
        db.Add(
            new Post
            {
                Title = title,
                Content = content,
                CreatedAt = DateTime.Now
            }
        );
        db.SaveChanges();
    }
    public List<Post> ReadAll()
    {
        return db.Posts.OrderBy(p => p.PostId).ToList();
    }
    public Post Update(int id, string title, string content)
    {
        var post = db.Posts.Where(p => p.PostId == I).First();
        post.Title = title;
        post.Content = content;
        db.SaveChanges();
        return post;
    }
    public void Delete(int id)
    {
        var post = db.Posts.Where(p => p.PostId == id).First();
        db.Remove(post);
        db.SaveChanges();
    }

}