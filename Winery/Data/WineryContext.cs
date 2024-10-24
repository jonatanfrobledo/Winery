﻿using Microsoft.EntityFrameworkCore;
using Winery.Entities;

public class WineryContext : DbContext
{
    public WineryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Wine> Wines { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cata> Catas { get; set; }
    public DbSet<Guest> Guests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wine>()
            .HasKey(w => w.Id);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Cata>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Guest>()
            .HasKey(g => g.Id);

        // Configuración adicional de relaciones
        modelBuilder.Entity<Guest>()
            .HasOne(g => g.Cata)
            .WithMany(c => c.Guests)
            .HasForeignKey(g => g.CataId);
    }
}