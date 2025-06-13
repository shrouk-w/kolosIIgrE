using kolosE.Models;
using Microsoft.EntityFrameworkCore;

namespace kolosE.DAL;

public class BatchDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<Tree_Species> TreeSpecies { get; set; }
    public DbSet<Seedling_Batch> SeedlingBatches { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    
    protected BatchDbContext()
    {
    }

    public BatchDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Responsible>()
            .HasKey(p => new { p.EmployeeId, p.BatchId });
    }
    
}