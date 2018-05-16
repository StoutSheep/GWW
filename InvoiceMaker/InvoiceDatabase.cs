using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class InvoiceDatabase
    {

        static String pswd = "password";
        static String user = "root";
        static string connStr = "server=localhost;user=" + user + ";database=GWW;port=3306;password=" + pswd;

       
        /*
         * stage 1 = picking stage
         * stage 2 = double check stage
         * stage 3 = done
         */
        internal static int AddInvoice(int storeID, String purchaseOrder, String specialNotes, int invoiceNo, float subTotal, float gst, float pst, float netTotal, int stage)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "INSERT INTO Invoices (StoreID, PurchaseOrder, SpecialNotes, InvoiceNo, SubTotal, Gst, Pst, NetTotal, Stage) VALUES (" +
                    storeID + "," +
                    "'" + purchaseOrder + "'," +
                    "'" + specialNotes + "'," +
                    invoiceNo + "," +
                    subTotal + "," +
                    gst + "," +
                    pst + "," +
                    netTotal + "," +
                    stage + 
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "SELECT MAX(InvoiceID) " +
                    "FROM Invoices;";
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



        internal static void EditInvoice(int invoiceID, int storeID, String purchaseOrder, String specialNotes, int invoiceNo, float subtotal, float gst, float pst, float netTotal, int stage)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

            
                sql = "UPDATE Invoices " +
                   "SET StoreID = " + storeID +
                   ",PurchaseOrder = '" + purchaseOrder +
                   "',SpecialNotes = '" + specialNotes +
                   "',InvoiceNo = " + invoiceNo +
                   ",Subtotal = " + subtotal +
                   ",Gst = " + gst +
                   ",Pst = " + pst +
                   ",NetTotal = " + netTotal +
                   ",Stage = " + stage +
                   " WHERE InvoiceID = " + invoiceID +
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


        internal static void UpdateTotals(int invoiceID, float subtotal, float gst, float pst, float netTotal)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "UPDATE Invoices " +
                   "SET Subtotal = " + subtotal +
                   ",Gst = " + gst +
                   ",Pst = " + pst +
                   ",NetTotal = " + netTotal +
                   " WHERE InvoiceID = " + invoiceID +
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


        internal static void UpdateStage(int invoiceID, int stage)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "UPDATE Invoices " +
                   "SET Stage = " + stage +
                   " WHERE InvoiceID = " + invoiceID +
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

        internal static void UpdateBackorderSpecialNotes(int invoiceID, String notes)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "UPDATE Invoices " +
                   "SET BackorderSpecialNotes = '" + notes +
                   "' WHERE InvoiceID = " + invoiceID +
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


        internal static void UpdateFreight(int invoiceID, float freight)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE Invoices " +
                   "SET Freight = " + freight +
                   " WHERE InvoiceID = " + invoiceID +
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




        internal static List<Invoice> SearchInvoicesByStage(int stage)
        {

            List<Invoice> invoices = new List<Invoice>();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT InvoiceID FROM Invoices WHERE Stage = " + stage + ";";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Invoice temp = new Invoice(Int32.Parse(rdr[0].ToString()));
                    invoices.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return invoices;
        }



        internal static void DeleteInvoice(int invoiceID)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DELETE FROM Invoices " +
                   " WHERE InvoiceID = " + invoiceID +
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
