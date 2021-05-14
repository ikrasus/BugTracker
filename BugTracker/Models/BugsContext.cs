using Microsoft.EntityFrameworkCore;

namespace BugTracker.Models
{
    public class BugsContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        //public DbSet<Status> Statuses {get; set;}
        public BugsContext(DbContextOptions<BugsContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}