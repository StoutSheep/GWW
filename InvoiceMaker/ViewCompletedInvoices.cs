using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceMaker
{
    public partial class ViewCompletedInvoices : Form
    {
        ListView listView = new ListView();
        List<Invoice> list;

        public ViewCompletedInvoices()
        {
            InitializeComponent();
            SetupLists();
        }

        private void SetupLists()
        {

            listView.Size = new Size(800, 450);
            listView.Location = new Point(50, 120);

            listView.Columns.Add("Local Invoice ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Invoice #", 100, HorizontalAlignment.Left);
            listView.Columns.Add("Customer Name", 200, HorizontalAlignment.Left);
            listView.Columns.Add("Shipping Address", 300, HorizontalAlignment.Left);
            listView.Columns.Add("Total Cost", -2, HorizontalAlignment.Left);


            listView.GridLines = true;
            listView.Scrollable = true;
            listView.FullRowSelect = true;
            listView.View = System.Windows.Forms.View.Details;
            listView.DoubleClick += listView_DoubleClick;
            this.Controls.Add(listView);

            Button processButton = new Button();
            processButton.Location = new Point(450, 600);
            processButton.Size = new Size(70, 40);
            processButton.Text = "Process";
            this.Controls.Add(processButton);

            Button deleteButton = new Button();
            deleteButton.Location = new Point(530, 600);
            deleteButton.Size = new Size(70, 40);
            deleteButton.Text = "Delete";
            this.Controls.Add(deleteButton);

            Button moveButton = new Button();
            moveButton.Location = new Point(610, 600);
            moveButton.Size = new Size(100, 40);
            moveButton.Text = "Move to Picking";
            this.Controls.Add(moveButton);

            list = InvoiceDatabase.SearchInvoicesByStage(3);
            foreach (Invoice l in list)
            {
                listView.Items.Add(new ListViewItem(new String[] { l.InvoiceID.ToString(),l.InvoiceNo.ToString() ,l.customer.StoreName, l.customer.ShippingAddress,l.NetTotal.ToString("0.00") }));
            }
        
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            InvoiceCompleted form = new InvoiceCompleted(Int32.Parse(listView.SelectedItems[0].SubItems[0].Text));
            form.Size = new System.Drawing.Size(980, 700);
            form.Show();
        }

        private void invoices_textBox_TextChanged(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RefreshView()
        {
            foreach (ListViewItem lvItem in listView.Items)
            {
                listView.Items.Remove(lvItem);
            }
            if (invoices_textBox.Text.Length == 0)
            {
                list = InvoiceDatabase.SearchInvoicesByStage(3);
            }
            else
            {
                //list = InvoiceDatabase.SearchInvoicesByStage(3);
            }
            foreach (Invoice p in list)
            {
                //productList.Items.Add(new ListViewItem(new String[] { p.ItemNo, p.ItemDesc, p.PerCarton.ToString(), p.Location, p.Cost.ToString("0.00"), p.SellPrice.ToString("0.00"), p.UPC.ToString() }));
            }
        }
    }
}

