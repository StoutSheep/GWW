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
    public partial class ProductForm : Form
    {
        String itemNo;
        String itemDesc;
        int perCarton;
        String location;
        double cost;
        double sellPrice;
        int upc;
        String replacedItemNo = null;
        bool editMode = false;

        //for adding new item
        public ProductForm()
        {
            InitializeComponent();
            setTextBoxRestricts();


        }

        //for editting
        public ProductForm(String itemNumber, String desc, String cp, String loc, String cost, String price, String upc)
        {
            InitializeComponent();
            setTextBoxRestricts();
            replacedItemNo = itemNumber;
            itemNumber_textBox.Text = itemNumber;
            itemDescription_textBox.Text = desc;
            cartonPack_textBox.Text = cp;
            warehouseLoc_textBox.Text = loc;
            cost_textBox.Text = cost;
            sellingPrice_textBox.Text = price;
            upc_textBox.Text = upc;
            editMode = true;
            itemNumber_textBox.BackColor = Color.White;
        }

        private void setTextBoxRestricts()
        {
            itemNumber_textBox.MaxLength = 10;
            itemDescription_textBox.MaxLength = 50;
            warehouseLoc_textBox.MaxLength = 10;
            cartonPack_textBox.KeyPress += textBoxOnlyNumb_KeyPress;
            cost_textBox.KeyPress += textBoxCurrency_KeyPress;
            sellingPrice_textBox.KeyPress += textBoxCurrency_KeyPress;
            upc_textBox.KeyPress += textBoxOnlyNumb_KeyPress;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            Boolean allValid = true;
            Boolean editValid = true;
            itemNo = itemNumber_textBox.Text;
            itemDesc = itemDescription_textBox.Text;
            Int32.TryParse(cartonPack_textBox.Text, out perCarton);
            location = warehouseLoc_textBox.Text;

            Int32.TryParse(upc_textBox.Text, out upc);

            if(!validItemNumber(itemNo))
            {
                allValid = false;
                itemNumber_textBox.BackColor = Color.Red;
            }
            else
            {
                itemNumber_textBox.BackColor = Color.White;
            }
            if(itemDesc.Length == 0)
            {

                allValid = false;
                editValid = false;
                itemDescription_textBox.BackColor = Color.Red;
            }
            else
            {
                itemDescription_textBox.BackColor = Color.White;
            }

            if (!Int32.TryParse(cartonPack_textBox.Text, out perCarton))
            {

                allValid = false;
                editValid = false;
                cartonPack_textBox.BackColor = Color.Red;
            }
            else
            {
                cartonPack_textBox.BackColor = Color.White;
            }

            if (location.Length == 0)
            {

                allValid = false;
                editValid = false;
                warehouseLoc_textBox.BackColor = Color.Red;
            }
            else
            {
                warehouseLoc_textBox.BackColor = Color.White;
            }

            if (!Double.TryParse(cost_textBox.Text, out cost))
            {

                allValid = false;
                editValid = false;
                cost_textBox.BackColor = Color.Red;
            }
            else
            {
                cost_textBox.BackColor = Color.White;
            }

            if (!Double.TryParse(sellingPrice_textBox.Text, out sellPrice))
            {

                allValid = false;
                editValid = false;
                sellingPrice_textBox.BackColor = Color.Red;
            }
            else
            {
                sellingPrice_textBox.BackColor = Color.White;
            }

            if (editMode == false && allValid)
            {
                ProductDatabase.AddProduct(itemNo, itemDesc, perCarton, location, cost, sellPrice, upc);
                if(replacedItemNo != null)
                {
                    ProductDatabase.DeleteProductByItemNo(replacedItemNo);
                }
                this.Close();   
            }
            else if(editMode && editValid)
            {
                ProductDatabase.EditProduct(replacedItemNo, itemNo, itemDesc, perCarton, location, cost, sellPrice, upc);
              
                this.Close();
            }
        }


        private Boolean validItemNumber(String itemNo)
        {
            if(itemNo.Length == 0)
            {
                return false;
            }
            if(!isUniqueItemNo(itemNo))
            {
                return false;
            }
            return true;
        }


        private Boolean isUniqueItemNo(String itemNo)
        {
            Product result = ProductDatabase.SearchProductByItemNo(itemNo);
            if(result != null)
            {
                return false;
            }
            return true;
        }

        private Boolean validMonetaryValue(double value)
        {
            return true;
        }

        private void itemNumber_textBox_TextChanged(object sender, EventArgs e)
        {
            if(editMode == false)
            {
                if(ProductDatabase.SearchProductByItemNo(itemNumber_textBox.Text) != null)
                {
                    itemNumber_textBox.BackColor = Color.Red;
                }
                else
                {
                    itemNumber_textBox.BackColor = Color.White;
                }
            }
            else
            {
                itemNumber_textBox.BackColor = Color.White;
            }

        }

        private void textBoxOnlyNumb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
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
