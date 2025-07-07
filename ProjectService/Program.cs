using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectService.Configs;
using ProjectService.Models;
using ProjectService.Repositories;
using ProjectService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
  builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddScoped<IUserSettingsRepository, UserSettingsRepository>();
builder.Services.AddScoped<IUserSettingsService, UserSettingsService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService.Services.ProjectService>();

builder.Services.AddHttpClient<IUserHttpClient, UserHttpClient>(client =>
{
  client.BaseAddress = new Uri(builder.Configuration["UserServiceUrl"]!);
});


builder.Services.AddSingleton<IMongoClient>(s =>
{
  var settings = s.GetRequiredService<IOptions<MongoDbSettings>>().Value;
  return new MongoClient(settings.ConnectionString);
});

builder.Services.AddScoped(serviceProvider =>
{
  var settings = serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
  var client = serviceProvider.GetRequiredService<IMongoClient>();
  return client.GetDatabase(settings.DatabaseName);
});

var app = builder.Build();

var mongoDb = app.Services.GetRequiredService<IMongoDatabase>();

var projectCollection = mongoDb.GetCollection<Project>("projects");
if (!projectCollection.Find(_ => true).Any())
{
  projectCollection.InsertOne(new Project
  {
    UserId = 1,
    Name = "Sample Project",
    Charts = new List<Chart>
    {
      new Chart
      {
        Symbol = "EURUSD",
        Timeframe = "M5",
        Indicators = new List<Indicator>
        {
          new Indicator { Name = "MA", Parameters = "period=14" },
          new Indicator { Name = "RSI", Parameters = "period=10" }
        }
      }
    }
  });
}
app.MapGet("/", () => "Hello World!");




app.Run();