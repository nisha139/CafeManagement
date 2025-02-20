using CafeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Persistence;
public class CafeDbContext : DbContext
{
    public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options) { }

    public DbSet<CafeMenu> CafeMenus { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CafeMenu>()
            .Property(c => c.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2);
        modelBuilder.Entity<CafeMenu>()
        .Property(c => c.Id)
        .HasDefaultValueSql("NEWID()");
    }
}


