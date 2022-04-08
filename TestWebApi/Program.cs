using Microsoft.EntityFrameworkCore;
using TestWebApi.DataManagement.DbManagement;
using TestWebApi.Models;

// TODO Edt créer une API Web en projet mvc pour avoir startup.cs et tout le bordel

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GenericDbContext>(opt => opt.UseInMemoryDatabase("GenericDb"));
builder.Services.AddDbContext<ComputersDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ComputersDbStr")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
