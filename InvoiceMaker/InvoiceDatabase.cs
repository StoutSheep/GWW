﻿using System;
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

        internal static void AddInvoice(int storeID, String purchaseOrder, String specialNotes, int invoiceNo)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "INSERT INTO Invoices (StoreID, PurchaseOrder, SpecialNotes, InvoiceNo) VALUES (" +
                    storeID + "," +
                    "'" + purchaseOrder + "'," +
                    "'" + specialNotes + "'," +
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



        internal static void EditInvoice(int invoiceID, int storeID, String purchaseOrder, String specialNotes, int invoiceNo)
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
