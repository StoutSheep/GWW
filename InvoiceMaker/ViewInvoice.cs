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
        ListView pickingList = new ListView();
        ListView doubleCheckList = new ListView();

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

            pickingList.Size = new Size(500, 450);
            pickingList.Location = new Point(50, 120);

            pickingList.Columns.Add("Local Invoice ID", -2, HorizontalAlignment.Left);
            pickingList.Columns.Add("Customer Name", 200, HorizontalAlignment.Left);
            pickingList.Columns.Add("Shipping Address", 200, HorizontalAlignment.Left);

            pickingList.GridLines = true;
            pickingList.Scrollable = true;
            pickingList.View = System.Windows.Forms.View.Details;
            pickingList.DoubleClick += PickingList_DoubleClick;
            this.Controls.Add(pickingList);

            doubleCheckList.Size = new Size(500, 450);
            doubleCheckList.Location = new Point(600, 120);

            doubleCheckList.Columns.Add("Local Invoice ID", -2, HorizontalAlignment.Left);
            doubleCheckList.Columns.Add("Customer Name", 200, HorizontalAlignment.Left);
            doubleCheckList.Columns.Add("Shipping Address", 200, HorizontalAlignment.Left);

            doubleCheckList.GridLines = true;
            doubleCheckList.Scrollable = true;
            doubleCheckList.View = System.Windows.Forms.View.Details;
            doubleCheckList.DoubleClick += PickingList_DoubleClick;
            this.Controls.Add(doubleCheckList);

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





        }

        private void PickingList_DoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
