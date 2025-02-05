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

//In real-world, we would asynchronously grab this data from a Grocery Items DB table.
List<GroceryItem> GroceryItemInventory = new()
    {
        new("Milk", "The best of cows", 2.50m),
        new("Bread", "Easy toast", 1.10m),
        new("Eggs", "Wild chicken", 4.20m)
    };

//Dictionary to hold order number mapped to an Order object.
//This is similar to a factory design pattern. And it ensures order numbers are unique.
Dictionary<uint, GroceryOrder> AllPlacedOrders = new();

app.MapGet("/items", () =>
{
    return Results.Ok(GroceryItemInventory);
});

app.MapPost("/placeorder", (PostGroceryOrderDTO order) =>
{
    uint orderNumber = 0;
    while (orderNumber == 0)
    {
        uint potentialOrderNumber = ExtensionMethods.GenerateRandomOrderNumber();
        if (AllPlacedOrders.ContainsKey(potentialOrderNumber))
        {
            continue;
        }
        else
        {
            orderNumber = potentialOrderNumber;
        }
    }
    var newOrder = new GroceryOrder(orderNumber);

    foreach (var item in order.ItemsToOrder)
    {
        int foundItemIndex = -1;
        for (int i = 0; i < GroceryItemInventory.Count; i++)
        {
            if (item.Name == GroceryItemInventory[i].Name)
            {
                foundItemIndex = i;
            }
        }
        if (foundItemIndex == -1)
        {
            return Results.BadRequest($"{item.Name} is not a valid grocery item in the inventory.");
        }

        try
        {
            var itemToAdd = GroceryItemInventory[foundItemIndex];
            newOrder.AddItemToOrder(itemToAdd, item.Quantity);
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Order Failed: {ex.Message}");
        }
    }

    //Thanks to the exception handling above, the following code will only reach if all items from the frontend were found to be valid.
    AllPlacedOrders.Add(orderNumber, newOrder);
    //TODO: Add shipping info and loyalty purchase
    return Results.Created($"order created", newOrder);
});

app.Run();