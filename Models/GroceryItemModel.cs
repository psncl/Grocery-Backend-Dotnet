using System;

namespace Backend.Models
{
    public class GroceryItem
    {

        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public bool IsPhysical { get; set; }

        public GroceryItem(string name, string brandName, decimal price, bool isPhysical = true)
        {
            Name = name;
            BrandName = brandName;
            Price = price;
            IsPhysical = isPhysical;
        }

        public decimal GetCost(int quantity)
        {
            return Price * quantity;
        }

    }
}