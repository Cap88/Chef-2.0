using Microsoft.EntityFrameworkCore;

namespace ChefInternational.Data
{
    public class ChefInternationalContext : DbContext
    {
        public ChefInternationalContext (
            DbContextOptions<ChefInternationalContext> options)
            : base(options)
        {
        }

        public DbSet<ChefInternational.Models.Recipe> Recipe { get; set; }
    }
}