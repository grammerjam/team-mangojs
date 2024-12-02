using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace baseapi.Models
{
  public enum Category
  {
    movie, series
  }

  public class Selection
  {
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("year")]
    public required int Year { get; set; }

    [JsonPropertyName("category")]
    public required string Category { get; set; }

    [JsonPropertyName("rating")]
    public required string Rating { get; set; }

    [JsonPropertyName("isBookmarked")]
    public bool IsBookmarked { get; set; }

    [JsonPropertyName("isTrending")]
    public bool IsTrending { get; set; }

    [JsonPropertyName("regular")]
    public required Regular Regular { get; set; }

    [JsonPropertyName("trending")]
    public Trending? Trending { get; set; }   
  }
  public class Regular
  {
    [JsonPropertyName("small")]
    public string? Small { get; set; }

    [JsonPropertyName("medium")]
    public string? Medium { get; set; }

    [JsonPropertyName("large")]
    public string? Large { get; set; }
  }
  public class Trending
  {
    [JsonPropertyName("small")]
    public string? Small { get; set; }

    [JsonPropertyName("large")]
    public string? Large { get; set; }
  }
  public class JsonParser
  {
    public Selection ParseJson(string jsonString)
    {
      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
      return JsonSerializer.Deserialize<Selection>(jsonString, options);
    }
  }
  public class BaseapiContext : DbContext
  {
    public BaseapiContext(DbContextOptions<BaseapiContext> options) : base(options) { }
    public DbSet<Selection> Selections { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Selection>().Property(e => e.Id).ValueGeneratedOnAdd();
      modelBuilder.Entity<Selection>().OwnsOne(r => r.Regular);
      modelBuilder.Entity<Selection>().OwnsOne(r => r.Trending);
    }
  }
}
