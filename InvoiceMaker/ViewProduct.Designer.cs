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
            this.CancelProduct = new System.Windows.Forms.Button();
            this.DeleteProduct = new System.Windows.Forms.Button();
            this.ModProduct = new System.Windows.Forms.Button();
            this.productTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ProductView
            // 
            this.ProductView.AutoSize = true;
            this.ProductView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductView.Location = new System.Drawing.Point(876, 25);
            this.ProductView.Name = "ProductView";
            this.ProductView.Size = new System.Drawing.Size(249, 42);
            this.ProductView.TabIndex = 1;
            this.ProductView.Text = "Find Products";
            // 
            // CancelProduct
            // 
            this.CancelProduct.Location = new System.Drawing.Point(0, 0);
            this.CancelProduct.Name = "CancelProduct";
            this.CancelProduct.Size = new System.Drawing.Size(75, 23);
            this.CancelProduct.TabIndex = 11;
            // 
            // DeleteProduct
            // 
            this.DeleteProduct.Location = new System.Drawing.Point(0, 0);
            this.DeleteProduct.Name = "DeleteProduct";
            this.DeleteProduct.Size = new System.Drawing.Size(75, 23);
            this.DeleteProduct.TabIndex = 12;
            // 
            // ModProduct
            // 
            this.ModProduct.Location = new System.Drawing.Point(0, 0);
            this.ModProduct.Name = "ModProduct";
            this.ModProduct.Size = new System.Drawing.Size(75, 23);
            this.ModProduct.TabIndex = 13;
            // 
            // productTextBox
            // 
            this.productTextBox.Location = new System.Drawing.Point(691, 86);
            this.productTextBox.Name = "productTextBox";
            this.productTextBox.Size = new System.Drawing.Size(674, 31);
            this.productTextBox.TabIndex = 10;
            this.productTextBox.TextChanged += new System.EventHandler(this.productTextBox_TextChanged);
            // 
            // ViewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1760, 929);
            this.Controls.Add(this.productTextBox);
            this.Controls.Add(this.CancelProduct);
            this.Controls.Add(this.DeleteProduct);
            this.Controls.Add(this.ModProduct);
            this.Controls.Add(this.ProductView);
            this.Name = "ViewProduct";
            this.Text = "ViewProduct";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ViewProduct_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductView;
        private System.Windows.Forms.Button CancelProduct;
        private System.Windows.Forms.Button DeleteProduct;
        private System.Windows.Forms.Button ModProduct;
        private System.Windows.Forms.TextBox productTextBox;
    }
}