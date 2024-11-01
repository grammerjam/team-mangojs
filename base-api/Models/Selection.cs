using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace baseapi.Models
{
  public enum Category
  {
    movie, series
  }

  public class Selection
  {
    public required int ID { get; set; }
    public required string Title { get; set; }
    public required int Year { get; set; }
    public required string Category { get; set; }
    public required string Rating { get; set; }
    public bool IsBookmarked { get; set; }
    public bool IsTrending { get; set; }
    
    public int ThumbnailID { get; set; }

    public required Thumbnail Thumbnail { get; set; }
  }
}
