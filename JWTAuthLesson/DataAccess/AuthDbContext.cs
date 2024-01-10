using JWTAuthLesson.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthLesson.DataAccess
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options):
            base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
