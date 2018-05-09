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
        public int StoreID { get; set; }
        public String StoreName { get; set; }
        public String StoreDetails { get; set; }
        // Head Office or Billing Address
        public String OfficeAddress { get; set; }
        // Address to send order
        public String StoreContact { get; set; }
        public String ShippingAddress { get; set; }
        public String PhoneNumber { get; set; }
        // Shipping company...Clarify.
        public String PaymentTerms { get; set; }
        // Instructions
        public String SpecialNotes { get; set; }
        // Unique identifier for product
        public String Email { get; set; }
        public String Province { get; set; }

        public Customer(int storeId, String storeName, String storeDetails, String emailAddress, String officeAddress, String shippingAddress, String storeContact, String phoneNumber,
            String paymentTerms, String shippingInstructions, String specialNotes, String province)
        {

            StoreID = storeId;
            StoreName = storeName;
            StoreDetails = storeDetails;
            OfficeAddress = officeAddress;
            ShippingAddress = shippingAddress;
            StoreContact = storeContact;
            PhoneNumber = phoneNumber;
            PaymentTerms = paymentTerms;
            SpecialNotes = specialNotes;
            Email = emailAddress;
            Province = province;

        }

       
    }
}
