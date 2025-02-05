using System;

//DTO class to act as interface for the frontend.
//Intended only for deserializing.

namespace Backend.Models
{
    public class PostGroceryOrderDTO
    {
        public List<GroceryItemAndQty> ItemsToOrder { get; set; }
        public ShippingInfo ShippingInfo { get; set; }
        public bool LoyaltyPurchase { get; set; }

        public PostGroceryOrderDTO()
        {
            ItemsToOrder = new();
            ShippingInfo = new("", "", "");
        }
    }
}