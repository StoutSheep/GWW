﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceMaker
{
    public partial class PrintInvoiceReport : Form
    {
        public Invoice _invoice;
        public List<InvoiceItemDetail> _list;

        public PrintInvoiceReport(Invoice invoice, List<InvoiceItemDetail> list)
        {
            InitializeComponent();
            _invoice = invoice;
            _list = list;
        }

        private void InvoiceReport_Load(object sender, EventArgs e)
        {
            //Init data source
            //InvoiceItemDetailBindingSource.DataSource = _list;
            //Set parameter for your report
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyName",_invoice.CompanyName),
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyAddress",_invoice.CompanyAddress),
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyPhoneNumber",_invoice.CompanyPhoneNumber),
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyFax",_invoice.CompanyFax),
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyTollFree",_invoice.CompanyTollFree),
                new Microsoft.Reporting.WinForms.ReportParameter("pInvoiceNumber",_invoice.InvoiceNo.ToString()),
                //new Microsoft.Reporting.WinForms.ReportParameter("pDate",_invoice.CompanyName),
                new Microsoft.Reporting.WinForms.ReportParameter("pTerms",_invoice.CustomerTerms),
                new Microsoft.Reporting.WinForms.ReportParameter("pShippingTerms",_invoice.CustomerShippingTerms),
                new Microsoft.Reporting.WinForms.ReportParameter("pPurchaseOrder",_invoice.PurchaseOrder),
                new Microsoft.Reporting.WinForms.ReportParameter("pSpecialNotes",_invoice.SpecialNotes),
                new Microsoft.Reporting.WinForms.ReportParameter("pStoreName",_invoice.CustomerName),
                new Microsoft.Reporting.WinForms.ReportParameter("pStoreContact",_invoice.CustomerContact),
                new Microsoft.Reporting.WinForms.ReportParameter("pStoreAddress",_invoice.CustomerAddress),
                new Microsoft.Reporting.WinForms.ReportParameter("pStorePhone",_invoice.CustomerPhone),
                new Microsoft.Reporting.WinForms.ReportParameter("pSubTotal",_invoice.SubTotal.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pGST",_invoice.Gst.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal",_invoice.NetTotal.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pGSTno",_invoice.GSTNo),
            };
            this.reportViewer.LocalReport.SetParameters(p);

            this.reportViewer.RefreshReport();
            Console.WriteLine("Done.");
        }


        //TODO: Query all invoice items based on Invoice IDS
        //SELECT invoicecontents.InvoiceID, invoicecontents.Quantity, invoicecontents.Quantity/products.PerCarton AS 'Grab Carton', products.Location, products.ItemDesc, products.PerCarton, products.SellPrice, invoicecontents.Quantity* products.SellPrice AS 'Amount' from invoicecontents
        //NATURAL JOIN products;

    }
}
