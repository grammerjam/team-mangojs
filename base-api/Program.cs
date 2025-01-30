using System.Configuration;
using System.Text;
using baseapi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using baseapi.Helpers;
using baseapi.Services;

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
builder.Services.AddSwaggerGen(swagger =>
{
  swagger.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "Mango Entertainment API",
    Description = "Curating the content you love",
    Version = "v1"
  });
  swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
  {
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
  });
  swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
      {
        new OpenApiSecurityScheme
        {
          Reference = new OpenApiReference
          {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
          }
        },
        new string[] {}
      }
    });
});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IUserService, UserService>();

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

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
  var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
  seeder.Seed();
}

app.Run();