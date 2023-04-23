using Microsoft.EntityFrameworkCore;
using stock_api.Models;

namespace stock_api.Context
{
    public class OrderContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public OrderContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Order> Orders { get; set;}
    }
}
