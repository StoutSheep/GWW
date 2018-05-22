using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public class Customer
    {
        // Unique identifier for customer; Managed in DB and used as PK
        public int StoreID { get; set; }
        public String StoreName { get; set; }
        public String StoreDetails { get; set; }
        // Head Office or Billing Address
        public String BillingAddress { get; set; }
        // Address to send order
        public String StoreContact { get; set; }
        public String ShippingAddress { get; set; }
        public String PhoneNumber { get; set; }
        // Shipping company...Clarify.
        public String PaymentTerms { get; set; }
        // Instructions
        public String ShippingInstructions { get; set; }
        // Unique identifier for product
        public String Email { get; set; }
        public String Province { get; set; }

        public String Rep { get; set; }

        public Customer(int storeId, String storeName, String storeDetails, String emailAddress, String billingAddress, String shippingAddress, String storeContact, String phoneNumber,
            String paymentTerms, String shippingInstructions, String province)
        {

            StoreID = storeId;
            StoreName = storeName;
            StoreDetails = storeDetails;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            StoreContact = storeContact;
            PhoneNumber = phoneNumber;
            PaymentTerms = paymentTerms;
            ShippingInstructions = shippingInstructions;
            Email = emailAddress;
            Province = province;
            Rep = "";

        }

        public Customer(int storeId, String storeName, String storeDetails, String emailAddress, String billingAddress, String shippingAddress, String storeContact, String phoneNumber,
            String paymentTerms, String shippingInstructions, String province, String rep)
        {

            StoreID = storeId;
            StoreName = storeName;
            StoreDetails = storeDetails;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            StoreContact = storeContact;
            PhoneNumber = phoneNumber;
            PaymentTerms = paymentTerms;
            ShippingInstructions = shippingInstructions;
            Email = emailAddress;
            Province = province;
            Rep = rep;

        }



    }
}
