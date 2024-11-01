using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Taller_3_DyA.Data;

public class AppDbContext : DbContext
{
    public DbSet<ProductV1> ProductV1 { get; set; }
    public DbSet<ProductV2> ProductV2 { get; set; }
    public DbSet<ProductV3> ProductV3 { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductV1>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
        
        modelBuilder.Entity<ProductV2>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ProductV3>()
            .Property(p => p.Discount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ProductV3>()
            .Property(p => p.FinalPrice)
            .HasColumnType("decimal(18,2)");
    }
}