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
    public int ID { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public Category Category { get; set; }
    public string Rating { get; set; }
    public bool isBookmarked { get; set; }
    public bool isTrending { get; set; }

    public int RegularID { get; set; }
    public int? TrendingID { get; set; }

    public Regular Regular { get; set; }
    public Trending? Trending { get; set; }
  }
}
