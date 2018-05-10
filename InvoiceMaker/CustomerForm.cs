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
            specialNotes_textBox.MaxLength = 150;
            
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
            Debug.Print(storeName_textBox.Text);

            String officeAddress = officeUnit_textBox.Text + " - " + officeStreet_textBox.Text + " " + 
                officeCity_textBox.Text + ", " + provinceConverter(officeProvince_comboBox.Text) + " " + officePostal_textBox.Text;
            Debug.Print(officeAddress);

            String shippingAddress = shippingUnit_textBox.Text + " - " + shippingStreet_textBox.Text + " " +
                shippingCity_textBox.Text + ", " + provinceConverter(shippingProvince_comboBox.Text) + " " + shippingPostal_textBox.Text;
            Debug.Print(shippingAddress);

            Debug.Print(storeContact_textBox.Text);
            Debug.Print(phoneNumber_textBox.Text);

            Debug.Print(paymentTerms_textBox.Text);
            Debug.Print(shippingInstructions_textBox.Text);
            Debug.Print(specialNotes_textBox.Text);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
