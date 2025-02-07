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
            this.Name = name;
            this.BrandName = brandName;
            this.Price = price;
        }

        public decimal GetCost(int quantity)
        {
            return Price * quantity;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var other = (GroceryItem)obj;

            return this.Name == other.Name && this.BrandName == other.BrandName && this.Price == other.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, BrandName, Price);
        }
    }
}