using InterviewTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewTask
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Add DbSet properties here
        public DbSet<Region> Regions { get; set; }
        public DbSet<Wiliyat> Wiliyats { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<EntityType> EntityType { get; set; }
        public DbSet<Item> Item { get; set; }
    }

   
}
