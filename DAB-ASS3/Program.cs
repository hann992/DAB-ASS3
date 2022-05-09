using DAB_ASS3;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Municipality Room/Location Management",
        Description = "Fetch Societies, Bookings, Rooms/Locations and Booking Access.\n\n <b>OBS! Til Booking Access, så kør program og se øverst i konsol, der står alle CPR numre som kan søges på!</b>",
        Version = "v1"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint(
        "/swagger/v1/swagger.json", "DefaultApiTemplate v1"));
}


app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

// Seeding database                        <- SKAL OPDATERES
SeedData.SeedDatabase();

app.Run();


