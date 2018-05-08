namespace InvoiceMaker
{
    partial class ViewCustomer
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
            this.CustomerView = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelCustomer = new System.Windows.Forms.Button();
            this.DeleteCustomer = new System.Windows.Forms.Button();
            this.ModCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerView
            // 
            this.CustomerView.AutoSize = true;
            this.CustomerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerView.Location = new System.Drawing.Point(427, 37);
            this.CustomerView.Name = "CustomerView";
            this.CustomerView.Size = new System.Drawing.Size(262, 42);
            this.CustomerView.TabIndex = 1;
            this.CustomerView.Text = "Find Customer";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(234, 108);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(673, 33);
            this.comboBox1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(63, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 628);
            this.panel1.TabIndex = 3;
            // 
            // CancelCustomer
            // 
            this.CancelCustomer.Location = new System.Drawing.Point(178, 842);
            this.CancelCustomer.Name = "CancelCustomer";
            this.CancelCustomer.Size = new System.Drawing.Size(202, 66);
            this.CancelCustomer.TabIndex = 8;
            this.CancelCustomer.Text = "Cancel";
            this.CancelCustomer.UseVisualStyleBackColor = true;
            this.CancelCustomer.Click += new System.EventHandler(this.CancelCustomer_Click);
            // 
            // DeleteCustomer
            // 
            this.DeleteCustomer.Location = new System.Drawing.Point(766, 842);
            this.DeleteCustomer.Name = "DeleteCustomer";
            this.DeleteCustomer.Size = new System.Drawing.Size(202, 66);
            this.DeleteCustomer.TabIndex = 7;
            this.DeleteCustomer.Text = "Delete";
            this.DeleteCustomer.UseVisualStyleBackColor = true;
            this.DeleteCustomer.Click += new System.EventHandler(this.DeleteCustomer_Click);
            // 
            // ModCustomer
            // 
            this.ModCustomer.Location = new System.Drawing.Point(473, 842);
            this.ModCustomer.Name = "ModCustomer";
            this.ModCustomer.Size = new System.Drawing.Size(202, 66);
            this.ModCustomer.TabIndex = 6;
            this.ModCustomer.Text = "Modify";
            this.ModCustomer.UseVisualStyleBackColor = true;
            this.ModCustomer.Click += new System.EventHandler(this.ModCustomer_Click);
            // 
            // ViewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 929);
            this.Controls.Add(this.CancelCustomer);
            this.Controls.Add(this.DeleteCustomer);
            this.Controls.Add(this.ModCustomer);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CustomerView);
            this.Name = "ViewCustomer";
            this.Text = "ViewCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CustomerView;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CancelCustomer;
        private System.Windows.Forms.Button DeleteCustomer;
        private System.Windows.Forms.Button ModCustomer;
    }
}