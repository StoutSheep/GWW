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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ModInvoice = new System.Windows.Forms.Button();
            this.DeleteInvoice = new System.Windows.Forms.Button();
            this.CancelInvoice = new System.Windows.Forms.Button();
            this.PrintInvoice = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // InvoiceView
            // 
            this.InvoiceView.AutoSize = true;
            this.InvoiceView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceView.Location = new System.Drawing.Point(425, 39);
            this.InvoiceView.Name = "InvoiceView";
            this.InvoiceView.Size = new System.Drawing.Size(238, 42);
            this.InvoiceView.TabIndex = 0;
            this.InvoiceView.Text = "Find Invoices";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(247, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(660, 31);
            this.textBox1.TabIndex = 2;
            // 
            // ModInvoice
            // 
            this.ModInvoice.Location = new System.Drawing.Point(291, 841);
            this.ModInvoice.Name = "ModInvoice";
            this.ModInvoice.Size = new System.Drawing.Size(202, 66);
            this.ModInvoice.TabIndex = 3;
            this.ModInvoice.Text = "Modify";
            this.ModInvoice.UseVisualStyleBackColor = true;
            this.ModInvoice.Click += new System.EventHandler(this.ModInvoice_Click);
            // 
            // DeleteInvoice
            // 
            this.DeleteInvoice.Location = new System.Drawing.Point(522, 841);
            this.DeleteInvoice.Name = "DeleteInvoice";
            this.DeleteInvoice.Size = new System.Drawing.Size(202, 66);
            this.DeleteInvoice.TabIndex = 4;
            this.DeleteInvoice.Text = "Delete";
            this.DeleteInvoice.UseVisualStyleBackColor = true;
            this.DeleteInvoice.Click += new System.EventHandler(this.DeleteInvoice_Click);
            // 
            // CancelInvoice
            // 
            this.CancelInvoice.Location = new System.Drawing.Point(62, 841);
            this.CancelInvoice.Name = "CancelInvoice";
            this.CancelInvoice.Size = new System.Drawing.Size(202, 66);
            this.CancelInvoice.TabIndex = 5;
            this.CancelInvoice.Text = "Cancel";
            this.CancelInvoice.UseVisualStyleBackColor = true;
            this.CancelInvoice.Click += new System.EventHandler(this.button2_Click);
            // 
            // PrintInvoice
            // 
            this.PrintInvoice.Location = new System.Drawing.Point(908, 841);
            this.PrintInvoice.Name = "PrintInvoice";
            this.PrintInvoice.Size = new System.Drawing.Size(202, 66);
            this.PrintInvoice.TabIndex = 6;
            this.PrintInvoice.Text = "View";
            this.PrintInvoice.UseVisualStyleBackColor = true;
            this.PrintInvoice.Click += new System.EventHandler(this.ViewInvoice_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(2642, 630);
            this.dataGridView1.TabIndex = 7;
            // 
            // ViewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2855, 1275);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PrintInvoice);
            this.Controls.Add(this.CancelInvoice);
            this.Controls.Add(this.DeleteInvoice);
            this.Controls.Add(this.ModInvoice);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.InvoiceView);
            this.Name = "ViewInvoice";
            this.Text = "ViewInvoice";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InvoiceView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ModInvoice;
        private System.Windows.Forms.Button DeleteInvoice;
        private System.Windows.Forms.Button CancelInvoice;
        private System.Windows.Forms.Button PrintInvoice;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}