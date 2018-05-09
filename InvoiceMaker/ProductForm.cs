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
        }

        //for editting
        public ProductForm(String itemNumber, String desc, String cp, String loc, String cost, String price, String upc)
        {
            InitializeComponent();
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
            //cost = cost_textBox.Text;
            //sellPrice = sellingPrice_textBox.Text;
            Int32.TryParse(upc_textBox.Text, out upc);
           // upc = upc_textBox.Text;
            if(!validItemNumber(itemNo))
            {
                Debug.Print("Failed");
                allValid = false;
            }
            if(!validStringLength(itemDesc, 50))
            {
                Debug.Print("Description Failed");
                allValid = false;
                editValid = false;
            }

            if (!Int32.TryParse(cartonPack_textBox.Text, out perCarton))
            {
                Debug.Print("PerCarton Failed");
                allValid = false;
                editValid = false;
            }

            if (!validStringLength(location, 10))
            {
                Debug.Print("Location Failed");
                allValid = false;
                editValid = false;
            }

            if (!Double.TryParse(cost_textBox.Text, out cost))
            {
                Debug.Print("Cost Failed");
                allValid = false;
                editValid = false;
            }

            if (!Double.TryParse(sellingPrice_textBox.Text, out sellPrice))
            {
                Debug.Print("Selling Price Failed");
                allValid = false;
                editValid = false;
            }

            /*
            if (!validStringLength(upc, 20))
            {
                Debug.Print("UPC Failed");
                allValid = false;
            }
            */

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
                if (replacedItemNo != null)
                {
                    ProductDatabase.DeleteProductByItemNo(replacedItemNo);
                }
                ProductDatabase.AddProduct(itemNo, itemDesc, perCarton, location, cost, sellPrice, upc);
                
                this.Close();
            }
        }

        private Boolean validItemNumber(String itemNo)
        {
            if(!validStringLength(itemNo, 10))
            {
                return false;
            }
            if(!isUniqueItemNo(itemNo))
            {
                return false;
            }
            return true;
        }

        private Boolean validStringLength(String text, int max)
        {
            if (text.Length <= 0 || text.Length > max)
            {
                return false;
            }
            return true;
        }

        private Boolean isUniqueItemNo(String itemNo)
        {
            List<Product> result = ProductDatabase.SearchProductsByItemNo(itemNo);
            if(result.Count > 0)
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
    }
}
