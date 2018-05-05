using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    class Customer
    {
        // Unique identifier for customer; Managed in DB and used as PK
        public int CustID { get; set; }
        public String StoreName { get; set; }
        // Head Office or Billing Address
        public String OfficeAddress { get; set; }
        // Address to send order
        public String ShippingAddress { get; set; }
        public String StoreContact { get; set; }
        public String PhoneNumber { get; set; }
        // Shipping company...Clarify.
        public String PaymentTerms { get; set; }
        // Instructions
        public String SpecialNotes { get; set; }
        // Unique identifier for product
        public String Email { get; set; }

        public Customer(int custID, string storeName, string officeAddress, string shippingAddress, string storeContact, string phoneNumber, string paymentTerms, string specialNotes, string email)
        {
            CustID = custID;
            StoreName = storeName;
            OfficeAddress = officeAddress;
            ShippingAddress = shippingAddress;
            StoreContact = storeContact;
            PhoneNumber = phoneNumber;
            PaymentTerms = paymentTerms;
            SpecialNotes = specialNotes;
            Email = email;
        }

        public Customer(int custID, string storeName, string officeAddress, string shippingAddress, string storeContact, string phoneNumber, string email)
        {
            CustID = custID;
            StoreName = storeName;
            OfficeAddress = officeAddress;
            ShippingAddress = shippingAddress;
            StoreContact = storeContact;
            PhoneNumber = phoneNumber;
            PaymentTerms = null;
            SpecialNotes = null;
            Email = email;
        }
    }
}
