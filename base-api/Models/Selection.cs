using System.ComponentModel.DataAnnotations;

namespace baseapi.Models;

public class Trending {
  public string? small {get; set;}
  public string? large {get; set;}

}

public class Regular {
  public string? small {get; set;}
  public string? medium {get; set;}

  public string? large {get; set;}

}

public class Selection
{
    public required string Id { get; set; }
    public required string title { get; set; }
    public required int year {get; set;}
    public required string category {get; set;}
    public required string rating {get; set;}
    public required bool isBookmarked {get; set;}
    public required bool isTrending {get; set;}
}