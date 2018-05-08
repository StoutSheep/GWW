using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class Program
    {
        static String pswd = "password";
       
        [STAThread]
        static void Main()
        {
            InitializeDatabase();

            //AddProvinceTax("BC", 20);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<Product> asd = SearchProductsByItemNo("123");
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

               
                sql = "CREATE TABLE IF NOT EXISTS Customers (" +
                    "StoreID int NOT NULL AUTO_INCREMENT," +
                    "StoreName varchar(50) NOT NULL," +
                    "EmailAddress varchar(50) NOT NULL," +
                    "ShippingAddress varchar(50) NOT NULL," +
                    "StoreContact varchar(50) NOT NULL," +
                    "PhoneNumber char(50) NOT NULL," +
                    "PaymentTerms varchar(50)," +
                    "ShippingInstructions varchar(50)," +
                    "SpecialNotes varchar(50)," +
                    "PRIMARY KEY (StoreID)" +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                sql = "CREATE TABLE IF NOT EXISTS Products (" +
                    "ItemNo varchar(10) NOT NULL," +
                    "ItemDesc varchar(50) NOT NULL," +
                    "PerCarton int NOT NULL," +
                    "Location varchar(10) NOT NULL," +
                    "Cost decimal(10,2) NOT NULL," +
                    "SellPrice decimal(10,2) NOT NULL," +
                    "UPC bigint," +
                    "PRIMARY KEY (ItemNo)" +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS ProvinceTax (" +
                   "Province char(2) NOT NULL," +
                   "Tax int NOT NULL," +
                   "CHECK (Tax >= 0 AND Tax <=30)," +
                   "PRIMARY KEY (Province)" +
                   ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS Invoices (" +
                   "InvoiceID int NOT NULL AUTO_INCREMENT," +
                   "StoreID int NOT NULL," +
                   "InvoiceNo int," +
                   "PRIMARY KEY (InvoiceID)," +
                   "FOREIGN KEY (StoreID) REFERENCES Customers(StoreID)" +
                   ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS InvoiceContents (" +
                   "EntryID int NOT NULL AUTO_INCREMENT," +
                   "InvoiceID int NOT NULL," +
                   "ItemNo varchar(10) NOT NULL," +
                   "Quantity int NOT NULL," +
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
            AddProduct("1234a", "cats", 3, "sdas", 34.2, 78.3, 3242);
            AddProduct("1234b", "dog", 3, "sdas", 34.2, 78.3, 3242);
            AddProduct("1234c", "animal", 3, "sdas", 34.2, 78.3, 3242);
            AddProduct("1234d", "kangaroo", 3, "sdas", 34.2, 78.3, 3242);
            AddProduct("1234e", "rat", 3, "sdas", 34.2, 78.3, 3242);
            AddProduct("1234f", "snek", 3, "sdas", 34.2, 78.3, 3242);
        }





        static void AddCustomer(String storeName, String emailAddress,  String shippingAddress, String storeContact, int phoneNumber, 
            String paymentTerms, String shippingInstructions, String specialNotes)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "INSERT INTO Customers (StoreName, EmailAddress, ShippingAddress, StoreContact, PhoneNumber, PaymentTerms, ShippingInstructions, SpecialNotes) " +
                    "VALUES (" +
                    "'" + storeName + "'," +
                    "'" + emailAddress + "'," +
                    "'" + shippingAddress + "'," +
                    "'" + storeContact + "'," +
                    "'" + phoneNumber + "'," +
                    "'" + paymentTerms + "'," +
                    "'" + shippingInstructions + "'," +
                    "'" + specialNotes + "'," +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

        }


        public static void AddProduct(String itemNo, String itemDesc, int perCarton, String location, double cost, double sellPrice, Int64 upc)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "INSERT INTO Products VALUES (" +
                    "'" + itemNo + "'," +
                    "'" + itemDesc + "'," +
                    perCarton + "," +
                    "'" + location + "'," +
                    cost + "," +
                    sellPrice + "," +
                    upc +
                    ");";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

        }

      


        static void AddProvinceTax(String province, int tax)

        { 
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "INSERT INTO ProvinceTax VALUES (" +
                    "'" + province + "'," +
                    tax +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

        }

        static void AddInvoice(int storeID, int invoiceNo)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "INSERT INTO Invoices (StoreID, InvoiceNo) VALUES (" +
                    storeID + "," +
                    invoiceNo +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }


        static void EditCustomer(int storeId, String storeName, String shippingAddress, String storeContact, int phoneNumber,
            String PaymentTerms, String ShippingInstructions, String SpecialNotes)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE Customers " +
                    "SET StoreName = " + storeName +
                    ",shippingAddress = " + shippingAddress +
                    ",storeContact = " + storeContact +
                    ",phoneNumber = " + phoneNumber +
                    ",PaymentTerms = " + PaymentTerms +
                    ",ShippingInstructions = " + ShippingInstructions +
                    ",SpecialNotes = " + SpecialNotes +
                    ",WHERE StoreID = " + storeId +
                    ";";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");


        }


        public static void EditProduct(String oldItemNo, String newItemNo, String itemDesc, int perCarton, String location, double cost, double sellPrice, Int64 upc)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE Products " +
                    "SET ItemNo = '" + newItemNo +
                    "',ItemDesc = '" + itemDesc +
                    "',PerCarton = " + perCarton +
                    ",Location = '" + location +
                    "',Cost = " + cost +
                    ",SellPrice = " + sellPrice +
                    ",UPC = " + upc +
                    " WHERE ItemNo = '" + oldItemNo +
                    "';";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done Updating.");



        }


        static void EditProvinceTax(String oldProvince, String newProvince, String tax)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE ProvinceTax " +
                   "SET Province = " + newProvince +
                   ",tax = " + tax +
                   ",WHERE Province = " + oldProvince +
                   ";";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");


        }

        static void EditInvoice(int invoiceID, int storeID, int invoiceNo)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "INSERT INTO Invoices (StoreID, InvoiceNo) VALUES (" +
                    storeID + "," +
                    invoiceNo +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

        }

        public static List<Product> SearchProductsByItemNo(String itemNo)
        {
            
            List<Product> productList = new List<Product>();
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT * FROM Products WHERE ItemNo LIKE '" + itemNo + "%';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                  
                    Product temp = new Product(rdr[0].ToString(), rdr[1].ToString(), Int32.Parse(rdr[2].ToString()), rdr[3].ToString(), Single.Parse(rdr[4].ToString()), Single.Parse(rdr[5].ToString()), Int64.Parse(rdr[6].ToString()));
                    productList.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return productList;

        }

    }
}
