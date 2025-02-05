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
    }
}