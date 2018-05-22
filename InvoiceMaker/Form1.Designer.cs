namespace InvoiceMaker
{
    partial class Form1
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
            this.AddCustomer = new System.Windows.Forms.Button();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.ViewCustomer = new System.Windows.Forms.Button();
            this.ViewProduct = new System.Windows.Forms.Button();
            this.ProductLabel = new System.Windows.Forms.Label();
            this.AddProduct = new System.Windows.Forms.Button();
            this.ReadProductExcel = new System.Windows.Forms.Button();
            this.ViewInvoice = new System.Windows.Forms.Button();
            this.OrderLabel = new System.Windows.Forms.Label();
            this.AddInvoice = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provinceTaxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.history_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddCustomer
            // 
            this.AddCustomer.Location = new System.Drawing.Point(162, 83);
            this.AddCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddCustomer.Name = "AddCustomer";
            this.AddCustomer.Size = new System.Drawing.Size(75, 42);
            this.AddCustomer.TabIndex = 0;
            this.AddCustomer.Text = "Add";
            this.AddCustomer.UseVisualStyleBackColor = true;
            this.AddCustomer.Click += new System.EventHandler(this.addButton_Click);
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerLabel.Location = new System.Drawing.Point(198, 30);
            this.CustomerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(107, 26);
            this.CustomerLabel.TabIndex = 1;
            this.CustomerLabel.Text = "Customer";
            // 
            // ViewCustomer
            // 
            this.ViewCustomer.Location = new System.Drawing.Point(268, 83);
            this.ViewCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ViewCustomer.Name = "ViewCustomer";
            this.ViewCustomer.Size = new System.Drawing.Size(75, 42);
            this.ViewCustomer.TabIndex = 2;
            this.ViewCustomer.Text = "View/Modify";
            this.ViewCustomer.UseVisualStyleBackColor = true;
            this.ViewCustomer.Click += new System.EventHandler(this.ViewCustomer_Click);
            // 
            // ViewProduct
            // 
            this.ViewProduct.Location = new System.Drawing.Point(217, 199);
            this.ViewProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ViewProduct.Name = "ViewProduct";
            this.ViewProduct.Size = new System.Drawing.Size(75, 42);
            this.ViewProduct.TabIndex = 5;
            this.ViewProduct.Text = "View/Modify";
            this.ViewProduct.UseVisualStyleBackColor = true;
            this.ViewProduct.Click += new System.EventHandler(this.ViewProduct_Click);
            // 
            // ProductLabel
            // 
            this.ProductLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductLabel.AutoSize = true;
            this.ProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductLabel.Location = new System.Drawing.Point(206, 150);
            this.ProductLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Size = new System.Drawing.Size(87, 26);
            this.ProductLabel.TabIndex = 4;
            this.ProductLabel.Text = "Product";
            // 
            // AddProduct
            // 
            this.AddProduct.Location = new System.Drawing.Point(110, 199);
            this.AddProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(75, 42);
            this.AddProduct.TabIndex = 3;
            this.AddProduct.Text = "Add";
            this.AddProduct.UseVisualStyleBackColor = true;
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // ReadProductExcel
            // 
            this.ReadProductExcel.Location = new System.Drawing.Point(319, 199);
            this.ReadProductExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReadProductExcel.Name = "ReadProductExcel";
            this.ReadProductExcel.Size = new System.Drawing.Size(75, 42);
            this.ReadProductExcel.TabIndex = 6;
            this.ReadProductExcel.Text = "Read Excel";
            this.ReadProductExcel.UseVisualStyleBackColor = true;
            this.ReadProductExcel.Click += new System.EventHandler(this.ReadProductExcel_Click);
            // 
            // ViewInvoice
            // 
            this.ViewInvoice.Location = new System.Drawing.Point(217, 321);
            this.ViewInvoice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ViewInvoice.Name = "ViewInvoice";
            this.ViewInvoice.Size = new System.Drawing.Size(75, 42);
            this.ViewInvoice.TabIndex = 9;
            this.ViewInvoice.Text = "View/Modify";
            this.ViewInvoice.UseVisualStyleBackColor = true;
            this.ViewInvoice.Click += new System.EventHandler(this.ViewInvoice_Click);
            // 
            // OrderLabel
            // 
            this.OrderLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OrderLabel.AutoSize = true;
            this.OrderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderLabel.Location = new System.Drawing.Point(206, 277);
            this.OrderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OrderLabel.Name = "OrderLabel";
            this.OrderLabel.Size = new System.Drawing.Size(92, 26);
            this.OrderLabel.TabIndex = 8;
            this.OrderLabel.Text = "Invoices";
            // 
            // AddInvoice
            // 
            this.AddInvoice.Location = new System.Drawing.Point(110, 321);
            this.AddInvoice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddInvoice.Name = "AddInvoice";
            this.AddInvoice.Size = new System.Drawing.Size(75, 42);
            this.AddInvoice.TabIndex = 7;
            this.AddInvoice.Text = "New";
            this.AddInvoice.UseVisualStyleBackColor = true;
            this.AddInvoice.Click += new System.EventHandler(this.AddInvoice_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(548, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.provinceTaxesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.fileToolStripMenuItem.Text = "Taxes";
            // 
            // provinceTaxesToolStripMenuItem
            // 
            this.provinceTaxesToolStripMenuItem.Name = "provinceTaxesToolStripMenuItem";
            this.provinceTaxesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.provinceTaxesToolStripMenuItem.Text = "Province Taxes";
            this.provinceTaxesToolStripMenuItem.Click += new System.EventHandler(this.provinceTaxesToolStripMenuItem_Click);
            // 
            // history_button
            // 
            this.history_button.Location = new System.Drawing.Point(319, 321);
            this.history_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.history_button.Name = "history_button";
            this.history_button.Size = new System.Drawing.Size(75, 42);
            this.history_button.TabIndex = 11;
            this.history_button.Text = "History";
            this.history_button.UseVisualStyleBackColor = true;
            this.history_button.Click += new System.EventHandler(this.history_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 458);
            this.Controls.Add(this.history_button);
            this.Controls.Add(this.ViewInvoice);
            this.Controls.Add(this.OrderLabel);
            this.Controls.Add(this.AddInvoice);
            this.Controls.Add(this.ReadProductExcel);
            this.Controls.Add(this.ViewProduct);
            this.Controls.Add(this.ProductLabel);
            this.Controls.Add(this.AddProduct);
            this.Controls.Add(this.ViewCustomer);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.AddCustomer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddCustomer;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Button ViewCustomer;
        private System.Windows.Forms.Button ViewProduct;
        private System.Windows.Forms.Label ProductLabel;
        private System.Windows.Forms.Button AddProduct;
        private System.Windows.Forms.Button ReadProductExcel;
        private System.Windows.Forms.Button ViewInvoice;
        private System.Windows.Forms.Label OrderLabel;
        private System.Windows.Forms.Button AddInvoice;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provinceTaxesToolStripMenuItem;
        private System.Windows.Forms.Button history_button;
    }
}

