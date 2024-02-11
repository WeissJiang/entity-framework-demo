namespace EFGetStarted;
public class DbInitializer
{
    public static void Initialize(BloggingContext context)
    {
        // Look for any students.
        if (context.Blogs.Any())
        {
            return;   // DB has been seeded
        }

        var blogs = new Blog[]
            {
                new Blog{Url="learn.com"},
                new Blog{Url="lift.com"}
            };

        context.Blogs.AddRange(blogs);
        context.SaveChanges();

        var posts = new Post[]
            {
                new Post{Title="ef get started",Content="",BlogId=1},
                new Post{Title="diet",Content="",BlogId=2}
            };

        context.Posts.AddRange(posts);
        context.SaveChanges();
    }
}
