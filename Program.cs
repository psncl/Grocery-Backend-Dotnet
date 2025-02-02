using Backend;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var appSettings = config.GetSection("GroceryAppSettings").Get<GroceryAppSettings>();

var app = builder.Build();

app.MapGet("/", () => $"Hello World");

app.Run();