using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class CustomerDatabase
    {

        static String pswd = "password";

        internal static void AddCustomer(String storeName, String emailAddress, String shippingAddress, String storeContact, int phoneNumber,
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


        internal static void EditCustomer(int storeId, String storeName, String shippingAddress, String storeContact, int phoneNumber,
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
    }
}
