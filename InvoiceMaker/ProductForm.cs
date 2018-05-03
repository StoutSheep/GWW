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
        String itemNo = "";
        String itemDesc = "";
        int perCarton;
        String location = "";
        double cost;
        double sellPrice;
        String upc = "";

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
            itemNo = itemNumber_textBox.Text;
            itemDesc = itemDescription_textBox.Text;
            if(cartonPack_textBox.Text.Length > 0)
                perCarton = Int32.Parse(cartonPack_textBox.Text);
            location = warehouseLoc_textBox.Text;
            if (cost_textBox.Text.Length > 0)
                cost = Double.Parse(cost_textBox.Text);
            if (sellingPrice_textBox.Text.Length > 0)
                sellPrice = Double.Parse(sellingPrice_textBox.Text);
            upc = upc_textBox.Text;
            if(!validItemNumber(itemNo))
            {
                Debug.Print("Failed");
                return;
            }
            Program.AddProduct(itemNo, itemDesc, perCarton, location, cost, sellPrice, upc);
            this.Close();
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
            ArrayList result = Program.SearchProductsByItemNo(itemNo);
            if(result.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
