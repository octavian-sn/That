using Microsoft.EntityFrameworkCore;
using ThatWeb.Models;

namespace ThatWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }
    }
}
