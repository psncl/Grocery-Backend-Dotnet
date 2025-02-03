using Backend;

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

app.MapGet("/items", () => "Hello World");

app.Run();