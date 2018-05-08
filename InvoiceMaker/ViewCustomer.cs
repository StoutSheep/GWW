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
    public partial class ViewCustomer : Form
    {
        public ViewCustomer()
        {
            InitializeComponent();
        }

        private void CancelCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModCustomer_Click(object sender, EventArgs e)
        {
            Debug.Print("ModCustomer");
        }

        private void DeleteCustomer_Click(object sender, EventArgs e)
        {
            Debug.Print("Delete Customer");
        }
    }
}
