//This deep cloning mechanism is taken from https://www.wwt.com/article/how-to-clone-objects-in-dotnet-core

using System.Text.Json;

namespace Backend.Models;
public static class ExtensionMethods
{
    public static T? DeepClone<T>(this T obj)
    {
        if (obj == null)
        {
            return default;
        }

        var serialized = JsonSerializer.Serialize(obj);
        return JsonSerializer.Deserialize<T>(serialized);
    }
}