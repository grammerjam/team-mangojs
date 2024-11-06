// using System;
// using System.Collections.Generic;
// using Newtonsoft.Json;
// using System.Net;
// using System.IO;
// using System.Text.Json.Nodes;
// using baseapi.Models;
// using BaseapiContext context = new BaseapiContext();

// using baseapi.Data;


// namespace baseapi.Classes
// {
//   public class Example
//   {
//     public IList<Selection>? Selections { get; set; }
//   }

  // public class Seed
  // {
    // void Seeding()
    // {
    //   string jsonValue = "";
    //   int counter = 0;
    //   string fileName = @"data.json";
    //   using FileStream openStream = File.OpenRead(fileName);
    //   using StreamReader reader = new StreamReader(openStream);
    //   jsonValue = reader.ReadToEnd();


    //   Example selections = JsonConvert.DeserializeObject<Example>(jsonValue);
      // foreach (var selection in selections?.Selections)
      // {
      //   Selection newSelection = new Selection()
      //   {
      //     ID = selection.ID,
      //     Title = selection.Title,
      //     Thumbnail = selection.Thumbnail,
      //     Year = selection.Year,
      //     Category = selection.Category,
      //     Rating = selection.Rating,
      //     IsBookmarked = selection.IsBookmarked,
      //     IsTrending = selection.IsTrending,
      //   };
  //       context.Add(newSelection);
  //       context.SaveChanges();
  //     }
  //   }

  //   public static void Seeding()
  //   {
  //     string jsonValue = "";
  //     int counter = 0;
  //     string fileName = @"data.json";
  //     using FileStream openStream = File.OpenRead(fileName);
  //     using StreamReader reader = new StreamReader(openStream);
  //     jsonValue = reader.ReadToEnd();


  //     Example selections = JsonConvert.DeserializeObject<Example>(jsonValue);
  //     foreach (var selection in selections?.Selections)
  //     {
  //       Selection newSelection = new Selection()
  //       {
  //         ID = selection.ID,
  //         Title = selection.Title,
  //         Thumbnail = selection.Thumbnail,
  //         Year = selection.Year,
  //         Category = selection.Category,
  //         Rating = selection.Rating,
  //         IsBookmarked = selection.IsBookmarked,
  //         IsTrending = selection.IsTrending,
  //       };
  //       context.Add(newSelection);
  //       context.SaveChanges();
  //     }
  //   }
  // }
// }