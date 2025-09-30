using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace shop.DATA
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
    }
}
