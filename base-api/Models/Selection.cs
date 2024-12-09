using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public int ThumbnailId { get; set; }

    [JsonPropertyName("thumbnail")]
    public required Thumbnail Thumbnail { get; set; }
  }

  public class Thumbnail
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public int Id { get; set; }

    public int RegularId { get; set; }

    [JsonPropertyName("regular")]
    public required Regular Regular { get; set; }

    public int? TrendingId { get; set; }

    [JsonPropertyName("trending")]
    public Trending? Trending { get; set; }
  }

  public class Regular
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [JsonPropertyName("small")]
    public required string Small { get; set; }

    [JsonPropertyName("medium")]
    public required string Medium { get; set; }

    [JsonPropertyName("large")]
    public required string Large { get; set; }
  }
  public class Trending
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

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
    }
  }
}
