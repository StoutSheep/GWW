using System;
using System.IO;
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
using ExcelLibrary.SpreadSheet;


namespace InvoiceMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            //Debug.Print("hi");
            //ProductForm productForm = new ProductForm();
            //productForm.Font = new Font(productForm.Font.Name, productForm.Font.Size + 1, productForm.Font.Style);
            //productForm.Show();
            OpenFileDialog fd = new OpenFileDialog();

            if (fd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //ExcelReadWindow prog = new ExcelReadWindow(fd.FileName);
            //prog.Show();

            Debug.Print("hi");
            CustomerForm customerForm = new CustomerForm();
            customerForm.Size = new System.Drawing.Size(460, 610);
            customerForm.Font = new Font(customerForm.Font.Name, customerForm.Font.Size+1, customerForm.Font.Style);
            customerForm.Show();
            InvoiceForm invoiceForm = new InvoiceForm();
            //invoiceForm.Size = new System.Drawing.Size(800, 600);
            invoiceForm.Show();
        }
        
    }
}
