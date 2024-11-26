using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using baseapi.Data;


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