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
    public partial class InvoiceDoubleCheckStage : Form
    {
        Panel panel1 = new Panel();
        bool PST = false; //pst of customer
        int customerID;
        Invoice invoice;
        List<InvoiceContentInfo> invoiceContentsList;

        public InvoiceDoubleCheckStage(int invoiceID)
        {
            InitializeComponent();
            invoice = new Invoice(invoiceID);
            invoiceContentsList = InvoiceContentsDatabase.GetInvoiceContents(invoiceID);
            this.customerID = invoice.customer.StoreID;
            Customer c = CustomerDatabase.SearchCustomersByID(customerID);
            ProvinceTax provinceTax = ProvinceTaxDatabase.GetProvinceByName(c.Province);
            if (provinceTax.pst == 0)
            {
                PST = false;
            }
            else
            {
                PST = true;
            }

            panel1.Location = new Point(30, 165);
            panel1.Size = new Size(900, 330);
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.AutoScroll = true;
            panel1.BackColor = Color.DarkGray;

            this.Controls.Add(panel1);
            AddLabels(customerID);
            AddTotalBoxes(customerID);
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

        }

        private void C_TextChanged(object sender, EventArgs e)
        {

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
            for (int j = 0; j < productList.Count; j++)
            {
                arr[j] = productList[j].ItemNo;
            }
            c.Items.AddRange(arr);
        }

        private void AddLabels(int customerID)
        {
            int x = 30;
            int y = 150;

            Customer cust = CustomerDatabase.SearchCustomersByID(customerID);
            ProvinceTax provinceTax = ProvinceTaxDatabase.GetProvinceByName(cust.Province);

            //customer labels
            Label storeNameLabel = new Label();
            if (cust.StoreDetails.Length != 0)
            {
                storeNameLabel.Text = "Store name: " + cust.StoreName + " - " + cust.StoreDetails;
            }
            else
            {
                storeNameLabel.Text = "Store name: " + cust.StoreName;
            }
            storeNameLabel.Location = new Point(30, 10);
            storeNameLabel.AutoSize = true;
            this.Controls.Add(storeNameLabel);

            Label officeLabel = new Label();
            officeLabel.Text = "Billing Address: " + cust.BillingAddress;
            officeLabel.Location = new Point(30, 25);
            officeLabel.AutoSize = true;
            this.Controls.Add(officeLabel);

            Label shippingLabel = new Label();
            shippingLabel.Text = "Shipping Address: " + cust.ShippingAddress;
            shippingLabel.Location = new Point(30, 40);
            shippingLabel.AutoSize = true;
            this.Controls.Add(shippingLabel);

            Label contactLabel = new Label();
            contactLabel.Text = "Store Contact: " + cust.StoreContact;
            contactLabel.Location = new Point(30, 55);
            contactLabel.AutoSize = true;
            this.Controls.Add(contactLabel);

            Label emailLabel = new Label();
            emailLabel.Text = "Email: " + cust.Email;
            emailLabel.Location = new Point(30, 70);
            emailLabel.AutoSize = true;
            this.Controls.Add(emailLabel);

            Label phoneLabel = new Label();
            phoneLabel.Text = "Phone: " + cust.PhoneNumber;
            phoneLabel.Location = new Point(emailLabel.Location.X + emailLabel.Size.Width + 20, 70);
            phoneLabel.AutoSize = true;
            this.Controls.Add(phoneLabel);

            

            Label paymentLabel = new Label();
            paymentLabel.Text = "Payment Terms: " + cust.PaymentTerms;
            paymentLabel.Location = new Point(500, 45);
            paymentLabel.AutoSize = true;
            this.Controls.Add(paymentLabel);

            Label shippingInstructionsLabel = new Label();
            shippingInstructionsLabel.Text = "Shipping Instructions: " + cust.ShippingInstructions;
            shippingInstructionsLabel.Location = new Point(500, 60);
            shippingInstructionsLabel.AutoSize = true;
            this.Controls.Add(shippingInstructionsLabel);

            Label invoiceIDLabel = new Label();
            invoiceIDLabel.Text = "Local Invoice ID: " + invoice.InvoiceID;
            invoiceIDLabel.Location = new Point(500, 10);
            invoiceIDLabel.AutoSize = true;
            this.Controls.Add(invoiceIDLabel);

            Label purchaseOrderLabel = new Label();
            purchaseOrderLabel.Text = "PO#:" + invoice.PurchaseOrder;
            purchaseOrderLabel.Location = new Point(30, 85);
            purchaseOrderLabel.AutoSize = true;
            this.Controls.Add(purchaseOrderLabel);

            Label invoiceSpecialNotesLabel = new Label();
            invoiceSpecialNotesLabel.Text = "Special Notes: ";
            invoiceSpecialNotesLabel.Location = new Point(30, 100);
            invoiceSpecialNotesLabel.AutoSize = true;
            this.Controls.Add(invoiceSpecialNotesLabel);

            TextBox invoiceSpecialNotes = new TextBox();
            invoiceSpecialNotes.Location = new Point(110, 100);
            invoiceSpecialNotes.Size = new Size(500, 25);
            invoiceSpecialNotes.Text = invoice.SpecialNotes;
            invoiceSpecialNotes.Name = "invoiceSpecialNotes";
            invoiceSpecialNotes.AccessibleName = "invoiceSpecialNotes";
            this.Controls.Add(invoiceSpecialNotes);

            Label invoiceNumberLabel = new Label();
            invoiceNumberLabel.Text = "Invoice #: ";
            invoiceNumberLabel.Location = new Point(500, 25);
            invoiceNumberLabel.AutoSize = true;
            this.Controls.Add(invoiceNumberLabel);

            TextBox invoiceNumber = new TextBox();
            invoiceNumber.Location = new Point(560, 25);
            invoiceNumber.Size = new Size(75, 25);
            invoiceNumber.Name = "invoiceNumber";
            invoiceNumber.AccessibleName = "invoiceNumber";
            invoiceNumber.KeyPress += textBoxOnlyNumb_KeyPress;
            this.Controls.Add(invoiceNumber);

            Label backorderInvoiceNotesLabel = new Label();
            backorderInvoiceNotesLabel.Text = "Backorder Invoice Notes: ";
            backorderInvoiceNotesLabel.Location = new Point(30, 125);
            backorderInvoiceNotesLabel.AutoSize = true;
            this.Controls.Add(backorderInvoiceNotesLabel);

            TextBox backorderInvoiceNotes = new TextBox();
            backorderInvoiceNotes.Location = new Point(165, 125);
            backorderInvoiceNotes.Size = new Size(700, 25);
            backorderInvoiceNotes.Text = "ITEMS ON BACKORDER " + cust.StoreName + ". PO#: " + invoice.PurchaseOrder + " ";
            backorderInvoiceNotes.Name = "backorderInvoiceNotes";
            backorderInvoiceNotes.AccessibleName = "backorderInvoiceNotes";
            this.Controls.Add(backorderInvoiceNotes);

            //Invoice column headers
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

            Label backorderLabel = new Label();
            backorderLabel.Text = "B.O.";
            backorderLabel.Location = new Point(x + 790, y);
            backorderLabel.AutoSize = true;
            backorderLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(backorderLabel);

            Label backorderNotesLabel = new Label();
            backorderNotesLabel.Text = "B.O. Note";
            backorderNotesLabel.Location = new Point(x + 830, y);
            backorderNotesLabel.AutoSize = true;
            backorderNotesLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(backorderNotesLabel);

            Button cancelButton = new Button();
            cancelButton.Location = new Point(720, 620);
            cancelButton.Size = new Size(50, 25);
            cancelButton.Text = "Cancel";
            cancelButton.Click += CancelButton_Click;
            this.Controls.Add(cancelButton);

            Button okButton = new Button();
            okButton.Location = new Point(780, 620);
            okButton.Size = new Size(50, 25);
            okButton.Text = "OK";
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);

            Button printButton = new Button();
            printButton.Location = new Point(665, 620);
            printButton.Size = new Size(50, 25);
            printButton.Text = "Print";
            printButton.Click += PrintButton_Click;
            this.Controls.Add(printButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure this invoice is complete?",
                                     "Confirm Completion!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (this.Controls["invoiceNumber"].Text.Length == 0)
                {
                    this.Controls["invoiceNumber"].BackColor = Color.Red;
                    return;
                }
                Customer cust = CustomerDatabase.SearchCustomersByID(customerID);

                for (int i = 0; i < invoiceContentsList.Count; i++)
                {
                    int numBO;
                    String itemNo = this.panel1.Controls["itemNumber" + i].Text;
                    String notes = this.panel1.Controls["specialNotes" + i].Text;
                    int qty = Int32.Parse(this.panel1.Controls["qty" + i].Text);
                    int entryID = InvoiceContentsDatabase.GetEntryID(invoice.InvoiceID, itemNo);

                    if (invoiceContentsList[i].Backorder > 0)
                    {
                        numBO = Int32.Parse(this.panel1.Controls["backorder" + i].Text);
                        InvoiceContentsDatabase.EditInvoiceContent(entryID, invoice.InvoiceID, itemNo, qty, notes);
                        InvoiceContentsDatabase.UpdateBackorderSpecialNotes(entryID, this.panel1.Controls["backorderNotes" + i].Text);
                    }

                }
                int invoiceNumber;

                invoiceNumber = Int32.Parse(this.Controls["invoiceNumber"].Text);

                float freight = 0;
                if (this.Controls["freight"].Text.Length == 0)
                {
                    freight = 0;
                }
                else
                {
                    freight = Single.Parse(this.Controls["freight"].Text);
                }
                InvoiceDatabase.EditInvoice(invoice.InvoiceID, cust.StoreID, invoice.PurchaseOrder, invoice.SpecialNotes, invoiceNumber, Single.Parse(this.Controls["subTotalAmount"].Text), Single.Parse(this.Controls["gst"].Text), Single.Parse(this.Controls["pst"].Text), Single.Parse(this.Controls["invoiceTotal"].Text), 3);
                InvoiceDatabase.UpdateFreight(invoice.InvoiceID, freight);

                int backordertotal = 0;

                for (int i = 0; i < invoice.Items.Count; i++)
                {
                    backordertotal =+ invoice.Items[i].BackOrder;
                }            

                if(backordertotal > 0)
                {
                    InvoiceDatabase.UpdateBackorderSpecialNotes(invoice.InvoiceID, this.Controls["backorderInvoiceNotes"].Text);
                } else
                {
                    InvoiceDatabase.UpdateBackorderSpecialNotes(invoice.InvoiceID, "");
                }

                
                Invoice printInvoice = new Invoice(invoice.InvoiceID);
                List<InvoiceItemDetail> invoiceItemDetails;
                invoiceItemDetails = new List<InvoiceItemDetail>();

                for (int i = 0; i < invoice.Items.Count; i++)
                {
                    invoiceItemDetails.Add(new InvoiceItemDetail());
                    invoiceItemDetails[i].InvoiceID = invoice.InvoiceID;
                    invoiceItemDetails[i].QTY = printInvoice.Items[i].Quantity;
                    invoiceItemDetails[i].GrabCarton = 0.0f;
                    invoiceItemDetails[i].ItemNo = printInvoice.Items[i].ItemNo;
                    invoiceItemDetails[i].Description = printInvoice.Items[i].ItemDesc;
                    invoiceItemDetails[i].CartonTotal = 0;
                    invoiceItemDetails[i].InvoiceItemSellPrice = printInvoice.Items[i].SellPrice;
                    invoiceItemDetails[i].InvoiceItemAmount = printInvoice.Items[i].Quantity * printInvoice.Items[i].SellPrice;
                    invoiceItemDetails[i].InvoiceItemNote = printInvoice.Items[i].SpecialNotes;

                    invoiceItemDetails[i].Backorder = printInvoice.Items[i].BackOrder;
                    invoiceItemDetails[i].BackorderGrabCarton = 0.0f;
                    invoiceItemDetails[i].BackorderNote = printInvoice.Items[i].BackOrderSpecialNotes;
                }

                Form Form2 = new PrintInvoiceProgress(printInvoice, invoiceItemDetails);
                Form2.ShowDialog();

                this.Close();
            }
            else
            {
                // If 'No', do something here.
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            String backordernotes = this.Controls["backorderInvoiceNotes"].Text;

            float freight = 0;
            if (this.Controls["freight"].Text.Length == 0)
            {
                freight = 0;
            }
            else
            {
                freight = Single.Parse(this.Controls["freight"].Text);
            }

            Invoice printInvoice = new Invoice(invoice.InvoiceID);
            List<InvoiceItemDetail> invoiceItemDetails;
            invoiceItemDetails = new List<InvoiceItemDetail>();

            for (int i = 0; i < printInvoice.Items.Count; i++)
            {
                invoiceItemDetails.Add(new InvoiceItemDetail());
                invoiceItemDetails[i].InvoiceID = invoice.InvoiceID;
                // Quantity not updated in DB; Subtraction required
                int SubQuantity = printInvoice.Items[i].Quantity - printInvoice.Items[i].BackOrder;

                invoiceItemDetails[i].QTY = SubQuantity;
                invoiceItemDetails[i].GrabCarton = printInvoice.Items[i].Quantity / printInvoice.Items[i].PerCarton;
                invoiceItemDetails[i].ItemNo = printInvoice.Items[i].ItemNo;
                invoiceItemDetails[i].Location = printInvoice.Items[i].Location;
                invoiceItemDetails[i].Description = printInvoice.Items[i].ItemDesc;
                invoiceItemDetails[i].CartonTotal = printInvoice.Items[i].PerCarton;
                invoiceItemDetails[i].InvoiceItemSellPrice = printInvoice.Items[i].SellPrice;
                invoiceItemDetails[i].InvoiceItemAmount = SubQuantity * printInvoice.Items[i].SellPrice;
                invoiceItemDetails[i].InvoiceItemNote = printInvoice.Items[i].SpecialNotes;

                invoiceItemDetails[i].Backorder = printInvoice.Items[i].BackOrder;
                invoiceItemDetails[i].BackorderGrabCarton = printInvoice.Items[i].BackOrder / printInvoice.Items[i].PerCarton;
                invoiceItemDetails[i].BackorderNote = printInvoice.Items[i].BackOrderSpecialNotes;
            }

            printInvoice.freight = freight;

            Form Form2 = new PrintInvoiceProgress(printInvoice, invoiceItemDetails);
            Form2.ShowDialog();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTotalBoxes(int customerID)
        {
            Customer cust = CustomerDatabase.SearchCustomersByID(customerID);
            ProvinceTax provinceTax = ProvinceTaxDatabase.GetProvinceByName(cust.Province);

            Label subtotalLabel = new Label();
            subtotalLabel.Text = "Subtotal";
            subtotalLabel.Location = new Point(562, 500);
            subtotalLabel.AutoSize = true;
            this.Controls.Add(subtotalLabel);

            TextBox subtotalAmount = new TextBox();
            subtotalAmount.Location = new Point(610, 500);
            subtotalAmount.Size = new Size(50, 25);
            subtotalAmount.Text = invoice.SubTotal.ToString("0.00");
            subtotalAmount.ReadOnly = true;
            subtotalAmount.Name = "subtotalAmount";
            subtotalAmount.AccessibleName = "subtotalAmount";
            subtotalAmount.TextChanged += SubtotalAmount_TextChanged;
            this.Controls.Add(subtotalAmount);

            Label feightLabel = new Label();
            feightLabel.Text = "Freight";
            feightLabel.Location = new Point(570, 530);
            feightLabel.AutoSize = true;
            feightLabel.TextAlign = ContentAlignment.TopRight;
            this.Controls.Add(feightLabel);

            TextBox freight = new TextBox();
            freight.Location = new Point(610, 530);
            freight.Size = new Size(50, 25);
            freight.Name = "freight";
            freight.AccessibleName = "freight";
            freight.TextChanged += Freight_TextChanged;
            this.Controls.Add(freight);

            Label subtotalWithFreightLabel = new Label();
            subtotalWithFreightLabel.Text = "Subtotal w/ Freight";
            subtotalWithFreightLabel.Location = new Point(510, 560);
            subtotalWithFreightLabel.AutoSize = true;
            subtotalWithFreightLabel.TextAlign = ContentAlignment.TopRight;
            this.Controls.Add(subtotalWithFreightLabel);

            TextBox subtotalWithFreight = new TextBox();
            subtotalWithFreight.Location = new Point(610, 560);
            subtotalWithFreight.Size = new Size(50, 25);
            subtotalWithFreight.Name = "subtotalWithFreight";
            subtotalWithFreight.AccessibleName = "subtotalWithFreight";
            subtotalWithFreight.TextChanged += SubtotalWithFreight_TextChanged;
            subtotalWithFreight.ReadOnly = true;
            this.Controls.Add(subtotalWithFreight);

            Label gstLabel = new Label();
            gstLabel.Text = "GST " + provinceTax.gst + "%";
            gstLabel.Location = new Point(560, 590);
            gstLabel.Size = new Size(50, 25);
            gstLabel.TextAlign = ContentAlignment.TopRight;
            this.Controls.Add(gstLabel);

            TextBox gst = new TextBox();
            gst.Location = new Point(610, 590);
            gst.Size = new Size(50, 25);
            gst.Text = invoice.Gst.ToString("0.00");
            gst.ReadOnly = true;
            gst.Name = "gst";
            gst.AccessibleName = "gst";
            this.Controls.Add(gst);

            if (PST)
            {
                Label pstLabel = new Label();
                pstLabel.Text = "PST " + provinceTax.pst + "%";
                pstLabel.Location = new Point(560, 620);
                pstLabel.Size = new Size(50, 25);
                pstLabel.TextAlign = ContentAlignment.TopRight;
                this.Controls.Add(pstLabel);

                TextBox pst = new TextBox();
                pst.Location = new Point(610, 620);
                pst.Size = new Size(50, 25);
                pst.Text = invoice.Pst.ToString("0.00");
                pst.ReadOnly = true;
                pst.Name = "pst";
                pst.AccessibleName = "pst";
                this.Controls.Add(pst);
                

                Label invoiceTotalLabel = new Label();
                invoiceTotalLabel.Text = "Invoice Total";
                invoiceTotalLabel.Location = new Point(540, 650);
                invoiceTotalLabel.AutoSize = true;
                this.Controls.Add(invoiceTotalLabel);

                TextBox invoiceTotal = new TextBox();
                invoiceTotal.Location = new Point(610, 650);
                invoiceTotal.Size = new Size(50, 25);
                invoiceTotal.Text = invoice.NetTotal.ToString("0.00");
                invoiceTotal.ReadOnly = true;
                invoiceTotal.Name = "invoiceTotal";
                invoiceTotal.AccessibleName = "invoiceTotal";
                this.Controls.Add(invoiceTotal);
            }
            else //no pst
            {
                
                Label invoiceTotalLabel = new Label();
                invoiceTotalLabel.Text = "Invoice Total";
                invoiceTotalLabel.Location = new Point(540, 620);
                invoiceTotalLabel.AutoSize = true;
                this.Controls.Add(invoiceTotalLabel);

                TextBox invoiceTotal = new TextBox();
                invoiceTotal.Location = new Point(610, 620);
                invoiceTotal.Size = new Size(50, 25);
                invoiceTotal.Text = invoice.NetTotal.ToString("0.00");
                invoiceTotal.ReadOnly = true;
                invoiceTotal.Name = "invoiceTotal";
                invoiceTotal.AccessibleName = "invoiceTotal";
                this.Controls.Add(invoiceTotal);
            }
        }

        private void SubtotalWithFreight_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;

            Customer c = CustomerDatabase.SearchCustomersByID(customerID);
            ProvinceTax provinceTax = ProvinceTaxDatabase.GetProvinceByName(c.Province);
            float gstRate = (float)provinceTax.gst / 100;

            this.Controls["gst"].Text = (Single.Parse(this.Controls["subtotalWithFreight"].Text) * gstRate).ToString("0.00");
            this.Controls["invoiceTotal"].Text = (Single.Parse(this.Controls["subtotalWithFreight"].Text) * (1 + gstRate)).ToString("0.00");
            if (PST)
            {
                float pstRate = (float)provinceTax.pst / 100;
                this.Controls["pst"].Text = (Single.Parse(this.Controls["subtotalWithFreight"].Text) * pstRate).ToString("0.00");
                this.Controls["invoiceTotal"].Text = (Single.Parse(this.Controls["subtotalWithFreight"].Text) * (1 + gstRate + pstRate)).ToString("0.00");
            }

        }

        private void Freight_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            float freight = 0;
            if (t.Text.Length == 0)
            {
                freight = 0;
            }
            else
            {
                freight = Single.Parse(t.Text);
            }
            this.Controls["subtotalWithFreight"].Text = (invoice.SubTotal + freight).ToString("0.00");

        }

        private void SubtotalAmount_TextChanged(object sender, EventArgs e)
        {
            Customer c = CustomerDatabase.SearchCustomersByID(customerID);
            ProvinceTax provinceTax = ProvinceTaxDatabase.GetProvinceByName(c.Province);
            float gstRate = (float)provinceTax.gst / 100;


            this.Controls["gst"].Text = (Single.Parse(this.Controls["subTotalAmount"].Text) * gstRate).ToString("0.00");
            this.Controls["invoiceTotal"].Text = (Single.Parse(this.Controls["subTotalAmount"].Text) * (1 + gstRate)).ToString("0.00");
            if (PST)
            {
                float pstRate = (float)provinceTax.pst / 100;
                this.Controls["pst"].Text = (Single.Parse(this.Controls["subTotalAmount"].Text) * pstRate).ToString("0.00");
                this.Controls["invoiceTotal"].Text = (Single.Parse(this.Controls["subTotalAmount"].Text) * (1 + gstRate + pstRate)).ToString("0.00");
            }
        }

        private void AddItemBoxes()
        {
            for (int i = 0; i < invoiceContentsList.Count; i++)
            {
                Product p = ProductDatabase.SearchProductByItemNo(invoiceContentsList[i].ItemNo);

                TextBox qty = new TextBox();
                qty.Location = new Point(0, 0 + i * 25);
                qty.Size = new Size(30, 25);
                qty.Name = "qty" + i;
                qty.Text = (invoiceContentsList[i].Quantity - invoiceContentsList[i].Backorder).ToString();
                qty.ReadOnly = true;
                qty.Enter += Desc_Enter;
                qty.AccessibleName = "" + i;
                panel1.Controls.Add(qty);

                TextBox itemNumber = new TextBox();
                itemNumber.Location = new Point(50, 0 + i * 25);
                itemNumber.Size = new Size(100, 25);
                itemNumber.Text = invoiceContentsList[i].ItemNo;
                itemNumber.ReadOnly = true;
                itemNumber.Name = "itemNumber" + i;
                itemNumber.Enter += Desc_Enter;
                itemNumber.AccessibleName = "" + i;
                panel1.Controls.Add(itemNumber);

                TextBox loc = new TextBox();
                loc.Location = new Point(170, 0 + i * 25);
                loc.Size = new Size(50, 25);
                loc.Text = p.Location;
                loc.ReadOnly = true;
                loc.Enter += Desc_Enter;
                loc.Name = "loc" + i;
                loc.AccessibleName = "" + i;
                panel1.Controls.Add(loc);

                TextBox desc = new TextBox();
                desc.Location = new Point(240, 0 + i * 25);
                desc.Size = new Size(200, 25);
                desc.Text = p.ItemDesc;
                desc.ReadOnly = true;
                desc.Enter += Desc_Enter;
                desc.Name = "desc" + i;
                desc.AccessibleName = "" + i;
                panel1.Controls.Add(desc);

                TextBox cartonPack = new TextBox();
                cartonPack.Location = new Point(460, 0 + i * 25);
                cartonPack.Size = new Size(30, 25);
                cartonPack.Text = p.PerCarton.ToString();
                cartonPack.ReadOnly = true;
                cartonPack.Enter += Desc_Enter;
                cartonPack.Name = "carton" + i;
                cartonPack.AccessibleName = "" + i;
                panel1.Controls.Add(cartonPack);

                TextBox cost = new TextBox();
                cost.Location = new Point(510, 0 + i * 25);
                cost.Size = new Size(50, 25);
                cost.Text = p.SellPrice.ToString("0.00");
                cost.ReadOnly = true;
                cost.Enter += Desc_Enter;
                cost.Name = "cost" + i;
                cost.AccessibleName = "" + i;
                panel1.Controls.Add(cost);

                TextBox amount = new TextBox();
                amount.Location = new Point(580, 0 + i * 25);
                amount.Size = new Size(50, 25);
                amount.Text = (Single.Parse(this.panel1.Controls["qty" + i].Text) * p.SellPrice).ToString("0.00");
                amount.ReadOnly = true;
                amount.Enter += Desc_Enter;
                amount.Name = "amount" + i;
                amount.AccessibleName = "" + i;
                amount.TextChanged += Amount_TextChanged;
                panel1.Controls.Add(amount);

                TextBox specialNotes = new TextBox();
                specialNotes.Location = new Point(640, 0 + i * 25);
                specialNotes.Size = new Size(140, 25);
                specialNotes.Text = invoiceContentsList[i].SpecialNotes;
                specialNotes.Name = "specialNotes" + i;
                specialNotes.AccessibleName = "" + i;
                panel1.Controls.Add(specialNotes);

                if (invoiceContentsList[i].Backorder > 0)
                {
                    TextBox backorder = new TextBox();
                    backorder.Location = new Point(790, 0 + i * 25);
                    backorder.Size = new Size(30, 25);
                    backorder.Name = "backorder" + i;
                    backorder.AccessibleName = "" + i;
                    backorder.Text = invoiceContentsList[i].Backorder.ToString();
                    backorder.TextChanged += Backorder_TextChanged;
                    backorder.ReadOnly = true;
                    panel1.Controls.Add(backorder);

                    TextBox backorderNotes = new TextBox();
                    backorderNotes.Location = new Point(830, 0 + i * 25);
                    backorderNotes.Size = new Size(50, 25);
                    backorderNotes.Name = "backorderNotes" + i;
                    backorderNotes.AccessibleName = "" + i;
                    backorderNotes.ReadOnly = true;
                    backorderNotes.Text = invoiceContentsList[i].BackOrderSpecialNotes.ToString();
                    panel1.Controls.Add(backorderNotes);

                }
            }
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            float total = 0;
            for (int i = 0; i < invoiceContentsList.Count; i++)
            {
                if (this.panel1.Controls["amount" + i].Text.Length != 0)
                {
                    total += Single.Parse(this.panel1.Controls["amount" + i].Text);
                }
            }

            this.Controls["subtotalAmount"].Text = total.ToString("0.00");
        }

        private void Backorder_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (t.Text.Length != 0)
            {
                this.panel1.Controls["amount" + t.AccessibleName].Text = (Int32.Parse(t.Text) * Single.Parse(this.panel1.Controls["cost" + t.AccessibleName].Text)).ToString("0.00");
            }
            else
            {
                this.panel1.Controls["amount" + t.AccessibleName].Text = (Int32.Parse(this.panel1.Controls["qty" + t.AccessibleName].Text) * Single.Parse(this.panel1.Controls["cost" + t.AccessibleName].Text)).ToString("0.00");
            }
        }

        private void textBoxOnlyNumb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}

