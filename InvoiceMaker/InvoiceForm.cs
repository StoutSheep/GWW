using System;
using System.Collections;
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
    public partial class InvoiceForm : Form
    {
        Panel panel1 = new Panel();
        int i = 0;
        public InvoiceForm()
        {
            InitializeComponent();

            panel1.Location = new Point(30, 195);
            panel1.Size = new Size(800, 300);
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.Controls.Add(panel1);
            AddLabels();
            AddCustomerBoxes();
            AddItemBoxes();
        }

        private void Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Qty_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            Product product = ProductDatabase.SearchProductByItemNo(this.panel1.Controls["itemNumber" + t.AccessibleName].Text);
            if (product != null && this.panel1.Controls["qty" + t.AccessibleName].Text.Length > 0)
            {
                this.panel1.Controls["amount" + t.AccessibleName].Text = (Single.Parse(this.panel1.Controls["qty" + t.AccessibleName].Text) * product.Cost).ToString("0.00");
            }
            if (Int32.Parse(t.AccessibleName) == i)
            {
                i++;
                AddItemBoxes();
            }

            if(this.panel1.Controls["itemNumber" + t.AccessibleName].Text.Length == 0 && this.panel1.Controls["qty" + t.AccessibleName].Text.Length == 0)
            {
                this.panel1.Controls["loc" + t.AccessibleName].Text = "";
                this.panel1.Controls["desc" + t.AccessibleName].Text = "";
                this.panel1.Controls["carton" + t.AccessibleName].Text = "";
                this.panel1.Controls["cost" + t.AccessibleName].Text = "";
                this.panel1.Controls["amount" + t.AccessibleName].Text = "";
            }
        }

        private void C_TextChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            Product product = ProductDatabase.SearchProductByItemNo(c.Text);
            if (product != null)
            {
                this.panel1.Controls["loc" + c.AccessibleName].Text = product.Location;
                this.panel1.Controls["desc" + c.AccessibleName].Text = product.ItemDesc;
                this.panel1.Controls["carton" + c.AccessibleName].Text = product.PerCarton.ToString();
                this.panel1.Controls["cost" + c.AccessibleName].Text = product.Cost.ToString("0.00");
                if (this.panel1.Controls["qty" + c.AccessibleName].Text.Length > 0)
                {
                    this.panel1.Controls["amount" + c.AccessibleName].Text = (Single.Parse(this.panel1.Controls["qty" + c.AccessibleName].Text) * product.Cost).ToString("0.00");
                }
            }

            if (Int32.Parse(c.AccessibleName) == i)
            {
                i++;
                AddItemBoxes();
            }

            //qty and itemNo empty
            if (this.panel1.Controls["itemNumber" + c.AccessibleName].Text.Length == 0 && this.panel1.Controls["qty" + c.AccessibleName].Text.Length == 0)
            {
                this.panel1.Controls["loc" + c.AccessibleName].Text = "";
                this.panel1.Controls["desc" + c.AccessibleName].Text = "";
                this.panel1.Controls["carton" + c.AccessibleName].Text = "";
                this.panel1.Controls["cost" + c.AccessibleName].Text = "";
                this.panel1.Controls["amount" + c.AccessibleName].Text = "";
            }
        }

        private void Desc_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void C_TextUpdated(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            c.DroppedDown = true;

            c.Items.Clear();
            c.SelectionLength = 0;

            c.SelectionStart = c.Text.Length;

            List<Product> productList = ProductDatabase.SearchProductsByItemNo(c.Text);
            
                Object[] arr = new Object[productList.Count];
                for (int i = 0; i < productList.Count; i++)
                {
                    arr[i] = productList[i].ItemNo;
                }
                c.Items.AddRange(arr);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddLabels()
        {
            int x = 30;
            int y = 180;

            Label storeNameLabel = new Label();
            storeNameLabel.Text = "Store name";
            storeNameLabel.Location = new Point(30, 10);
            storeNameLabel.AutoSize = true;
            storeNameLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(storeNameLabel);

            Label qtyLabel = new Label();
            qtyLabel.Text = "Qty";
            qtyLabel.Location = new Point(x, y);
            qtyLabel.AutoSize = true;
            qtyLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(qtyLabel);

            Label itemNoLabel = new Label();
            itemNoLabel.Text = "Item Number";
            itemNoLabel.Location = new Point(x + 50, y);
            itemNoLabel.AutoSize = true;
            itemNoLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(itemNoLabel);

            Label locLabel = new Label();
            locLabel.Text = "Location";
            locLabel.Location = new Point(x + 170, y);
            locLabel.AutoSize = true;
            locLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(locLabel);

            Label descLabel = new Label();
            descLabel.Text = "Description";
            descLabel.Location = new Point(x + 240, y);
            descLabel.AutoSize = true;
            descLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(descLabel);

            Label cartonLabel = new Label();
            cartonLabel.Text = "Pack";
            cartonLabel.Location = new Point(x + 460, y);
            cartonLabel.AutoSize = true;
            cartonLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(cartonLabel);

            Label costLabel = new Label();
            costLabel.Text = "Cost";
            costLabel.Location = new Point(x + 510, y);
            costLabel.AutoSize = true;
            costLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(costLabel);

            Label amountLabel = new Label();
            amountLabel.Text = "Amount";
            amountLabel.Location = new Point(x + 580, y);
            amountLabel.AutoSize = true;
            amountLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(amountLabel);

            Label specialNotesLabel = new Label();
            specialNotesLabel.Text = "Special Notes";
            specialNotesLabel.Location = new Point(x + 640, y);
            specialNotesLabel.AutoSize = true;
            specialNotesLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(specialNotesLabel);
        }

        private void AddCustomerBoxes()
        {
            ComboBox storeName = new ComboBox();
            storeName.TextChanged += StoreName_TextChanged;
            storeName.TextUpdate += StoreName_TextUpdate;
            storeName.Location = new Point(30, 25);
            storeName.Size = new Size(100, 25);
            storeName.Name = "storeName";
            this.Controls.Add(storeName);
        }

        private void StoreName_TextUpdate(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox) sender;

            c.DroppedDown = true;

            c.Items.Clear();
            c.SelectionLength = 0;

            c.SelectionStart = c.Text.Length;

            List<Product> productList = ProductDatabase.SearchProductsByItemNo(c.Text);

            Object[] arr = new Object[productList.Count];
            for (int i = 0; i < productList.Count; i++)
            {
                arr[i] = productList[i].ItemNo;
            }
            c.Items.AddRange(arr);
        }

        private void StoreName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AddItemBoxes()
        {
            TextBox qty = new TextBox();
            qty.Location = new Point(0, 0 + i * 25);
            qty.Size = new Size(30, 25);
            qty.Name = "qty" + i;
            qty.TextChanged += Qty_TextChanged;
            qty.KeyPress += Qty_KeyPress;
            qty.AccessibleName = "" + i;
            panel1.Controls.Add(qty);

            ComboBox itemNumber = new ComboBox();
            itemNumber.Location = new Point(50, 0 + i * 25);
            itemNumber.Size = new Size(100, 25);
            itemNumber.TextUpdate += C_TextUpdated;
            itemNumber.TextChanged += C_TextChanged;
            itemNumber.Name = "itemNumber" + i;
            itemNumber.AccessibleName = "" + i;
            panel1.Controls.Add(itemNumber);

            TextBox loc = new TextBox();
            loc.Location = new Point(170, 0 + i * 25);
            loc.Size = new Size(50, 25);
            loc.ReadOnly = true;
            loc.Enter += Desc_Enter;
            loc.Name = "loc" + i;
            loc.AccessibleName = "" + i;
            panel1.Controls.Add(loc);

            TextBox desc = new TextBox();
            desc.Location = new Point(240, 0 + i * 25);
            desc.Size = new Size(200, 25);
            desc.ReadOnly = true;
            desc.Enter += Desc_Enter;
            desc.Name = "desc" + i;
            desc.AccessibleName = "" + i;
            panel1.Controls.Add(desc);

            TextBox cartonPack = new TextBox();
            cartonPack.Location = new Point(460, 0 + i * 25);
            cartonPack.Size = new Size(30, 25);
            cartonPack.ReadOnly = true;
            cartonPack.Enter += Desc_Enter;
            cartonPack.Name = "carton" + i;
            cartonPack.AccessibleName = "" + i;
            panel1.Controls.Add(cartonPack);

            TextBox cost = new TextBox();
            cost.Location = new Point(510, 0 + i * 25);
            cost.Size = new Size(50, 25);
            cost.ReadOnly = true;
            cost.Enter += Desc_Enter;
            cost.Name = "cost" + i;
            cost.AccessibleName = "" + i;
            panel1.Controls.Add(cost);

            TextBox amount = new TextBox();
            amount.Location = new Point(580, 0 + i * 25);
            amount.Size = new Size(50, 25);
            amount.ReadOnly = true;
            amount.Enter += Desc_Enter;
            amount.Name = "amount" + i;
            amount.AccessibleName = "" + i;
            panel1.Controls.Add(amount);

            TextBox specialNotes = new TextBox();
            specialNotes.Location = new Point(640, 0 + i * 25);
            specialNotes.Size = new Size(140, 25);
            specialNotes.Name = "specialNotes" + i;
            specialNotes.AccessibleName = "" + i;
            panel1.Controls.Add(specialNotes);

        }
    }
}
