using Microsoft.EntityFrameworkCore;

namespace baseapi.Models;

public class SelectionContext : DbContext
{
    public SelectionContext(DbContextOptions<SelectionContext> options)
        : base(options)
    {
    }

    public DbSet<Selection> Selections { get; set; } = null!;
}