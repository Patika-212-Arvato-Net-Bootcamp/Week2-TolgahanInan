using Microsoft.EntityFrameworkCore;
using Week2_Tolgahaninan.Models;

namespace Week2_Tolgahaninan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<User> users { get; set; }
        public DbSet<Bootcamp> bootcamps { get; set; }
        public DbSet<RegisteredBootcampsByUsers> registeredBootcampsByUsers { get; set; }
    }
}
