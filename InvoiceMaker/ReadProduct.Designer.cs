namespace InvoiceMaker
{
    partial class ReadProduct
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BrowseExcelProduct = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReadProductError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(597, 31);
            this.textBox1.TabIndex = 0;
            // 
            // BrowseExcelProduct
            // 
            this.BrowseExcelProduct.Location = new System.Drawing.Point(665, 65);
            this.BrowseExcelProduct.Name = "BrowseExcelProduct";
            this.BrowseExcelProduct.Size = new System.Drawing.Size(224, 62);
            this.BrowseExcelProduct.TabIndex = 1;
            this.BrowseExcelProduct.Text = "Browse";
            this.BrowseExcelProduct.UseVisualStyleBackColor = true;
            this.BrowseExcelProduct.Click += new System.EventHandler(this.BrowseExcelProduct_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(40, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 551);
            this.panel1.TabIndex = 2;
            // 
            // ReadProductError
            // 
            this.ReadProductError.AutoSize = true;
            this.ReadProductError.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadProductError.Location = new System.Drawing.Point(42, 134);
            this.ReadProductError.Name = "ReadProductError";
            this.ReadProductError.Size = new System.Drawing.Size(119, 42);
            this.ReadProductError.TabIndex = 3;
            this.ReadProductError.Text = "Errors";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(484, 51);
            this.label2.TabIndex = 4;
            this.label2.Text = "Read Product Excel File";
            // 
            // CancelRead
            // 
            this.CancelRead.Location = new System.Drawing.Point(454, 784);
            this.CancelRead.Name = "CancelRead";
            this.CancelRead.Size = new System.Drawing.Size(165, 51);
            this.CancelRead.TabIndex = 5;
            this.CancelRead.Text = "Cancel";
            this.CancelRead.UseVisualStyleBackColor = true;
            this.CancelRead.Click += new System.EventHandler(this.CancelRead_Click);
            // 
            // ReadProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 874);
            this.Controls.Add(this.CancelRead);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReadProductError);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BrowseExcelProduct);
            this.Controls.Add(this.textBox1);
            this.Name = "ReadProduct";
            this.Text = "ReadProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BrowseExcelProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ReadProductError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelRead;
    }
}