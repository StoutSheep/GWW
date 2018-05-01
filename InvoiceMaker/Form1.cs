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
using MySql.Data;

namespace InvoiceMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.Print("hi");
            ProductForm productForm = new ProductForm();
            productForm.Font = new Font(productForm.Font.Name, productForm.Font.Size + 1, productForm.Font.Style);
            productForm.Show();
        }
    }
}
