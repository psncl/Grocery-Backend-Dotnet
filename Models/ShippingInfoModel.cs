using System;

namespace Backend.Models
{
    public class ShippingInfo
    {
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }

        public ShippingInfo(string address, string postCode, string phoneNumber)
        {
            this.Address = address;
            this.PostCode = postCode;
            this.PhoneNumber = phoneNumber;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var other = (ShippingInfo)obj;

            return this.Address.ToLower().Equals(other.Address) && this.PostCode.ToLower().Equals(other.PostCode) && this.PhoneNumber.ToLower().Equals(other.PhoneNumber);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Address.ToLower(), PostCode.ToLower(), PhoneNumber.ToLower());
        }
    }
}