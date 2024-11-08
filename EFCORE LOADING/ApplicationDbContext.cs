using EFCORE_LOADING.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_LOADING;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    
    public DbSet<Villa> Villas { get; set; }
    public DbSet<VillaAmeneties> VillaAmeneties { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Villa>().HasData(new Villa { ID = 1, Name = "lAKE VIEW", Price = 9999 });

        modelBuilder.Entity<VillaAmeneties>().HasData(new VillaAmeneties { Id = 2, VillaId = 1, Name = "jACCUZZI" });
        
    }
}
