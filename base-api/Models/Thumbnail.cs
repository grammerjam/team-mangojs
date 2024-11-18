namespace baseapi.Models
{

  public class Thumbnail
  {
    public string Id { get; set; }

    public string RegularId { get; set; }
    public string? TrendingId { get; set; }
    
    public Trending? Trending { get; set; }
    public required Regular Regular { get; set; }
  }
}