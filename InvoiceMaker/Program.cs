using System;
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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            InitializeDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
        }



        static void InitializeDatabase()
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=password";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;
                

                sql = "CREATE TABLE IF NOT EXISTS Customers (" +
                    "StoreID int NOT NULL AUTO_INCREMENT," +
                    "StoreName varchar(50) NOT NULL," +
                    "ShippingAddress varchar(50) NOT NULL," +
                    "StoreContact varchar(50) NOT NULL," +
                    "PhoneNumber varchar(50) NOT NULL," +
                    "PaymentTerms varchar(50) NOT NULL," +
                    "ShippingInstructions varchar(50) NOT NULL," +
                    "SpecialNotes varchar(50) NOT NULL," +
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
                    "UPC varchar(20) NOT NULL," +
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
