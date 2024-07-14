using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repository.Implementation;
using WebAPI.Repository.Interface;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<FlightHelperDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(
                builder.Configuration["Authentication:SecretForKey"]))
        };
    }
    );



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

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IActivityTypeService, ActivityTypeService>();
builder.Services.AddScoped<ITransportTypeService, TransportTypeService>();
builder.Services.AddScoped<IAccommodationTypeService, AccommodationTypeService>();
builder.Services.AddScoped<IUserServices, UserServices>();

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
