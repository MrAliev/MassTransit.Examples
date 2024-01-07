using Microsoft.EntityFrameworkCore;
using Wallets.Model;

namespace Wallets.Data
{
    public class WalletsDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; }

        public WalletsDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
