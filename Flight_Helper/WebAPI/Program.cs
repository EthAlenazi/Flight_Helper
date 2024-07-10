using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.ReportApiVersions = true;
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
}).AddMvc().AddApiExplorer(setupAction =>
{
    setupAction.SubstituteApiVersionInUrl = true;
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();//for swager

//builder.Services.AddSwaggerGen(setupAction =>
//{
//    foreach (var description in
//    apiVersionDescriptionProvider.ApiVersionDescriptions)
//    {
//        setupAction.SwaggerDoc(//This is for documentation an API
//            $"{description.GroupName}",
//            new()
//            {
//                Title = "CityInfo API",
//                Version = description.ApiVersion.ToString(),
//                Description = "Through this API you can access cities and their points of interest."
//            });

//    }

//    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

//    setupAction.IncludeXmlComments(xmlCommentsFullPath);

//});//for swager

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
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
    );
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

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
                    Title = "Info API",
                    Version = description.ApiVersion.ToString(),
                    Description = "Through this API you can access our api."
                });
        }

    }
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
