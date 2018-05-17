using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace InvoiceMaker
{
    public class Invoice
    {
        // String info for User Company
        public String CompanyName { get; set; }
        public String CompanyAddress { get; set; }
        public String CompanyPhoneNumber { get; set; }
        public String CompanyFax { get; set; }
        public String CompanyTollFree { get; set; }
        public String GSTNo { get; set; }

        public Customer customer { get; set; }
        public String CustomerName { get; set; }
        public String CustomerContact { get; set; }
        public String CustomerAddress { get; set; }
        public String CustomerPhone { get; set; }
        public String CustomerTerms { get; set; }
        public String CustomerShippingTerms { get; set; }


        public int InvoiceID { get; set; }
        public String PurchaseOrder { get; set; }
        public String SpecialNotes { get; set; }
        
        public String InvoiceNo { get; set; }
        public float SubTotal { get; set; }
        public float Gst { get; set; }
        public float Pst { get; set; }
        public float NetTotal { get; set; }
        public int Stage { get; set; }

        public List<Product> Items { get; set; }
        public String BackorderNotes { get; set; }
        public float freight { get; set; }

        public Invoice(int invoiceID)
        {
            // WholeSale Company Information
            CompanyName = "Wholesaler";
            CompanyAddress = "1234 GRANOLA ST. NEW WESTMINISTER, BC W4T 4U2";
            CompanyPhoneNumber = "123-456-7890";
            CompanyFax = "123-456-7890";
            CompanyTollFree = "1-800-123-4567";
            GSTNo = "abc123";

            Items = new List<Product>();
            String pswd = "password";
            String user = "root";
            String connStr = "server=localhost;user=" + user + ";database=GWW;port=3306;password=" + pswd;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                String sql;

                sql = "SELECT * FROM Invoices WHERE InvoiceID = " + invoiceID + ";";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                //InvoiceID | StoreID | PurchaseOrder | SpecialNotes | InvoiceNo | SubTotal | Gst | Pst | NetTotal | Stage |

                if (rdr.HasRows)
                {
                    rdr.Read();

                    InvoiceID = Int32.Parse(rdr[0].ToString());

                    customer = CustomerDatabase.SearchCustomersByID(Int32.Parse(rdr[1].ToString()));

                    CustomerName = customer.StoreName;
                    CustomerContact = customer.StoreContact;
                    CustomerAddress = customer.ShippingAddress;
                    CustomerPhone = customer.PhoneNumber;
                    CustomerTerms = customer.PaymentTerms;
                    CustomerShippingTerms = customer.ShippingInstructions;

                    PurchaseOrder = rdr[2].ToString();

                    SpecialNotes = rdr[3].ToString();

                    BackorderNotes = rdr[4].ToString();
                    InvoiceNo = rdr[5].ToString();
                    SubTotal = Single.Parse(rdr[6].ToString());

                    Gst = Single.Parse(rdr[7].ToString());
                    Pst = Single.Parse(rdr[8].ToString());
                    NetTotal = Single.Parse(rdr[9].ToString());
                    freight = Single.Parse(rdr[10].ToString());
                    Stage = Int32.Parse(rdr[11].ToString());

                    List<InvoiceContentInfo> items = InvoiceContentsDatabase.GetInvoiceContents(InvoiceID);
                    Product temp;
                    for (int i = 0; i < items.Count; i++)
                    {
                        temp = ProductDatabase.SearchProductByItemNo(items[i].ItemNo);
                        temp.SpecialNotes = items[i].SpecialNotes;
                        temp.Quantity = items[i].Quantity;
                        temp.BackOrder = items[i].Backorder;
                        temp.BackOrderSpecialNotes = items[i].BackOrderSpecialNotes;
                        Items.Add(temp);

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
