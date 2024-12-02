using baseapi.Models;
using Newtonsoft.Json;

public class Seeder
{
  private readonly BaseapiContext _context;
  public Seeder(BaseapiContext context)
  {
    _context = context;
  }
  public void Seed()
  {
    SeedSelections();
  }
  public void SeedSelections()
  {

    // db.Database.EnsureDeleted();
    _context.Database.EnsureCreated();
    if (!_context.Selections.Any())
    {
      string jsonValue;
      string fileName = @"data.json";
      using FileStream openStream = File.OpenRead(fileName);
      using StreamReader reader = new StreamReader(openStream);
      jsonValue = reader.ReadToEnd();


      var selections = JsonConvert.DeserializeObject<IList<Selection>>(jsonValue);
      Console.WriteLine("*************");
      Console.WriteLine(selections.Count());
      Console.WriteLine("*************");
      // foreach (var item in selections)
      // {
      //   db.Selections.Add(new Selection
      //   {
      //     Id = item.Id,
      //     Title = item.Title,
      //     Thumbnail = item.Thumbnail,
      //     Year = item.Year,
      //     Category = item.Category,
      //     Rating = item.Rating,
      //     IsBookmarked = item.IsBookmarked,
      //     IsTrending = item.IsTrending,
      //   });

      // }

      _context.Selections.AddRange(selections);
      _context.SaveChanges();
    }
  }
}