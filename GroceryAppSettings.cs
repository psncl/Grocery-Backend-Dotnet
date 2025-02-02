namespace Backend;
public class GroceryAppSettings
{
    public static decimal PriceLoyaltyCard { get; set; }
    public static decimal DiscountLoyaltyCard { get; set; }

    public static decimal DiscountMultiplier()
    {
        return 1 - (DiscountLoyaltyCard / 100m);
    }
}