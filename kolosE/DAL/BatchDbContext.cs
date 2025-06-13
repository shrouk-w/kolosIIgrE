﻿using kolosE.Models;
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
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Doe",
                HireDate = DateTime.Now,
            });

        modelBuilder.Entity<Nursery>().HasData(
            new Nursery
            {
                NurseryId = 1,
                Name = "aaa",
                EstablishedDate = DateTime.Now,
            });

        modelBuilder.Entity<Tree_Species>().HasData(
            new Tree_Species
            {
                SpeciesId = 1,
                LatinName = "skibidi",
                GrowthTimeInYears = 1
            });

        modelBuilder.Entity<Seedling_Batch>().HasData(
            new Seedling_Batch
            {
                BatchId = 1,
                NurseryId = 1,
                SpeciesId = 1,
                Quantity = 100,
                SownDate = DateTime.Now,
                ReadyDate = DateTime.Now
            });

        modelBuilder.Entity<Responsible>().HasData(
            new Responsible
            {
                BatchId = 1,
                EmployeeId = 1,
                Role = "worker"
            });

    }
    
}