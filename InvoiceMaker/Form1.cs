﻿using System;
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
            Debug.Print("Customer Form");
            CustomerForm customerForm = new CustomerForm();
            customerForm.Size = new System.Drawing.Size(460, 610);
            customerForm.Font = new Font(customerForm.Font.Name, customerForm.Font.Size + 1, customerForm.Font.Style);
            customerForm.Show();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            Debug.Print("Add Product Form");
            ProductForm productForm = new ProductForm();
            productForm.Font = new Font(productForm.Font.Name, productForm.Font.Size + 1, productForm.Font.Style);
            productForm.Show();
        }

        private void ReadProductExcel_Click(object sender, EventArgs e)
        {
            Debug.Print("Read Excel");
            ReadProduct readProduct = new ReadProduct();
            readProduct.Show();
        }

        private void AddInvoice_Click(object sender, EventArgs e)
        {
            Debug.Print("InvoiceForm");
            InvoiceForm invoiceForm = new InvoiceForm();
            invoiceForm.Size = new System.Drawing.Size(750, 600);
            invoiceForm.Show();
        }

        private void ViewCustomer_Click(object sender, EventArgs e)
        {
            Debug.Print("ViewCustomer");
            ViewCustomer viewCustomer = new ViewCustomer();
            viewCustomer.Show();
        }

        private void ViewInvoice_Click(object sender, EventArgs e)
        {
            Debug.Print("ViewInvoice");
            ViewInvoice viewInvoice = new ViewInvoice();
            viewInvoice.Show();
        }

        private void ViewProduct_Click(object sender, EventArgs e)
        {
            Debug.Print("ViewProduct");
            ViewProduct viewProduct = new ViewProduct();
            viewProduct.Size = new System.Drawing.Size(1000, 700);
            viewProduct.Show();
        }

    }
}
