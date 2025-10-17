
using Microsoft.EntityFrameworkCore;

namespace Week3.Database
{
    /**
     * Database context
     */
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}

