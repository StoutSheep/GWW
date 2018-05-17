namespace InvoiceMaker
{
    partial class ViewCompletedInvoices
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
            this.invoices_textBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // invoices_textBox
            // 
            this.invoices_textBox.Location = new System.Drawing.Point(621, 97);
            this.invoices_textBox.Name = "invoices_textBox";
            this.invoices_textBox.Size = new System.Drawing.Size(660, 31);
            this.invoices_textBox.TabIndex = 4;
            this.invoices_textBox.TextChanged += new System.EventHandler(this.invoices_textBox_TextChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new System.Drawing.Point(811, 35);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(238, 42);
            this.searchLabel.TabIndex = 3;
            this.searchLabel.Text = "Find Invoices";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Invoice #";
            // 
            // ViewCompletedInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1618, 1123);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.invoices_textBox);
            this.Controls.Add(this.searchLabel);
            this.Name = "ViewCompletedInvoices";
            this.Text = "ViewCompletedInvoices";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox invoices_textBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label label1;
    }
}