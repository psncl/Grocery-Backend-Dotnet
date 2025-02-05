using System;

//Intended only for deserializing.
//To be used with PostGroceryOrderDTO class.

namespace Backend.Models
{
    public class GroceryItemAndQty
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }

        public GroceryItemAndQty(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }
    }
}