using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace InvoiceMaker
{
    static class Program
    {
        static String pswd = "password";
       
        [STAThread]
        static void Main()
        {
            InitializeDatabase();


            TestFunctions();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<Product> asd = ProductDatabase.SearchProductsByItemNo("123");
            Application.Run(new Form1());
        }

        static void InitializeDatabase()
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DROP TABLE IF EXISTS InvoiceContents;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "DROP TABLE IF EXISTS Invoices;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "DROP TABLE IF EXISTS Customers;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "DROP TABLE IF EXISTS Products;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "DROP TABLE IF EXISTS ProvinceTax;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                sql = "CREATE TABLE IF NOT EXISTS ProvinceTax (" +
                  "Province varchar(3) NOT NULL," +
                  "PST int NOT NULL," +
                  "GST int NOT NULL," +
                  "CHECK (Tax >= 0 AND Tax <=30)," +
                  "PRIMARY KEY (Province)" +
                  ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();



                sql = "CREATE TABLE IF NOT EXISTS Customers (" +
                    "StoreID int NOT NULL AUTO_INCREMENT," +
                    "StoreName varchar(50) NOT NULL," +
                    "StoreDetails varchar(50)," +
                    "EmailAddress varchar(50)," +
                    "OfficeAddress varchar(50)," +
                    "ShippingAddress varchar(50) NOT NULL," +
                    "StoreContact varchar(50)," +
                    "PhoneNumber varchar(15)," +
                    "PaymentTerms varchar(50)," +
                    "ShippingInstructions varchar(50)," +
                    "SpecialNotes varchar(150)," +
                    "Province varchar(3) NOT NULL," +
                    "PRIMARY KEY (StoreID)," +
                    "FOREIGN KEY (Province) REFERENCES ProvinceTax(Province)" +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                sql = "CREATE TABLE IF NOT EXISTS Products (" +
                    "ItemNo varchar(10) NOT NULL," +
                    "ItemDesc varchar(100) NOT NULL," +
                    "PerCarton int NOT NULL," +
                    "Location varchar(10) NOT NULL," +
                    "Cost decimal(10,2) NOT NULL," +
                    "SellPrice decimal(10,2) NOT NULL," +
                    "UPC bigint," +
                    "PRIMARY KEY (ItemNo)" +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

               

                sql = "CREATE TABLE IF NOT EXISTS Invoices (" +
                   "InvoiceID int NOT NULL AUTO_INCREMENT," +
                   "StoreID int NOT NULL," +
                   "PurchaseOrder varchar(20)," +
                   "SpecialNotes varchar(100)," +
                   "InvoiceNo int," +
                   "SubTotal NUMERIC," +
                   "Gst NUMERIC," +
                   "Pst NUMERIC," +
                   "NetTotal NUMERIC," +
                   "Stage int NOT NULL," +
                   "PRIMARY KEY (InvoiceID)," +
                   "FOREIGN KEY (StoreID) REFERENCES Customers(StoreID)" +
                   ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS InvoiceContents (" +
                   "EntryID bigint NOT NULL AUTO_INCREMENT," +
                   "InvoiceID int NOT NULL," +
                   "ItemNo varchar(10) NOT NULL," +
                   "Quantity int NOT NULL," +
                   "SpecialNotes varchar(40)," +
                   "PRIMARY KEY (EntryID)," +
                   "FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID)," +
                   "FOREIGN KEY (ItemNo) REFERENCES Products(ItemNo)" +
                   ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                SeedData();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

        }

        static void SeedData()
        {
            ProductDatabase.AddProduct("1234a", "cats", 3, "sdaccs", 34.0, 78.3, 3232);
            ProductDatabase.AddProduct("1234b", "dog", 3, "sdadfs", 34.2, 78.3, 32422);
            ProductDatabase.AddProduct("1234c", "animal", 3, "sd44as", 34.2, 78.3, 63242);
            ProductDatabase.AddProduct("1234d", "kangaroo", 3, "sdras", 34.2, 78.3, 73242);
            ProductDatabase.AddProduct("1234e", "rat", 3, "sdasw", 34.2, 78.3, 453242);
            ProductDatabase.AddProduct("1234f", "snek", 3, "sdas", 34.2, 78.3, 324542);
        }


        static void TestFunctions()
        {
            ProvinceTaxDatabase.AddProvinceTax("ON", 7, 5);
            //ProvinceTaxDatabase.EditProvinceTax("BC", "ON", 10, 12);
            ProductDatabase.AddProduct("1234g", "gecko", 3, "ssdas", 34.2, 78.3, 3242);
            ProductDatabase.EditProduct("1234g", "9876a", "notGecko", 5, "s4453das", 3.2, 7.3, 0003242);
            ProductDatabase.DeleteProduct("1234a");
            CustomerDatabase.AddCustomer("Toys", "gift shop", "toyts@gmail.com", "asdas", "somehwere 2131", "Hank", "6047990643", "n/a", "n/a", "n/a", "ON");
            CustomerDatabase.AddCustomer("Games", "", "Games@gmail.com", "sadsads", "somehwereElse 9931", "Hill", "6047990643", "n/a", "n/a", "n/a", "ON");
            int custID = CustomerDatabase.GetStoreID("Toys", "somehwere 2131");
            CustomerDatabase.EditCustomer(custID, "UpdatedToys", "notgiftshop", "toyts@gmail.com", "asdewr", "somehwere 2131", "Hank", "6047990643", "n/a", "n/a", "n/a", "ON");
            int custID2 = CustomerDatabase.GetStoreID("Games", "somehwereElse 9931");
            //CustomerDatabase.DeleteCustomer(custID);
            InvoiceDatabase.AddInvoice(1, "sadasd", "n/a", 0, 10, 5, 7, 12, 1);
            InvoiceContentsDatabase.AddInvoiceContent(1, "1234b", 10, "2 red");


            List<Customer> sd = CustomerDatabase.SearchCustomersByStoreName("Updated");


        }


    }
}
