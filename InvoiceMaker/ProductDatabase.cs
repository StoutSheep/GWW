﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class ProductDatabase
    {

        static String pswd = "password";

        internal static void AddProduct(String itemNo, String itemDesc, int perCarton, String location, double cost, double sellPrice, Int64 upc)
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




        internal static void EditProduct(String oldItemNo, String newItemNo, String itemDesc, int perCarton, String location, double cost, double sellPrice, Int64 upc)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE Products " +
                    "SET ItemNo = '" + newItemNo + "'" +
                    ",ItemDesc = '" + itemDesc + "'" +
                    ",PerCarton = " + perCarton +
                    ",Location = '" + location + "'" +
                    ",Cost = " + cost +
                    ",SellPrice = " + sellPrice +
                    ",UPC = " + upc +
                    " WHERE ItemNo = '" + oldItemNo + "'" +
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



        internal static void DeleteProduct(String itemNo)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DELETE FROM Products" +
                  " WHERE ItemNo = '" + itemNo + "'" +
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





        internal static List<Product> SearchProductsByItemNo(String itemNo)
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


                    Product temp = new Product(rdr[0].ToString(), rdr[1].ToString(), Int32.Parse(rdr[2].ToString()), rdr[3].ToString(), Single.Parse(rdr[4].ToString()), Single.Parse(rdr[5].ToString()), Int32.Parse(rdr[6].ToString()));
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





        internal static Product SearchProductByItemNo(String itemNo)
        {
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT * FROM Products WHERE ItemNo='" + itemNo + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();
                    Product temp = new Product(rdr[0].ToString(), rdr[1].ToString(), Int32.Parse(rdr[2].ToString()), rdr[3].ToString(), Single.Parse(rdr[4].ToString()), Single.Parse(rdr[5].ToString()), Int32.Parse(rdr[6].ToString()));
                    conn.Close();
                    return temp;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Done.");
            return null;

        }


    }
}