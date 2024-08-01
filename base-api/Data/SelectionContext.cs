using baseapi.Models;
using Microsoft.EntityFrameworkCore;

namespace baseapi.Data
{
  public class SelectionContext : DbContext
  {
    public SelectionContext(DbContextOptions<SelectionContext> options)
        : base(options)
    {
    }

    public DbSet<Selection> Selections { get; set; } = null!;
    public DbSet<Regular> Regulars { get; set; } = null!;
    public DbSet<Trending> Trendings { get; set; } = null!;
  }
}
