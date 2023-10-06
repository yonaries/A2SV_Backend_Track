class Blog
{
    static void Main()
    {
        var p = new PostController();
        var c = new CommentController();
        p.Create("First blog", "Here is my first blog");
        p.ReadAll().ForEach(pp =>
        {
            Console.WriteLine(pp.Title);
            Console.WriteLine(pp.Content);
            c.Create(pp.PostId, "Here is my first comment");
        });

        Console.WriteLine("Hello, World! This is my blog!");
    }
}