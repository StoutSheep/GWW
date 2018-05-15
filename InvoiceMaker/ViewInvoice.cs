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
using Dapper;

namespace InvoiceMaker
{
    public partial class ViewInvoice : Form
    {
        ListView pickingListView = new ListView();
        ListView doubleCheckListView = new ListView();
        List<Invoice> pickingList;
        List<Invoice> doubleCheckList;

        public ViewInvoice()
        {
            InitializeComponent();
            SetupLists();
        }

        private void SetupLists()
        {
            Label pickingLabel = new System.Windows.Forms.Label();
            pickingLabel.AutoSize = true;
            pickingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pickingLabel.Location = new System.Drawing.Point(200, 95);
            pickingLabel.Size = new System.Drawing.Size(238, 42);
            pickingLabel.TabIndex = 0;
            pickingLabel.Text = "Picking Stage";
            this.Controls.Add(pickingLabel);

            Label doubleCheckLabel = new System.Windows.Forms.Label();
            doubleCheckLabel.AutoSize = true;
            doubleCheckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            doubleCheckLabel.Location = new System.Drawing.Point(750, 95);
            doubleCheckLabel.Size = new System.Drawing.Size(238, 42);
            doubleCheckLabel.TabIndex = 0;
            doubleCheckLabel.Text = "Double Check Stage";
            this.Controls.Add(doubleCheckLabel);

            pickingListView.Size = new Size(500, 450);
            pickingListView.Location = new Point(50, 120);

            pickingListView.Columns.Add("Local Invoice ID", -2, HorizontalAlignment.Left);
            pickingListView.Columns.Add("Customer Name", 200, HorizontalAlignment.Left);
            pickingListView.Columns.Add("Shipping Address", 200, HorizontalAlignment.Left);

            pickingListView.GridLines = true;
            pickingListView.Scrollable = true;
            pickingListView.FullRowSelect = true;
            pickingListView.View = System.Windows.Forms.View.Details;
            pickingListView.DoubleClick += PickingListView_DoubleClick;
            this.Controls.Add(pickingListView);

            doubleCheckListView.Size = new Size(500, 450);
            doubleCheckListView.Location = new Point(600, 120);

            doubleCheckListView.Columns.Add("Local Invoice ID", -2, HorizontalAlignment.Left);
            doubleCheckListView.Columns.Add("Customer Name", 200, HorizontalAlignment.Left);
            doubleCheckListView.Columns.Add("Shipping Address", 200, HorizontalAlignment.Left);

            doubleCheckListView.GridLines = true;
            doubleCheckListView.Scrollable = true;
            doubleCheckListView.FullRowSelect = true;

            doubleCheckListView.View = System.Windows.Forms.View.Details;
            doubleCheckListView.DoubleClick += DoubleCheckListView_DoubleClick;
            this.Controls.Add(doubleCheckListView);

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

            pickingList = InvoiceDatabase.SearchInvoicesByStage(1);
            doubleCheckList = InvoiceDatabase.SearchInvoicesByStage(2);
            foreach (Invoice l in pickingList)
            {
                pickingListView.Items.Add(new ListViewItem(new String[] { l.InvoiceID.ToString(), l.customer.StoreName, l.customer.ShippingAddress}));
            }
            foreach (Invoice l in doubleCheckList)
            {
                doubleCheckListView.Items.Add(new ListViewItem(new String[] { l.InvoiceID.ToString(), l.customer.StoreName, l.customer.ShippingAddress }));
            }


        }

        private void DoubleCheckListView_DoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PickingListView_DoubleClick(object sender, EventArgs e)
        {
            InvoicePickingStage form = new InvoicePickingStage(Int32.Parse(pickingListView.SelectedItems[0].SubItems[0].Text));
            form.Size = new System.Drawing.Size(980, 700);
            form.Show();
        }
    }
}
