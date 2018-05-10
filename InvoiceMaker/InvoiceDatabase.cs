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

       
        /*
         * stage 1 = picking stage
         * stage 2 = double check stage
         * stage 3 = done
         */
        internal static void AddInvoice(int storeID, String purchaseOrder, String specialNotes, int invoiceNo, float subTotal, float gst, float pst, float netTotal, int stage)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); 
            Console.WriteLine("Done.");
        }



        internal static void EditInvoice(int invoiceID, int storeID, String purchaseOrder, String specialNotes, int invoiceNo, int subtotal, int gst, int pst, int netTotal, int stage)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

            
                sql = "UPDATE Invoices " +
                   "SET StoreID = " + storeID +
                   ",PurchaseOrder = " + purchaseOrder +
                   ",SpecialNotes = " + specialNotes +
                   ",InvoiceNo = " + invoiceNo +
                   ",Subtotal = " + invoiceNo +
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



    }
}
