using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class InvoiceContentsDatabase
    {

        static String pswd = "password";
        static String user = "root";
        static string connStr = "server=localhost;user=" + user + ";database=GWW;port=3306;password=" + pswd;

        internal static void AddInvoiceContent(int invoiceID, String itemNo, int quantity, String specialNotes) 
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "INSERT INTO InvoiceContents (InvoiceID, ItemNo, Quantity, SpecialNotes) VALUES (" +
                    invoiceID + "," +
                    "'" + itemNo + "'," + 
                    quantity + "," +
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
            Console.WriteLine("Done Inserting Details.");
        }



        internal static void EditInvoiceContent(int entryID, int invoiceID, String itemNo, int quantity, String specialNotes)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE InvoiceContents " +
                  "SET ItemNo = " + itemNo +
                  ",Quantity = " + quantity +
                  ",InvoiceID = " + invoiceID +
                  ",SpecialNotes = " + specialNotes +
                  " WHERE EntryID = " + entryID +
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



        internal static void DeleteInvoiceContent(int entryID)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DELETE FROM InvoiceContents" +
                  " WHERE EntryID = " + entryID +
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




        internal static int GetEntryID(int invoiceID, String itemNo)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;
                MySqlDataReader rdr;

                sql = "SELECT EntryID FROM InvoiceContents" +
                  " WHERE InvoiceID = " + invoiceID + " AND ItemNo = " + itemNo + 
                  ";";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();


                if (rdr.HasRows)
                {
                    rdr.Read();
                    int temp =  Int32.Parse(rdr[0].ToString());
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
