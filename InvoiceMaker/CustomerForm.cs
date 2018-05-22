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

        bool editMode = false;
        int storeNumber;

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

            setTextBoxLimits();
            
        }

        public CustomerForm(String storeName, String storeDetails, String officeAddress, String shippingAddress, String storeContact, String emailAddress, String phoneNumber
          , String province, String paymentTerms, String shippingInstructions, string rep)
        {
            InitializeComponent();
            List<ProvinceTax> provinceTaxList = ProvinceTaxDatabase.GetAllProvinces();

            Object[] arr = new Object[provinceTaxList.Count];
            for (int i = 0; i < provinceTaxList.Count; i++)
            {
                arr[i] = provinceTaxList[i].provinceTax + " - GST: " + provinceTaxList[i].gst + "%/PST: " + provinceTaxList[i].pst + "%";
            }
            provinceTax_comboBox.Items.AddRange(arr);

            setTextBoxLimits();
            storeName_textBox.Text = storeName;
            storeDetails_textBox.Text = storeDetails;
            parseStringToGroup(officeAddress, groupBox1);
            parseStringToGroup(shippingAddress, groupBox2);
            storeContact_textBox.Text = storeContact;
            email_textBox.Text = emailAddress;
            phoneNumber_textBox.Text = phoneNumber;
            paymentTerms_textBox.Text = paymentTerms;
            shippingInstructions_textBox.Text = shippingInstructions;
            provinceTax_comboBox.Text = provinceTax_comboBox.Items[provinceTax_comboBox.FindString(province)].ToString();
            rep_textBox.Text = rep;
            editMode = true;
            storeNumber = CustomerDatabase.GetStoreID(storeName, shippingAddress);
            
        }

        private void setTextBoxLimits()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if (tb != phoneNumber_textBox)
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

        private String provinceCodeConverter(String province)
        {
            switch (province)
            {
                case "AB":
                    return "Alberta";
                case "BC":
                    return "British Columbia";
                case "MB":
                    return "Manitoba";
                case "NB":
                    return "New Brunswick";
                case "NL":
                    return "Newfoundland and Labrador";
                case "NT":
                    return "Northwest Territories";
                case "NS":
                    return "Nova Scotia";
                case "NU":
                    return "Nunavut";
                case "ON":
                    return "Ontario";
                case "PE":
                    return "Prince Edward Island";
                case "QC":
                    return "Quebec";
                case "SK":
                    return "Saskatchewan";
                case "YT":
                    return "Yukon Territories";
                default:
                    return "";
            }
        }

        private void parseStringToGroup(String str, GroupBox box)
        {
            TextBox street = null, unit = null, city = null, postal = null;
            ComboBox prov =  null;
            foreach (TextBox tb in box.Controls.OfType<TextBox>())
            {
                if (tb.Name.Contains("Street"))
                {
                    street = tb;
                }
                else if (tb.Name.Contains("Unit"))
                {
                    unit = tb;
                }
                else if (tb.Name.Contains("City"))
                {
                    city = tb;
                }
                else
                {
                    postal = tb;
                }
            }

            foreach (ComboBox cb in box.Controls.OfType<ComboBox>())
            {
                prov = cb;
            }

            String[] fields = str.Split(new String[] { " - ", ", ", "  " }, StringSplitOptions.None);
            if(fields.Length == 5)
            {
                unit.Text = fields[0];
                street.Text = fields[1];
                city.Text = fields[2];
                prov.Text = provinceCodeConverter(fields[3]);
                postal.Text = fields[4];
            }
            else
            {
                street.Text = fields[0];
                city.Text = fields[1];
                prov.Text = provinceCodeConverter(fields[2]);
                postal.Text = fields[3];
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Boolean err = false;
            String officeAddress = (officeUnit_textBox.Text != String.Empty ? officeUnit_textBox.Text + " - " : "") + officeStreet_textBox.Text + ", " + 
                officeCity_textBox.Text + ", " + provinceConverter(officeProvince_comboBox.Text) + "  " + officePostal_textBox.Text;


            String shippingAddress = (shippingUnit_textBox.Text != String.Empty ? shippingUnit_textBox.Text + " - " : "") + shippingStreet_textBox.Text + ", " +
                shippingCity_textBox.Text + ", " + provinceConverter(shippingProvince_comboBox.Text) + "  " + shippingPostal_textBox.Text;
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
            if (editMode)
            {
                CustomerDatabase.EditCustomer(storeNumber, storeName_textBox.Text, storeDetails_textBox.Text, email_textBox.Text, officeAddress,
                    shippingAddress, storeContact_textBox.Text, phoneNumber_textBox.Text, paymentTerms_textBox.Text,
                    shippingInstructions_textBox.Text, provinceTax_comboBox.Text.Split(' ')[0], rep_textBox.Text);
            }
            else
            {
                CustomerDatabase.AddCustomer(storeName_textBox.Text, storeDetails_textBox.Text, email_textBox.Text, officeAddress,
                    shippingAddress, storeContact_textBox.Text, phoneNumber_textBox.Text, paymentTerms_textBox.Text,
                    shippingInstructions_textBox.Text, provinceTax_comboBox.Text.Split(' ')[0], rep_textBox.Text);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if(c.Checked)
            {
                shippingUnit_textBox.Text = officeUnit_textBox.Text;
                shippingUnit_textBox.ReadOnly = true;
                shippingStreet_textBox.Text = officeStreet_textBox.Text;
                shippingStreet_textBox.ReadOnly = true;
                shippingCity_textBox.Text = officeCity_textBox.Text;
                shippingCity_textBox.ReadOnly = true;
                shippingProvince_comboBox.SelectedIndex = officeProvince_comboBox.SelectedIndex;
                shippingProvince_comboBox.Enabled = false;
                shippingPostal_textBox.Text = officePostal_textBox.Text;
                shippingPostal_textBox.ReadOnly = true;
            }
            else
            {
                shippingUnit_textBox.ReadOnly = false;
                shippingStreet_textBox.ReadOnly = false;
                shippingCity_textBox.ReadOnly = false;
                shippingProvince_comboBox.Enabled = true;
                shippingPostal_textBox.ReadOnly = false;
            }
        }

        private void officeStreet_textBox_TextChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox) this.Controls["checkBox1"];

            if (c.Checked)
            {
                shippingStreet_textBox.Text = officeStreet_textBox.Text;
            }
        }

        private void officeUnit_textBox_TextChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)this.Controls["checkBox1"];

            if (c.Checked)
            {
                shippingUnit_textBox.Text = officeUnit_textBox.Text;
            }
        }

        private void officeCity_textBox_TextChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)this.Controls["checkBox1"];

            if (c.Checked)
            {
                shippingCity_textBox.Text = officeCity_textBox.Text;
            }
        }

        private void officeProvince_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)this.Controls["checkBox1"];

            if (c.Checked)
            {
                shippingProvince_comboBox.SelectedIndex = officeProvince_comboBox.SelectedIndex;
            }
        }

        private void officePostal_textBox_TextChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)this.Controls["checkBox1"];

            if (c.Checked)
            {
                shippingPostal_textBox.Text = officePostal_textBox.Text;
            }
        }
    }
}
