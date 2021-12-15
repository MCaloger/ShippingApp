using Microsoft.EntityFrameworkCore;
using ShippingApp.Models;

namespace ShippingApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<UserModel> users { get; set; }
    }
}
