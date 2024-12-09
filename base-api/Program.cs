using baseapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

// var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngularApp",
                    builder => builder
                      .WithOrigins("http://localhost:4200", "https://localhost:4200")
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                      .SetIsOriginAllowedToAllowWildcardSubdomains()
                    );
});

var DB_CONNECTION_STRING = builder.Configuration.GetConnectionString("DB_CONNECTION_STRING");

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
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

app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
  var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
  seeder.Seed();
}

app.Run();