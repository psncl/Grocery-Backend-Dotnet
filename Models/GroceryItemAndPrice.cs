using System;

//Helper class to act as interface for the frontend.
//It receives only two items relevant to ordering: item name and quantity.

namespace Backend.Models
{
    public class GroceryItemAndPrice
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public GroceryItemAndPrice(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }
    }
}