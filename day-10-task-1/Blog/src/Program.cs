public class Program
{
    static void Main()
    {
        Console.write();
        var dbContext = new DbContext(); 
        var blogRepository = new BlogRepository(dbContext);
        var commentRepository = new CommentRepository(dbContext);
    }
}