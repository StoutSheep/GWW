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
    public partial class ViewProduct : Form
    {
        public ViewProduct()
        {
            InitializeComponent();
        }

        private void CancelProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModProduct_Click(object sender, EventArgs e)
        {
            Debug.Print("Mod Product");
        }

        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            Debug.Print("Delete Product");
        }
    }
}
