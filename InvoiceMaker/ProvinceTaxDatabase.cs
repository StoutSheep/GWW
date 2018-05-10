using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class ProvinceTaxDatabase
    {

        static String pswd = "password";

        internal static void AddProvinceTax(String province, int pst, int gst)
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
                    pst + "," +
                    gst +
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



        internal static void EditProvinceTax(String province, int pst, int gst)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                /*
                sql = "UPDATE ProvinceTax " +
                   "SET Province = '" + newProvince + "'" +
                   ",pst = " + pst +
                   ",gst = " + gst +
                   " WHERE Province = '" + oldProvince + "'" +
                   ";";
                   */
                sql = "UPDATE ProvinceTax " +
                "SET pst = " + pst +
                ",gst = " + gst +
                " WHERE Province = '" + province + "'" +
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

        internal static List<ProvinceTax> GetAllProvinces()
        {

            List<ProvinceTax> provinceTaxList = new List<ProvinceTax>();
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT * FROM ProvinceTax";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ProvinceTax temp = new ProvinceTax(rdr[0].ToString(), Int32.Parse(rdr[1].ToString()), Int32.Parse(rdr[2].ToString()));
                    provinceTaxList.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return provinceTaxList;
        }

    }
}
