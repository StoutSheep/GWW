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
            // TODO: Link to Invoice DB
        }
    }
}
