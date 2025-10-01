using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using shop.DATA.Entities;

namespace shop.DATA
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
