using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repository.Implementation;
using WebAPI.Repository.Interface;
using WebAPI.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    configure =>
    {
        configure.CacheProfiles.Add("40SecondsCacheProfile",
            new() { Duration = 40 });
    });
//builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions
//              .ReferenceHandler = ReferenceHandler.Preserve); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<FlightHelperDBContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IActivityTypeService, ActivityTypeService>();
builder.Services.AddScoped<ITransportTypeService, TransportTypeService>();
builder.Services.AddScoped<IAccommodationTypeService, AccommodationTypeService>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddResponseCaching();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        setupAction =>
        {
            var descriptions = app.DescribeApiVersions();
            foreach (var description in descriptions)
            {
                setupAction.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        }
        );
    app.UseDeveloperExceptionPage();
}

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler();

}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.MapControllers();

app.Run();
