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
    public partial class CustomerForm : Form
    {

        public CustomerForm()
        {
            InitializeComponent();

            List<ProvinceTax> provinceTaxList = ProvinceTaxDatabase.GetAllProvinces();

            Object[] arr = new Object[provinceTaxList.Count];
            for (int i = 0; i < provinceTaxList.Count; i++)
            {
                arr[i] = provinceTaxList[i].provinceTax + " - GST: " + provinceTaxList[i].gst + "%/PST: " + provinceTaxList[i].pst + "%";
            }
            provinceTax_comboBox.Items.AddRange(arr);

            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if(tb != phoneNumber_textBox)
                {
                    tb.MaxLength = 50;
                }
                
                else 
                {
                    tb.MaxLength = 15;
                }
            }
            
        }

        private String provinceConverter(String province)
        {
            switch (province)
            {
                case "Alberta":
                    return "AB";
                case "British Columbia":
                    return "BC";
                case "Manitoba":
                    return "MB";
                case "New Brunswick":
                    return "NB";
                case "Newfoundland and Labrador":
                    return "NL";
                case "Northwest Territories":
                    return "NT";
                case "Nova Scotia":
                    return "NS";
                case "Nunavut":
                    return "NU";
                case "Ontario":
                    return "ON";
                case "Prince Edward Island":
                    return "PE";
                case "Quebec":
                    return "QC";
                case "Saskatchewan":
                    return "SK";
                case "Yukon Territories":
                    return "YT";
                default:
                    return "";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Boolean err = false;
            String officeAddress = (officeUnit_textBox.Text != String.Empty ? officeUnit_textBox.Text + " - " : "") + officeStreet_textBox.Text + " " + 
                officeCity_textBox.Text + ", " + provinceConverter(officeProvince_comboBox.Text) + " " + officePostal_textBox.Text;


            String shippingAddress = (shippingUnit_textBox.Text != String.Empty ? shippingUnit_textBox.Text + " - " : "") + shippingStreet_textBox.Text + " " +
                shippingCity_textBox.Text + ", " + provinceConverter(shippingProvince_comboBox.Text) + " " + shippingPostal_textBox.Text;
            if (storeName_textBox.Text == String.Empty)
            {
                label1.ForeColor = Color.Red;
                err = true;
            }
            else
            {
                label1.ForeColor = Color.Black;
            }

            if (shippingAddress.Length < 10)
            {
                groupBox2.ForeColor = Color.Red;
                err = true;
            }
            else
            {
                groupBox2.ForeColor = Color.Black;
            }

            if(provinceTax_comboBox.Text == String.Empty)
            {
                label18.ForeColor = Color.Red;
                err = true;
            }
            else
            {
                label18.ForeColor = Color.Black;
            }
            if(err)
            {
                return;
            }
            CustomerDatabase.AddCustomer(storeName_textBox.Text, storeDetails_textBox.Text, email_textBox.Text, officeAddress,
                shippingAddress, storeContact_textBox.Text, phoneNumber_textBox.Text, paymentTerms_textBox.Text,
                shippingInstructions_textBox.Text, provinceTax_comboBox.Text.Split(' ')[0]);

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
