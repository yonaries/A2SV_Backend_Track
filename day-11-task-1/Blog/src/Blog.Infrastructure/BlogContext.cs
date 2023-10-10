// using System;
using Blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogContext: DbContext
{
	public DbSet<Post> Posts { get; set; }
	public DbSet<Comment> Comments { get; set; }

	public BlogContext(DbContextOptions<BlogContext> options): base (options)
	{

	} 

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity relationships, constraints, etc., if needed
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId);
        
        // Add more configurations as needed
    }
}
