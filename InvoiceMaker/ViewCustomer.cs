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
        ListView custList = new ListView();
        public ViewCustomer()
        {

            InitializeComponent();
            AddButtons();
            custList.Size = new Size(1150, 500);
            custList.Location = new Point(25, 100);

            custList.Columns.Add("Store Name", 150, HorizontalAlignment.Left);
            custList.Columns.Add("Store Details", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Office Address", 190, HorizontalAlignment.Left);
            custList.Columns.Add("Shipping Address", 190, HorizontalAlignment.Left);
            custList.Columns.Add("Store Contact", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Phone Number", 90, HorizontalAlignment.Left);
            custList.Columns.Add("Province Tax", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Payment Terms", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Shipping Instr", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Special Notes ", -2, HorizontalAlignment.Left);
            


            custList.GridLines = true;
            custList.Scrollable = true;
            custList.View = System.Windows.Forms.View.Details;
            //custList.DoubleClick += CustomerList_DoubleClick;

            this.Controls.Add(custList);

            
        }

        private void AddButtons()
        {
            // 
            // CancelProduct
            // 
            this.CancelCustomer.Location = new System.Drawing.Point(400, 610);
            this.CancelCustomer.Name = "CancelProduct";
            this.CancelCustomer.Size = new System.Drawing.Size(100, 30);
            this.CancelCustomer.TabIndex = 8;
            this.CancelCustomer.Text = "Cancel";
            this.CancelCustomer.UseVisualStyleBackColor = true;
            this.CancelCustomer.Click += new System.EventHandler(this.CancelCustomer_Click);
            // 
            // ModProduct
            // 
            this.ModCustomer.Location = new System.Drawing.Point(550, 610);
            this.ModCustomer.Name = "ModProduct";
            this.ModCustomer.Size = new System.Drawing.Size(100, 30);
            this.ModCustomer.TabIndex = 6;
            this.ModCustomer.Text = "Modify";
            this.ModCustomer.UseVisualStyleBackColor = true;
            this.ModCustomer.Click += new System.EventHandler(this.ModCustomer_Click);
            // 
            // DeleteProduct
            // 
            this.DeleteCustomer.Location = new System.Drawing.Point(700, 610);
            this.DeleteCustomer.Name = "DeleteProduct";
            this.DeleteCustomer.Size = new System.Drawing.Size(100, 30);
            this.DeleteCustomer.TabIndex = 7;
            this.DeleteCustomer.Text = "Delete";
            this.DeleteCustomer.UseVisualStyleBackColor = true;
            this.DeleteCustomer.Click += new System.EventHandler(this.DeleteCustomer_Click);

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

        private void productTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
