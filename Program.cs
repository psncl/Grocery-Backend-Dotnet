using Backend;
using Backend.Models;

var builder = WebApplication.CreateBuilder(args);

//Swagger for testing API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Import custom settings for changing purchase order processor parameters easily
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var appSettings = config.GetSection("GroceryAppSettings").Get<GroceryAppSettings>();

var app = builder.Build();

//Swagger for testing API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/items", () =>
{
    //In real-world, we would asynchronously grab this data from a Grocery Items DB table.
    List<GroceryItem> items = new()
    {
        new GroceryItem("Milk", "The best of cows", 2.50m),
        new GroceryItem("Bread", "Easy toast", 1.10m),
        new GroceryItem("Eggs", "Wild chicken", 4.20m)
    };

    return Results.Ok(items);
});

app.Run();