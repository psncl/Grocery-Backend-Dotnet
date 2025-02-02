using System;

namespace Backend.Models
{
    public class GroceryItem
    {

        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }

        public GroceryItem(string name, string brandName, decimal price)
        {
            Name = name;
            BrandName = brandName;
            Price = price;
        }

        public decimal GetCost(int quantity)
        {
            return Price * quantity;
        }

    }
}