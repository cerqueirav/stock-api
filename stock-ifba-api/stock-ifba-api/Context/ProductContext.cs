using Microsoft.EntityFrameworkCore;
using stock_api.Models;

namespace stock_api.Context
{
    public class ProductContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ProductContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Product> Products { get; set;}
    }
}
