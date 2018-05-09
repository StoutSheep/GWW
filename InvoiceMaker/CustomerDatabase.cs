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

        internal static void AddCustomer(String storeName, String storeDetails, String emailAddress, String officeAddress, String shippingAddress, String storeContact, String phoneNumber,
          String paymentTerms, String shippingInstructions, String specialNotes, String province)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "INSERT INTO Customers (StoreName, StoreDetails, EmailAddress, OfficeAddress, ShippingAddress, " +
                    "StoreContact, PhoneNumber, PaymentTerms, ShippingInstructions, SpecialNotes, Province) " +
                    "VALUES (" +
                    "'" + storeName + "'," +
                    "'" + storeDetails + "'," +
                    "'" + emailAddress + "'," +
                    "'" + shippingAddress + "'," +
                    "'" + officeAddress + "'," +
                    "'" + storeContact + "'," +
                    "'" + phoneNumber + "'," +
                    "'" + paymentTerms + "'," +
                    "'" + shippingInstructions + "'," +
                    "'" + specialNotes + "'," +
                    "'" + province + "'" +
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


        internal static void EditCustomer(int storeId, String storeName, String storeDetails, String emailAddress, String officeAddress, String shippingAddress, String storeContact, String phoneNumber,
            String paymentTerms, String shippingInstructions, String specialNotes, String province)
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
                    ",StoreDetails = '" + storeDetails + "'" +
                    ",EmailAddress = '" + emailAddress + "'" +
                    ",OfficeAddress = '" + officeAddress + "'" +
                    ",ShippingAddress = '" + shippingAddress + "'" +
                    ",StoreContact = '" + storeContact + "'" +
                    ",PhoneNumber = '" + phoneNumber + "'" +
                    ",PaymentTerms = '" + paymentTerms + "'" +
                    ",ShippingInstructions = '" + shippingInstructions + "'" +
                    ",SpecialNotes = '" + specialNotes + "'" +
                    ",Province = '" + province + "'" +
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


        internal static List<Customer> SearchCustomersByStoreName(String storeName)
        {

            List<Customer> customerList = new List<Customer>();
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT * FROM Customers WHERE ItemNo LIKE '%" + storeName + "%';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer temp = new Customer(Int32.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString(), rdr[7].ToString(), rdr[8].ToString(), rdr[9].ToString(), rdr[10].ToString(), rdr[11].ToString());
                    customerList.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return customerList;
        }
    }
}
