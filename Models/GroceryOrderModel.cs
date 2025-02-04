using System;

namespace Backend.Models
{
    public class GroceryOrder
    {

        public string OrderNumber { get; set; }

        // Use a dictionary to store the item along with its quantity,
        // so that it is easy to deny adding an item twice.
        public Dictionary<GroceryItem, int> OrderedItems { get; set; }
        public ShippingInfo ShippingAddress { get; set; }
        public bool IsLoyaltyMember { get; set; }

        /* 
        In a real-world application, I would save the applied discount
        and cost of loyalty card in each order instance. Even if it leads
        to duplicated data, it is important because these two rates may change in future.

        EXAMPLE FIELDS:
        public decimal DiscountApplied;
        public decimal LoyaltyCardCost;
        */

        public GroceryOrder(string orderNumber)
        {
            OrderNumber = orderNumber;
            OrderedItems = new();
            ShippingAddress = new("", "", "");
            IsLoyaltyMember = false;
        }

        public void AddItemToOrder(GroceryItem item, int quantity)
        {
            if (OrderedItems.ContainsKey(item))
            {
                throw new InvalidOperationException($"{item.Name} already exists in the order. Cannot add it again.");
            }

            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException($"Quantity must be greater than 0. Provided value: {quantity}.");
            }

            OrderedItems.Add(item, quantity);
        }

        public Dictionary<GroceryItem, decimal> GetIndividualCosts()
        {
            var individualCosts = new Dictionary<GroceryItem, decimal>();

            foreach (var entry in OrderedItems)
            {
                decimal cost = entry.Key.GetCost(entry.Value); //Cost = Price * Quantity
                individualCosts.Add(entry.Key, cost);
            }

            return individualCosts;
        }

        public decimal GetTotalCost()
        {
            decimal sum = 0;

            foreach (var entry in OrderedItems)
            {
                sum += entry.Key.GetCost(entry.Value);
            }

            if (IsLoyaltyMember)
            {
                sum *= GroceryAppSettings.DiscountMultiplier();
                sum += GroceryAppSettings.PriceLoyaltyCard;
            }

            return sum;
        }

        public void BuyLoyaltyMemberShip()
        {
            IsLoyaltyMember = true;
        }
    }
}