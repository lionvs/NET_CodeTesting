using System.Data.Entity;
using Cashbox.DataAccess.Models;

namespace Cashbox.DataAccess
{
    internal class CashboxDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
