namespace InvoiceMaker
{
    partial class ViewProduct
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
            this.ProductView = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelProduct = new System.Windows.Forms.Button();
            this.DeleteProduct = new System.Windows.Forms.Button();
            this.ModProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProductView
            // 
            this.ProductView.AutoSize = true;
            this.ProductView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductView.Location = new System.Drawing.Point(424, 31);
            this.ProductView.Name = "ProductView";
            this.ProductView.Size = new System.Drawing.Size(249, 42);
            this.ProductView.TabIndex = 1;
            this.ProductView.Text = "Find Products";
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
            // CancelProduct
            // 
            this.CancelProduct.Location = new System.Drawing.Point(195, 842);
            this.CancelProduct.Name = "CancelProduct";
            this.CancelProduct.Size = new System.Drawing.Size(202, 66);
            this.CancelProduct.TabIndex = 8;
            this.CancelProduct.Text = "Cancel";
            this.CancelProduct.UseVisualStyleBackColor = true;
            this.CancelProduct.Click += new System.EventHandler(this.CancelProduct_Click);
            // 
            // DeleteProduct
            // 
            this.DeleteProduct.Location = new System.Drawing.Point(783, 842);
            this.DeleteProduct.Name = "DeleteProduct";
            this.DeleteProduct.Size = new System.Drawing.Size(202, 66);
            this.DeleteProduct.TabIndex = 7;
            this.DeleteProduct.Text = "Delete";
            this.DeleteProduct.UseVisualStyleBackColor = true;
            this.DeleteProduct.Click += new System.EventHandler(this.DeleteProduct_Click);
            // 
            // ModProduct
            // 
            this.ModProduct.Location = new System.Drawing.Point(490, 842);
            this.ModProduct.Name = "ModProduct";
            this.ModProduct.Size = new System.Drawing.Size(202, 66);
            this.ModProduct.TabIndex = 6;
            this.ModProduct.Text = "Modify";
            this.ModProduct.UseVisualStyleBackColor = true;
            this.ModProduct.Click += new System.EventHandler(this.ModProduct_Click);
            // 
            // ViewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 929);
            this.Controls.Add(this.CancelProduct);
            this.Controls.Add(this.DeleteProduct);
            this.Controls.Add(this.ModProduct);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ProductView);
            this.Name = "ViewProduct";
            this.Text = "ViewProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductView;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CancelProduct;
        private System.Windows.Forms.Button DeleteProduct;
        private System.Windows.Forms.Button ModProduct;
    }
}