using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    public partial class ViewInvoiceReport : Form
    {

        static String pswd = "password";

        public ViewInvoiceReport()
        {
            InitializeComponent();
        }

        private void InvoiceReport_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
            string connStr = "server=localhost;user=root;database=GWW;port=3306;password=" + pswd;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "SELECT * from invoices NATURAL JOIN customers;";
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
