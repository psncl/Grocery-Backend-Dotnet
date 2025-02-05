
using System.Text.Json;

namespace Backend.Models;
public static class ExtensionMethods
{
    //This deep cloning mechanism is taken from https://www.wwt.com/article/how-to-clone-objects-in-dotnet-core
    public static T? DeepClone<T>(this T obj)
    {
        if (obj == null)
        {
            return default;
        }

        var serialized = JsonSerializer.Serialize(obj);
        return JsonSerializer.Deserialize<T>(serialized);
    }

    public static uint GenerateRandomOrderNumber()
    {
        var random = new Random();
        // Generate a random 6-digit number
        uint number = (uint)random.Next(100000, 1000000);
        return number;
    }
}