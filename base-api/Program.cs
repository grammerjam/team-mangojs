using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using baseapi.Models;
using baseapi.Data;
// using baseapi.Classes;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);
var DB_CONNECTION_STRING = builder.Configuration.GetConnectionString("DB_CONNECTION_STRING");

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseapiContext>(opt =>
    opt.UseNpgsql(DB_CONNECTION_STRING));
builder.Services.AddTransient<Seeder>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "Mango Entertainment API",
    Description = "Curating the content you love",
    Version = "v1"
  });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
   {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mango Entertainment API V1");
   });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
  var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
  seeder.Seed();
}

app.Run();


// void CreateDb()
// {
//   using var scope = app.Services.CreateScope();
//   using var db = scope.ServiceProvider.GetRequiredService<BaseapiContext>();

//   // db.Database.EnsureDeleted();
//   db.Database.EnsureCreated();

//   string jsonValue = "";
//   string fileName = @"data.json";
//   using FileStream openStream = File.OpenRead(fileName);
//   using StreamReader reader = new StreamReader(openStream);
//   jsonValue = reader.ReadToEnd();


//   var selections = JsonConvert.DeserializeObject<IList<Selection>>(jsonValue); 

//   foreach (var item in selections)
//   {
//     db.Selections.Add(new Selection
//     {
//       Title = item.Title,
//       Thumbnail = item.Thumbnail,
//       Year = item.Year,
//       Category = item.Category,
//       Rating = item.Rating,
//       IsBookmarked = item.IsBookmarked,
//       IsTrending = item.IsTrending,
//     });

//   }

//   db.SaveChanges();
// }