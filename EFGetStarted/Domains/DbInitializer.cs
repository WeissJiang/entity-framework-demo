using EFGetStarted.Domains.Users;

namespace EFGetStarted.Domains;
public class DbInitializer
{
    public static void Initialize(BloggingContext context)
    {
        // Look for any students.
        if (context.Users.Any())
        {
            return;   // DB has been seeded
        }

        var users = new User[]
            {
                new User
                {
                    Name = "Super Admin",
                    Email = "meweissjiang@gmail.com",
                    AdminLevel = UserAdminLevel.SuperAdmin
                },
                new User
                {
                    Name = "Weiss",
                    Email = "xoloveweiss@gmail.com",
                    AdminLevel = UserAdminLevel.Standard
                }
            };

        context.Users.AddRange(users);
        context.SaveChanges();
    }
}
