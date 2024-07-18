using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PdfSharp.Charting;
using System;
using System.Reflection;
using System.Text;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.Repository.Implementation;
using WebAPI.Repository.Interface;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<FlightHelperDBContext>(options =>
    options.UseSqlServer(connectionString));
//for authentication
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<StaticCredentials>(builder.Configuration.GetSection("StaticCredentials"));

// Add JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
    });



#region swagger and versioning
builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.ReportApiVersions = true;
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
}).AddMvc() //this for allow versioning in porject
.AddApiExplorer(setupAction =>
{
    setupAction.SubstituteApiVersionInUrl = true;
});//this for showing versioning in swagger
builder.Services.AddControllers(
    configure =>
    {
        configure.CacheProfiles.Add("40SecondsCacheProfile",
            new() { Duration = 40 });
    });
builder.Services.AddEndpointsApiExplorer();//for swager
var apiVersionDescriptionProvider = builder.Services.BuildServiceProvider()//to allow versioning in swagger UI
  .GetRequiredService<IApiVersionDescriptionProvider>();

builder.Services.AddSwaggerGen(
    setupAction =>
    {
        foreach (var description in
        apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            setupAction.SwaggerDoc( //This is for showing versioning API
                $"{description.GroupName}",
                new()
                {
                    Title = "A Program For Helping a clients to Planning her Trips",
                    Version = description.ApiVersion.ToString(),
                    Description = "Through this UI you can access an api and tested."
                });
        }

    }
    );
#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IActivityTypeService, ActivityTypeService>();
builder.Services.AddScoped<ITransportTypeService, TransportTypeService>();
builder.Services.AddScoped<IAccommodationTypeService, AccommodationTypeService>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ITripServices, TripsService>();
builder.Services.AddScoped<IAddServices, AddServices>();
builder.Services.AddScoped<IPdfService, PdfService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
#region swagger in app as middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  //for swager
    app.UseSwaggerUI(
          setupAction =>
          {
              var descriptions = app.DescribeApiVersions();
              foreach (var description in descriptions)
              {
                  setupAction.SwaggerEndpoint(
                      $"/swagger/{description.GroupName}/swagger.json",
                      description.GroupName.ToUpperInvariant());
              }//this to Show versioning in swagger UI as list 

          });//for swager
}
#endregion

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
