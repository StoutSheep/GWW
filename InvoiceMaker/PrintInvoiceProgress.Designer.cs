namespace InvoiceMaker
{
    partial class PrintInvoiceProgress
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InvoiceItemDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceItemDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "InvoiceData";
            reportDataSource1.Value = this.InvoiceItemDetailBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InvoiceMaker.InvoiceReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1792, 970);
            this.reportViewer1.TabIndex = 0;
            // 
            // InvoiceItemDetailBindingSource
            // 
            this.InvoiceItemDetailBindingSource.DataSource = typeof(InvoiceMaker.InvoiceItemDetail);
            // 
            // CustomerBindingSource
            // 
            this.CustomerBindingSource.DataSource = typeof(InvoiceMaker.Customer);
            // 
            // PrintInvoiceProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 984);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintInvoiceProgress";
            this.Text = "Invoice In Progress";
            this.Load += new System.EventHandler(this.PrintInvoiceProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceItemDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CustomerBindingSource;
        private System.Windows.Forms.BindingSource InvoiceItemDetailBindingSource;
    }
}