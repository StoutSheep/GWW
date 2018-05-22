namespace InvoiceMaker
{
    partial class SelectCustomer
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
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.CustomerView = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(895, 98);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(674, 31);
            this.customerTextBox.TabIndex = 13;
            this.customerTextBox.TextChanged += new System.EventHandler(this.customerTextBox_TextChanged);
            // 
            // CustomerView
            // 
            this.CustomerView.AutoSize = true;
            this.CustomerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerView.Location = new System.Drawing.Point(1080, 37);
            this.CustomerView.Name = "CustomerView";
            this.CustomerView.Size = new System.Drawing.Size(262, 42);
            this.CustomerView.TabIndex = 12;
            this.CustomerView.Text = "Find Customer";
            // 
            // SelectCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1840, 1007);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.CustomerView);
            this.Name = "SelectCustomer";
            this.Text = "SelectCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Label CustomerView;
    }
}