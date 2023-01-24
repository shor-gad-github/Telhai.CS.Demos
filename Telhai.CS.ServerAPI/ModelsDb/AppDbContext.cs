using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Telhai.CS.ServerAPI.ModelsDb
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
             
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
            // optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels; AttachDbFilename='D:\Courses\.Net_Core_C#\01_.NetCore_Overview\ClassWork\Telhai.CS.Demos\DB\DbTesting.mdf'");
       
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        //entities
        // public DbSet<Log> Logs { get; set; }




    }
}
