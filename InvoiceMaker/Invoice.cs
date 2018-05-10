using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public class Invoice
    {
        public Customer currentCustomer { get; set; }

        // String info for User Company
        public String CompanyName = "Wholesaler";
        public String CompanyAddress = "1234 GRANOLA ST. NEW WESTMINISTER, BC W4T 4U2";
        public String CompanyPhoneNumber= "123-456-7890";
        public String CompanyFax = "123-456-7890";
        public String CompanyTollFree = "1-800-123-4567";

        // TODO: Query Invoices by Stage 1; Stage 2 and Stage 3

        // TODO: Query Customer with associated Invoice IDS

        // TODO: Join Customers based on stages

        //TODO: Query all invoice items based on Invoice IDS
        //SELECT invoicecontents.InvoiceID, invoicecontents.Quantity, invoicecontents.Quantity/products.PerCarton AS 'Grab Carton', products.Location, products.ItemDesc, products.PerCarton, products.SellPrice, invoicecontents.Quantity* products.SellPrice AS 'Amount' from invoicecontents
        //NATURAL JOIN products;

        // TODO: Join all invoice items with invoice ID based on customer and selected invoice ID

    }
}
