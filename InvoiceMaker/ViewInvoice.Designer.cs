namespace InvoiceMaker
{
    partial class ViewInvoice
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
            this.InvoiceView = new System.Windows.Forms.Label();
            this.invoices_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InvoiceView
            // 
            this.InvoiceView.AutoSize = true;
            this.InvoiceView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceView.Location = new System.Drawing.Point(1049, 35);
            this.InvoiceView.Name = "InvoiceView";
            this.InvoiceView.Size = new System.Drawing.Size(238, 42);
            this.InvoiceView.TabIndex = 0;
            this.InvoiceView.Text = "Find Invoices";
            // 
            // invoices_textBox
            // 
            this.invoices_textBox.Location = new System.Drawing.Point(859, 97);
            this.invoices_textBox.Name = "invoices_textBox";
            this.invoices_textBox.Size = new System.Drawing.Size(660, 31);
            this.invoices_textBox.TabIndex = 2;
            // 
            // ViewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1804, 929);
            this.Controls.Add(this.invoices_textBox);
            this.Controls.Add(this.InvoiceView);
            this.Name = "ViewInvoice";
            this.Text = "ViewInvoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InvoiceView;
        private System.Windows.Forms.TextBox invoices_textBox;
    }
}