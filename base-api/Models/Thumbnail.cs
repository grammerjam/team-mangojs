namespace baseapi.Models
{

  public class Thumbnail
  {
    public int Id { get; set; }

    public int RegularId { get; set; }
    public int? TrendingId { get; set; }
    
    public Trending? Trending { get; set; }
    public required Regular Regular { get; set; }
  }
}