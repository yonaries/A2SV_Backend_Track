public class Program
{
    static void Main()
    {
        Console.write();
        var dbContext = new DbContext(); 
        var postRepository = new PostRepository(dbContext);
        var commentRepository = new CommentRepository(dbContext);
    }
}