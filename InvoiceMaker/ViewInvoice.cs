using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceMaker
{
    public partial class ViewInvoice : Form
    {
        public ViewInvoice()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModInvoice_Click(object sender, EventArgs e)
        {
            Debug.Print("ModInvoice");
            // TODO: Link to Invoice DB
        }

        private void DeleteInvoice_Click(object sender, EventArgs e)
        {
            Debug.Print("DeleteInvoice");
            // TODO: Link to Invoice DB
        }

        private void ViewInvoice_Click(object sender, EventArgs e)
        {
            Debug.Print("View Invoice");
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
