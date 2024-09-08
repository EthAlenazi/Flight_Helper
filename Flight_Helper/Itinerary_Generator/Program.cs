using Itinerary_Generator.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options => 
options.UseSqlServer(builder.Configuration
.GetConnectionString("DataConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
