namespace Backend;

//This class is used for importing the loyalty discount values from appsettings.json
//See Program.cs for its usage.
public class GroceryAppSettings
{
    public static decimal PriceLoyaltyCard { get; set; }
    public static decimal DiscountLoyaltyCard { get; set; }

    public static decimal DiscountMultiplier()
    {
        return 1 - (DiscountLoyaltyCard / 100m);
    }
}