using System;

namespace Backend.Models
{
    public class GroceryOrder
    {

        //Private setter to ensure order number is only set during construction,
        //and cannot be accidentally modified later on.
        public uint OrderNumber { get; private set; }

        // Use a dictionary to store the item along with its quantity,
        // so that it is easy to deny adding an item twice.
        private Dictionary<GroceryItem, int> _OrderedItems { get; set; }

        //The above dictionary gives a NotSupportedException on serializing.
        //So the following data structure was employed as workaround. Source: https://stackoverflow.com/a/56351540
        public List<KeyValuePair<GroceryItem, int>> OrderedItems
        {
            get { return _OrderedItems.ToList(); }
            set { _OrderedItems = value.ToDictionary(x => x.Key, x => x.Value); }
        }

        public ShippingInfo ShippingAddress { get; private set; }
        private bool IsLoyaltyMember { get; set; }
        public decimal TotalCost
        {
            get
            {
                return GetTotalCost();
            }
        }

        /* 
        In a real-world application, we would save the applied discount
        and cost of loyalty card in each order instance. Even if it leads
        to duplicated data, it is important because these two rates may change in future.

        EXAMPLE FIELDS:
        public decimal DiscountApplied;
        public decimal LoyaltyCardCost;
        */

        public GroceryOrder(uint orderNumber)
        {
            this.OrderNumber = orderNumber;
            this._OrderedItems = new();
            this.OrderedItems = new();
            this.ShippingAddress = new("", "", "");
            this.IsLoyaltyMember = false;
        }

        public void AddItemToOrder(GroceryItem item, int quantity)
        {
            if (_OrderedItems.ContainsKey(item))
            {
                throw new InvalidOperationException($"{item.Name} already exists in the order. Cannot add it again.");
            }

            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException($"Quantity must be greater than 0. Provided value: {quantity}.");
            }

            _OrderedItems.Add(item, quantity);
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

        public void AddShippingAddress(ShippingInfo shippingAddress)
        {
            if (shippingAddress.Address == "" || shippingAddress.PostCode == "" || shippingAddress.PhoneNumber == "")
            {
                throw new ArgumentNullException($"No field in the shipping info must be empty.");
            }
            this.ShippingAddress = shippingAddress.DeepClone();
        }

        public void BuyLoyaltyMemberShip()
        {
            this.IsLoyaltyMember = true;
        }
    }
}