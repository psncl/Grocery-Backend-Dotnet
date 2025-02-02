using System;

namespace Models
{
    public class OrderModel
    {

        public string OrderNumber { get; set; }
        public List<GroceryItem,  { get; set; }
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