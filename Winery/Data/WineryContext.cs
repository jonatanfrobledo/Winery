using Microsoft.EntityFrameworkCore;
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
    public DbSet<Sale> Sales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wine>()
            .HasKey(w => w.Id);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Cata>()
            .HasMany(c => c.Vinos)
            .WithMany(w => w.Catas);

        modelBuilder.Entity<Guest>()
            .HasKey(g => g.Id);

        modelBuilder.Entity<Guest>()
            .HasOne(g => g.Cata)
            .WithMany(c => c.Invitados)
            .HasForeignKey(g => g.CataId);
    }
}