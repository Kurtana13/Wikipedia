using Microsoft.EntityFrameworkCore;
using Wikipedia.Models;

namespace Wikipedia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Article> Article { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User>User { get; set; }
    }
}
