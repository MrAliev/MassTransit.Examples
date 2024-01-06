using Microsoft.EntityFrameworkCore;
using Users.Model;

namespace Users.Repository
{
    public class UsersDbContext : DbContext
    {
        public DbSet<CompositeUserModel> CompositeUsers { get; set; }

        public UsersDbContext(DbContextOptions options) : base(options)
        {

        }
    }

     
}
