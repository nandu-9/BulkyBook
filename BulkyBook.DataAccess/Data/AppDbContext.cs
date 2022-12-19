using Microsoft.EntityFrameworkCore;
using BulkyBook.Models;

namespace BulkyBookWeb.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // The variable name of DbSet field will be the created table name.
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
    }
}
