using Microsoft.EntityFrameworkCore;
using baseapi.Models;
using baseapi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<SelectionContext>(opt =>
    opt.UseNpgsql(@"Host=postgres;Username=postgres;Password=postgres;Database=mango"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
