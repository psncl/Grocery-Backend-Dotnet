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
            Address = address;
            PostCode = postCode;
            PhoneNumber = phoneNumber;
        }
    }
}