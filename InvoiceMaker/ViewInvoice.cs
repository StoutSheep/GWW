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
            pickingListView.Enter += PickingListView_Enter;
            this.Controls.Add(pickingListView);

            doubleCheckListView.Size = new Size(500, 450);
            doubleCheckListView.Location = new Point(600, 120);

            doubleCheckListView.Columns.Add("Local Invoice ID", -2, HorizontalAlignment.Left);
            doubleCheckListView.Columns.Add("Customer Name", 200, HorizontalAlignment.Left);
            doubleCheckListView.Columns.Add("Shipping Address", 200, HorizontalAlignment.Left);

            doubleCheckListView.GridLines = true;
            doubleCheckListView.Scrollable = true;
            doubleCheckListView.FullRowSelect = true;
            doubleCheckListView.Enter += DoubleCheckListView_Enter;

            doubleCheckListView.View = System.Windows.Forms.View.Details;
            doubleCheckListView.DoubleClick += DoubleCheckListView_DoubleClick;
            this.Controls.Add(doubleCheckListView);

            Button processButton = new Button();
            processButton.Location = new Point(450, 600);
            processButton.Size = new Size(70, 40);
            processButton.Text = "Process";
            processButton.Click += ProcessButton_Click;
            this.Controls.Add(processButton);

            Button deleteButton = new Button();
            deleteButton.Location = new Point(530, 600);
            deleteButton.Size = new Size(70, 40);
            deleteButton.Text = "Delete";
            deleteButton.Click += DeleteButton_Click;
            this.Controls.Add(deleteButton);

            Button moveButton = new Button();
            moveButton.Location = new Point(610, 600);
            moveButton.Size = new Size(100, 40);
            moveButton.Text = "Move to Picking";
            moveButton.Click += MoveButton_Click;
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

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in pickingListView.SelectedItems)
            {
                InvoicePickingStage form = new InvoicePickingStage(Int32.Parse(pickingListView.SelectedItems[0].SubItems[0].Text));
                form.Size = new System.Drawing.Size(980, 700);
                form.Show();
            }
            foreach (ListViewItem l in doubleCheckListView.SelectedItems)
            {
                InvoiceDoubleCheckStage form = new InvoiceDoubleCheckStage(Int32.Parse(doubleCheckListView.SelectedItems[0].SubItems[0].Text));
                form.Size = new System.Drawing.Size(1000, 700);
                form.Show();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (pickingListView.SelectedItems.Count > 0 || doubleCheckListView.SelectedItems.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this invoice?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    foreach (ListViewItem l in pickingListView.SelectedItems)
                    {
                        InvoiceDatabase.DeleteInvoice(Int32.Parse(l.SubItems[0].Text));
                    }
                    foreach (ListViewItem l in doubleCheckListView.SelectedItems)
                    {
                        InvoiceDatabase.DeleteInvoice(Int32.Parse(l.SubItems[0].Text));
                    }
                    RefreshView();
                }
                else
                {
                    RefreshView();
                }
            }
            
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            if (doubleCheckListView.SelectedItems.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to move these to the Picking Stage?",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    foreach (ListViewItem l in doubleCheckListView.SelectedItems)
                    {
                        InvoiceDatabase.UpdateStage(Int32.Parse(l.SubItems[0].Text), 1);
                    }
                    RefreshView();
                }
                else
                {
                    // If 'No', do something here.
                }
            }
            
        }

        private void DoubleCheckListView_Enter(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void PickingListView_Enter(object sender, EventArgs e)
        {
            RefreshView();
        }



        private void RefreshView()
        {
            foreach (ListViewItem lvItem in pickingListView.Items)
            {
                pickingListView.Items.Remove(lvItem);
            }
            foreach (ListViewItem lvItem in doubleCheckListView.Items)
            {
                doubleCheckListView.Items.Remove(lvItem);
            }
            pickingList = InvoiceDatabase.SearchInvoicesByStage(1);
            doubleCheckList = InvoiceDatabase.SearchInvoicesByStage(2);
            foreach (Invoice l in pickingList)
            {
                pickingListView.Items.Add(new ListViewItem(new String[] { l.InvoiceID.ToString(), l.customer.StoreName, l.customer.ShippingAddress }));
            }
            foreach (Invoice l in doubleCheckList)
            {
                doubleCheckListView.Items.Add(new ListViewItem(new String[] { l.InvoiceID.ToString(), l.customer.StoreName, l.customer.ShippingAddress }));
            }
        }

        private void DoubleCheckListView_DoubleClick(object sender, EventArgs e)
        {
            InvoiceDoubleCheckStage form = new InvoiceDoubleCheckStage(Int32.Parse(doubleCheckListView.SelectedItems[0].SubItems[0].Text));
            form.Size = new System.Drawing.Size(1000, 700);
            form.Show();
        }

        private void PickingListView_DoubleClick(object sender, EventArgs e)
        {
            InvoicePickingStage form = new InvoicePickingStage(Int32.Parse(pickingListView.SelectedItems[0].SubItems[0].Text));
            form.Size = new System.Drawing.Size(980, 700);
            form.Show();
        }
    }
}
