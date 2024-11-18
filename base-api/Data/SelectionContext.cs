using System.Data.Common;
using baseapi.Models;
using Microsoft.EntityFrameworkCore;

namespace baseapi.Data
{
  public class BaseapiContext : DbContext
  {
    public BaseapiContext(DbContextOptions<BaseapiContext> options) : base(options) { }
    public DbSet<Regular> Regulars { get; set; } = null!;
    public DbSet<Trending> Trendings { get; set; } = null!;
    public DbSet<Thumbnail> Thumbnails { get; set; } = null!;
    public DbSet<Selection> Selections { get; set; } = null!;

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   modelBuilder.Entity<Selection>().Property(e => e.Id).ValueGeneratedOnAdd();
    //   modelBuilder.Entity<Regular>().Property(e => e.Id).ValueGeneratedOnAdd();
    //   modelBuilder.Entity<Trending>().Property(e => e.Id).ValueGeneratedOnAdd();
    //   modelBuilder.Entity<Thumbnail>().Property(e => e.Id).ValueGeneratedOnAdd();
    // }
  }
}

