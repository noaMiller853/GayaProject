
using Microsoft.EntityFrameworkCore;

namespace WebApplicationUser.Models
{ 
public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Operator> Operation { get; set; }
        public DbSet<Arguments> Arguments { get; set; }
    }

}

