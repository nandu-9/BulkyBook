using Microsoft.EntityFrameworkCore;
using BulkyBookWeb.Models;
namespace BulkyBookWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // The variable name of DbSet field will be the created table name.
        DbSet<Category> Categories { get; set; }

    }
}
