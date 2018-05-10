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

        public String CompanyName = "Great West Wholesale";
        public String CompanyAddress = "1670 PANDORA ST. VANCOUVER, BC V5L 1L6";
        public String CompanyPhoneNumber= "604-255-9588";
        public String CompanyFax = "604-255-9589";
        public String CompanyTollFree = "1-800-901-9588";



    }
}
