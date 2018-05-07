namespace InvoiceMaker
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.storeName_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.officeProvince_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.officePostal_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.officeCity_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.officeUnit_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.officeStreet_textBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shippingPostal_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.shippingCity_textBox = new System.Windows.Forms.TextBox();
            this.shippingProvince_comboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.shippingUnit_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.shippingStreet_textBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.storeContact_textBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.phoneNumber_textBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.paymentTerms_textBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.shippingInstructions_textBox = new System.Windows.Forms.RichTextBox();
            this.specialNotes_textBox = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(731, 1012);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.okButton_Click);
            // 
            // storeName_textBox
            // 
            this.storeName_textBox.Location = new System.Drawing.Point(74, 46);
            this.storeName_textBox.Name = "storeName_textBox";
            this.storeName_textBox.Size = new System.Drawing.Size(556, 31);
            this.storeName_textBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Store Name";
            // 
            // officeProvince_comboBox
            // 
            this.officeProvince_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.officeProvince_comboBox.FormattingEnabled = true;
            this.officeProvince_comboBox.Items.AddRange(new object[] {
            "Alberta",
            "British Columbia",
            "Manitoba",
            "New Brunswick",
            "Newfoundland and Labrador",
            "Nova Scotia",
            "Northwest Territories",
            "Nunavut",
            "Ontario",
            "Prince Edward Island",
            "Quebec",
            "Saskatchewan",
            "Yukon Territories"});
            this.officeProvince_comboBox.Location = new System.Drawing.Point(242, 131);
            this.officeProvince_comboBox.Name = "officeProvince_comboBox";
            this.officeProvince_comboBox.Size = new System.Drawing.Size(281, 33);
            this.officeProvince_comboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Street";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.officePostal_textBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.officeCity_textBox);
            this.groupBox1.Controls.Add(this.officeProvince_comboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.officeUnit_textBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.officeStreet_textBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(74, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 184);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Office Address";
            // 
            // officePostal_textBox
            // 
            this.officePostal_textBox.Location = new System.Drawing.Point(548, 133);
            this.officePostal_textBox.Name = "officePostal_textBox";
            this.officePostal_textBox.Size = new System.Drawing.Size(161, 31);
            this.officePostal_textBox.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(543, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 25);
            this.label10.TabIndex = 11;
            this.label10.Text = "Postal Code";
            // 
            // officeCity_textBox
            // 
            this.officeCity_textBox.Location = new System.Drawing.Point(11, 133);
            this.officeCity_textBox.Name = "officeCity_textBox";
            this.officeCity_textBox.Size = new System.Drawing.Size(216, 31);
            this.officeCity_textBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Province";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "City";
            // 
            // officeUnit_textBox
            // 
            this.officeUnit_textBox.Location = new System.Drawing.Point(573, 66);
            this.officeUnit_textBox.Name = "officeUnit_textBox";
            this.officeUnit_textBox.Size = new System.Drawing.Size(136, 31);
            this.officeUnit_textBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(568, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Unit #";
            // 
            // officeStreet_textBox
            // 
            this.officeStreet_textBox.Location = new System.Drawing.Point(11, 66);
            this.officeStreet_textBox.Name = "officeStreet_textBox";
            this.officeStreet_textBox.Size = new System.Drawing.Size(545, 31);
            this.officeStreet_textBox.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shippingPostal_textBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.shippingCity_textBox);
            this.groupBox2.Controls.Add(this.shippingProvince_comboBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.shippingUnit_textBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.shippingStreet_textBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(74, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 184);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shipping Address";
            // 
            // shippingPostal_textBox
            // 
            this.shippingPostal_textBox.Location = new System.Drawing.Point(548, 133);
            this.shippingPostal_textBox.Name = "shippingPostal_textBox";
            this.shippingPostal_textBox.Size = new System.Drawing.Size(161, 31);
            this.shippingPostal_textBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(543, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Postal Code";
            // 
            // shippingCity_textBox
            // 
            this.shippingCity_textBox.Location = new System.Drawing.Point(11, 133);
            this.shippingCity_textBox.Name = "shippingCity_textBox";
            this.shippingCity_textBox.Size = new System.Drawing.Size(216, 31);
            this.shippingCity_textBox.TabIndex = 9;
            // 
            // shippingProvince_comboBox
            // 
            this.shippingProvince_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shippingProvince_comboBox.FormattingEnabled = true;
            this.shippingProvince_comboBox.Items.AddRange(new object[] {
            "Alberta",
            "British Columbia",
            "Manitoba",
            "New Brunswick",
            "Newfoundland and Labrador",
            "Nova Scotia",
            "Northwest Territories",
            "Nunavut",
            "Ontario",
            "Prince Edward Island",
            "Quebec",
            "Saskatchewan",
            "Yukon Territories"});
            this.shippingProvince_comboBox.Location = new System.Drawing.Point(242, 131);
            this.shippingProvince_comboBox.Name = "shippingProvince_comboBox";
            this.shippingProvince_comboBox.Size = new System.Drawing.Size(281, 33);
            this.shippingProvince_comboBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Province";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "City";
            // 
            // shippingUnit_textBox
            // 
            this.shippingUnit_textBox.Location = new System.Drawing.Point(573, 66);
            this.shippingUnit_textBox.Name = "shippingUnit_textBox";
            this.shippingUnit_textBox.Size = new System.Drawing.Size(136, 31);
            this.shippingUnit_textBox.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(568, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Unit #";
            // 
            // shippingStreet_textBox
            // 
            this.shippingStreet_textBox.Location = new System.Drawing.Point(11, 66);
            this.shippingStreet_textBox.Name = "shippingStreet_textBox";
            this.shippingStreet_textBox.Size = new System.Drawing.Size(545, 31);
            this.shippingStreet_textBox.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 25);
            this.label11.TabIndex = 5;
            this.label11.Text = "Street";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(74, 506);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 25);
            this.label12.TabIndex = 8;
            this.label12.Text = "Store Contact";
            // 
            // storeContact_textBox
            // 
            this.storeContact_textBox.Location = new System.Drawing.Point(74, 534);
            this.storeContact_textBox.Name = "storeContact_textBox";
            this.storeContact_textBox.Size = new System.Drawing.Size(333, 31);
            this.storeContact_textBox.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(431, 506);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 25);
            this.label13.TabIndex = 10;
            this.label13.Text = "Phone Number";
            // 
            // phoneNumber_textBox
            // 
            this.phoneNumber_textBox.Location = new System.Drawing.Point(436, 533);
            this.phoneNumber_textBox.Name = "phoneNumber_textBox";
            this.phoneNumber_textBox.Size = new System.Drawing.Size(347, 31);
            this.phoneNumber_textBox.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(74, 582);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(162, 25);
            this.label14.TabIndex = 14;
            this.label14.Text = "Payment Terms";
            // 
            // paymentTerms_textBox
            // 
            this.paymentTerms_textBox.Location = new System.Drawing.Point(74, 610);
            this.paymentTerms_textBox.Name = "paymentTerms_textBox";
            this.paymentTerms_textBox.Size = new System.Drawing.Size(709, 31);
            this.paymentTerms_textBox.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(74, 664);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(212, 25);
            this.label15.TabIndex = 16;
            this.label15.Text = "Shipping Instructions";
            // 
            // shippingInstructions_textBox
            // 
            this.shippingInstructions_textBox.Location = new System.Drawing.Point(74, 693);
            this.shippingInstructions_textBox.Name = "shippingInstructions_textBox";
            this.shippingInstructions_textBox.Size = new System.Drawing.Size(716, 108);
            this.shippingInstructions_textBox.TabIndex = 15;
            this.shippingInstructions_textBox.Text = "";
            // 
            // specialNotes_textBox
            // 
            this.specialNotes_textBox.Location = new System.Drawing.Point(69, 854);
            this.specialNotes_textBox.Name = "specialNotes_textBox";
            this.specialNotes_textBox.Size = new System.Drawing.Size(716, 108);
            this.specialNotes_textBox.TabIndex = 19;
            this.specialNotes_textBox.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(69, 825);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(145, 25);
            this.label16.TabIndex = 18;
            this.label16.Text = "Special Notes";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(591, 1012);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 59);
            this.button2.TabIndex = 20;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 1131);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.specialNotes_textBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.shippingInstructions_textBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.paymentTerms_textBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.phoneNumber_textBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.storeContact_textBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.storeName_textBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomerForm";
            this.Text = "New Customer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox storeName_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox officeProvince_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox officeStreet_textBox;
        private System.Windows.Forms.TextBox officeCity_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox officeUnit_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox officePostal_textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox shippingPostal_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox shippingCity_textBox;
        private System.Windows.Forms.ComboBox shippingProvince_comboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox shippingUnit_textBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox shippingStreet_textBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox storeContact_textBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox phoneNumber_textBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox paymentTerms_textBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox shippingInstructions_textBox;
        private System.Windows.Forms.RichTextBox specialNotes_textBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button2;
    }
}