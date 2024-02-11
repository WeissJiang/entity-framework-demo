using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.Domains.Users
{
    public class User : CreationDateRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdminLevel { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string Email { get; set; }
    }

    public static class UserAdminLevel
    {
        public const int
            Standard = 0,
            Manager = 1,
            SuperAdmin = 2;
    }

    //public static class UserExtensions
    //{
    //    public static IQueryable<User> GetUsers(this IQueryable<User> users)
    //    {
    //        return users
    //            .Include(u => u.UserTenants)
    //            .ThenInclude(u => u.UserGroups)
    //            .Include(u => u.UserTenants)
    //            .ThenInclude(u => u.Roles)
    //            .Include(u => u.UserTenants)
    //            .ThenInclude(u => u.Tenant);
    //    }
    //}
}
