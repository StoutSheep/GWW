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
       
        [STAThread]
        static void Main()
        {
            //DropTables();
            CreateTables();
            //SeedData();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void DropTables()
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }




        static void CreateTables()
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

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
                    "BillingAddress varchar(50)," +
                    "ShippingAddress varchar(50) NOT NULL," +
                    "StoreContact varchar(50)," +
                    "PhoneNumber varchar(15)," +
                    "PaymentTerms varchar(50)," +
                    "ShippingInstructions varchar(50)," +
                    "Province varchar(3) NOT NULL," +
                    "Rep varchar(10)," +
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
                    "SpecialNotes varchar(100)," +
                    "PRIMARY KEY (ItemNo)" +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                

                sql = "CREATE TABLE IF NOT EXISTS Invoices (" +
                   "InvoiceID int NOT NULL AUTO_INCREMENT," +
                   "StoreID int NOT NULL," +
                   "PurchaseOrder varchar(20)," +
                   "SpecialNotes varchar(100)," +
                   "BackorderSpecialNotes varchar(100)," +
                   "InvoiceNo varchar(10)," +
                   "SubTotal DECIMAL(10,2)," +
                   "Gst DECIMAL(10,2)," +
                   "Pst DECIMAL(10,2)," +
                   "NetTotal DECIMAL(10,2)," +
                   "Freight DECIMAL(10,2) DEFAULT 0," +
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
                   "Backorder int DEFAULT 0," +
                   "SpecialNotes varchar(40)," +
                   "BackorderSpecialNotes varchar(40)," +
                   "PRIMARY KEY (EntryID)," +
                   "FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID) ON DELETE CASCADE," +
                   "FOREIGN KEY (ItemNo) REFERENCES Products(ItemNo) ON UPDATE CASCADE" +
                   ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            

        }

        static void SeedData()
        {
            ProvinceTaxDatabase.AddProvinceTax("ON1", 7, 5);
            ProvinceTaxDatabase.AddProvinceTax("ON2", 0, 5);
            ProvinceTaxDatabase.AddProvinceTax("BC1", 7, 12);
            ProvinceTaxDatabase.AddProvinceTax("BC2", 0, 5);
            ProvinceTaxDatabase.AddProvinceTax("BC3", 7, 5);
            ProvinceTaxDatabase.AddProvinceTax("AB1", 7, 5);


            ProductDatabase.AddProduct("12121", "Bouncy Ball", 1, "TSBK", 1.70, 2.50, 3242343, "may7");
            ProductDatabase.AddProduct("34523", "PlayDough", 6, "TS", 3.90, 4.99, 3453453, "discontinued");
            ProductDatabase.AddProduct("78666", "U-Fidget", 15, "TS", 1.25, 2.00, 5645334, "discontinued");
            ProductDatabase.AddProduct("34513", "Kaleidoscope", 20, "TS", 5.50, 6.50, 6433423, "jn9");
            ProductDatabase.AddProduct("89798", "PlayDough", 8, "TS", 1.20, 2.50, 2565443, "discontinued");
            ProductDatabase.AddProduct("45323", "Sidewalk Chalk", 12, "TS00", 5.50, 7.00, 4534634);
            ProductDatabase.AddProduct("89675", "Rubber Duck", 5, "TSD", 1.90, 2.20, 9678565);
            ProductDatabase.AddProduct("34921", "Baseball", 20, "TS2", 3.00, 3.50, 3527657);
            ProductDatabase.AddProduct("90243", "SuperSoaker", 1, "TS3", 10.50, 12.50, 7687432);
            ProductDatabase.AddProduct("43424", "Diving Sub", 10, "TS1", 3.50, 4.00, 1787424);
            ProductDatabase.AddProduct("42131", "Geo Twister", 4, "TS1", 1.50, 2.00, 2437583);
            ProductDatabase.AddProduct("14513", "Chicken Flingers", 16, "TS1", 8.50, 10.00, 5898275);
            ProductDatabase.AddProduct("24235", "Stunt Flyer", 18, "TS1", 4.00, 4.50, 4980240);



            CustomerDatabase.AddCustomer("Splash Toys", "", "splashtoys@gmail.com", "1201 Main st, Vancouver, BC  V6G9K7", "1201 Main st, Vancouver, BC  V6G9K7", "Nicole", "6047990643", "net30", "fedex", "BC2", "Kyle");
            CustomerDatabase.AddCustomer("Kaboodles", "", "kaboodles@gmail.com", "5601 Broadway st, Vancouver, BC  L6G9K7", "5601 Broadway st, Vancouver, BC  L6G9K7", "Ben", "6047342643", "credit", "canpar", "BC3", "Jake");
            CustomerDatabase.AddCustomer("Childrens Hospital", "Gift Shop", "BCchildrens@gmail.com", "8901 Cambie st, Vancouver, BC  H7J9K0", "8901 Cambie st, Vancouver, BC  H7J9K0", "Sammy", "6045690643", "net30", "canpar", "BC1", "Kyle");
            CustomerDatabase.AddCustomer("Science World Edmonton", "Gift Shop", "scienceworldED@gmail.com", "4745 Main st, Edmonton, AB  K7G5F4", "4745 Main st, Edmonton, AB  K7G5F4", "Julie", "6047670643", "net30", "canpar", "AB1", "Mike");

            int custID;
            custID = CustomerDatabase.GetStoreID("Splash Toys", "1201 Main st, Vancouver, BC  V6G9K7");
            InvoiceDatabase.AddInvoice(custID, "2312343", "", "", 0, 0, 0, 0, 1);
            InvoiceDatabase.UpdateBackorderSpecialNotes(custID, "monday only not friday");
            InvoiceContentsDatabase.AddInvoiceContent(1, "12121", 10, "2 Red");
            InvoiceContentsDatabase.AddInvoiceContent(1, "24235", 8, "");
            InvoiceContentsDatabase.AddInvoiceContent(1, "89675", 12, "1 Pink");
            InvoiceContentsDatabase.AddInvoiceContent(1, "90243", 2, "");
            InvoiceContentsDatabase.AddInvoiceContent(1, "43424", 5, "");

            custID = CustomerDatabase.GetStoreID("Kaboodles", "5601 Broadway st, Vancouver, BC  L6G9K7");
            InvoiceDatabase.AddInvoice(custID, "2312343", "", "", 0, 0, 0, 0, 2);
            InvoiceContentsDatabase.AddInvoiceContent(2, "45323", 10, "3 blue");
            InvoiceContentsDatabase.AddInvoiceContent(2, "34523", 8, "");
            InvoiceContentsDatabase.AddInvoiceContent(2, "34513", 12, "1 Pink");
            InvoiceContentsDatabase.AddInvoiceContent(2, "89798", 2, "");
            InvoiceContentsDatabase.AddInvoiceContent(2, "42131", 5, "");

        }


        static void TestFunctions()
        {

        }


    }
}
