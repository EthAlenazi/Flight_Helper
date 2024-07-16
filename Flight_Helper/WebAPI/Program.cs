using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
//using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repository.Implementation;
using WebAPI.Repository.Interface;
using WebAPI.Services;

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .WriteTo.Console()
//    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
//builder.Host.UseSerilog();
builder.Services.AddProblemDetails();
// Add services to the container.

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

//builder.Services.AddDbContext<FlightHelperDBContext>(options =>
//{
//    options.UseSqlServer(
//        builder.Configuration["ConnectionStrings:CityConnection"]);
//});
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<FlightHelperDBContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IActivityTypeService, ActivityTypeService>();
builder.Services.AddScoped<ITransportTypeService, TransportTypeService>();
builder.Services.AddScoped<IAccommodationTypeService, AccommodationTypeService>();
builder.Services.AddScoped<IUserServices, UserServices>();
//builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.ReportApiVersions = true;
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
}).AddMvc().AddApiExplorer(setupAction =>
{
    setupAction.SubstituteApiVersionInUrl = true;
});
var apiVersionDescriptionProvider = builder.Services.BuildServiceProvider()
  .GetRequiredService<IApiVersionDescriptionProvider>();
builder.Services.AddSwaggerGen(
    setupAction =>
    {
        foreach (var description in
        apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            setupAction.SwaggerDoc(
                $"{description.GroupName}",
                new()
                {
                    Title = "CityInfo API",
                    Version = description.ApiVersion.ToString(),
                    Description = "Through this API you can access cities and their points of interest."
                });
        }

        //var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

        //setupAction.IncludeXmlComments(xmlCommentsFullPath);
        //setupAction.AddSecurityDefinition("CityInfoApiBearerAuth", new()
        //{
        //    Type = SecuritySchemeType.Http,
        //    Scheme = "Bearer",
        //    Description = "Input a valid token to access this API"
        //});

        setupAction.AddSecurityRequirement(new()
             {
                 {
                     new ()
                     {
                         Reference = new OpenApiReference {
                             Type = ReferenceType.SecurityScheme,
                             Id = "CityInfoApiBearerAuth" }
                     },
                     new List<string>()
                 }
             });


    }
    );
builder.Services.AddResponseCaching();
//builder.Services.AddHttpCacheHeaders(
//    (expirationModelOptions) =>
//    {
//        expirationModelOptions.MaxAge = 60;
//        expirationModelOptions.CacheLocation =
//            Marvin.Cache.Headers.CacheLocation.Private;
//    },
//    (validationModelOptions) =>
//    {
//        validationModelOptions.MustRevalidate = true;
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
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
//app.UseAuthorization();

app.UseResponseCaching();
//app.UseHttpCacheHeaders();
app.MapControllers();

app.Run();
