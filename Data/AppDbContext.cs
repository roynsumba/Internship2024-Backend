using Microsoft.EntityFrameworkCore;
using AppraisalTracker.Modules.AppraisalActivity.Models;

namespace AppraisalTracker.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

      

        public DbSet<MeasurableActivity> MeasurableActivities { get; set; }
        public DbSet<Implementation> Implementations { get; set; } 

        public DbSet<ConfigMenuItem>   ConfigMenuItems { get; set; }

    }
} 


