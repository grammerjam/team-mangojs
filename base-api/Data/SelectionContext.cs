using baseapi.Models;
using Microsoft.EntityFrameworkCore;

namespace baseapi.Data
{
  public class SelectionContext : DbContext
  {
    public SelectionContext(DbContextOptions<SelectionContext> options) : base(options) { }
    public DbSet<Regular> Regulars { get; set; } = null!;
    public DbSet<Trending> Trendings { get; set; } = null!;
    public DbSet<Thumbnail> Thumbnails { get; set; } = null!;
    public DbSet<Selection> Selections { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Selection>().Property(e => e.ID).ValueGeneratedOnAdd();
      modelBuilder.Entity<Regular>().Property(e => e.ID).ValueGeneratedOnAdd();
      modelBuilder.Entity<Trending>().Property(e => e.ID).ValueGeneratedOnAdd();
      modelBuilder.Entity<Thumbnail>().Property(e => e.ID).ValueGeneratedOnAdd();
    }
  }
}
