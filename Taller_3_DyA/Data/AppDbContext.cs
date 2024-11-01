using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Taller_3_DyA.Data;

public class AppDbContext: DbContext
{
    public DbSet<ProductV1> ProductV1 { get; set; }
    public DbSet<ProductV2> ProductV2 { get; set; }
    public DbSet<ProductV3> ProductV3 { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}