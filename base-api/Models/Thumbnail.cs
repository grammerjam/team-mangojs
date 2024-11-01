namespace baseapi.Models
{

  public class Thumbnail
  {
    public int ID { get; set; }

    public int RegularID { get; set; }
    public int? TrendingID { get; set; }
    
    public Trending? Trending { get; set; }
    public required Regular Regular { get; set; }
  }
}