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

        internal static void AddCustomer(String storeName, String emailAddress, String shippingAddress, String storeContact, String phoneNumber,
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
                    "'" + specialNotes + "'" +
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


        internal static void EditCustomer(int storeId, String storeName, String emailAddress, String shippingAddress, String storeContact, String phoneNumber,
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
                    "SET StoreName = '" + storeName + "'" +
                    ",EmailAddress = '" + emailAddress + "'" +
                    ",ShippingAddress = '" + shippingAddress + "'" +
                    ",StoreContact = '" + storeContact + "'" +
                    ",PhoneNumber = '" + phoneNumber + "'" +
                    ",PaymentTerms = '" + PaymentTerms + "'" +
                    ",ShippingInstructions = '" + ShippingInstructions + "'" +
                    ",SpecialNotes = '" + SpecialNotes + "'" +
                    " WHERE StoreID = " + storeId +
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


        internal static void DeleteCustomer(int storeID)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DELETE FROM Customers" +
                  " WHERE StoreID = " + storeID +
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



        internal static int GetStoreID(String storeName, String shippingAddress)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;
                MySqlDataReader rdr;

                sql = "SELECT StoreID FROM Customers" +
                  " WHERE StoreName = '" + storeName + "' AND ShippingAddress = '" + shippingAddress + "'" +
                  ";";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();


                if (rdr.HasRows)
                {
                    rdr.Read();
                    int temp = Int32.Parse(rdr[0].ToString());
                    conn.Close();
                    rdr.Close();
                    return temp;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return 0;

        }
    }
}
