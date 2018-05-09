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

        public ProductForm()
        {
            InitializeComponent();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            Boolean allValid = true;
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
            }

            if (!Int32.TryParse(cartonPack_textBox.Text, out perCarton))
            {
                Debug.Print("PerCarton Failed");
                allValid = false;
            }

            if (!validStringLength(location, 10))
            {
                Debug.Print("Location Failed");
                allValid = false;
            }

            if(!Double.TryParse(cost_textBox.Text, out cost))
            {
                Debug.Print("Cost Failed");
                allValid = false;
            }

            if (!Double.TryParse(sellingPrice_textBox.Text, out sellPrice))
            {
                Debug.Print("Selling Price Failed");
                allValid = false;
            }

            /*
            if (!validStringLength(upc, 20))
            {
                Debug.Print("UPC Failed");
                allValid = false;
            }
            */

            if (allValid)
            {
                Program.AddProduct(itemNo, itemDesc, perCarton, location, cost, sellPrice, upc);
                this.Close();
            }
        }

        public Boolean validItemNumber(String itemNo)
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

        public Boolean validStringLength(String text, int max)
        {
            if (text.Length <= 0 || text.Length > max)
            {
                return false;
            }
            return true;
        }

        public Boolean isUniqueItemNo(String itemNo)
        {
            List<Product> result = Program.SearchProductsByItemNo(itemNo);
            if(result.Count > 0)
            {
                return false;
            }
            return true;
        }

        public Boolean validMonetaryValue(double value)
        {
            return true;
        }
    }
}
