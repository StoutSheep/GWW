using Microsoft.Reporting.WinForms;
using System;
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
        }

        private void reportViewer_Load(object sender, EventArgs e)
        {

            var reportDataSource = new ReportDataSource("InvoiceItemData", _list);
            ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new ReportParameter("pCompanyName",_invoice.CompanyName),
                //new ReportParameter("pCompanyAddress",_invoice.CompanyAddress),
                //new ReportParameter("pCompanyPhoneNumber",_invoice.CompanyPhoneNumber),
                //new ReportParameter("pCompanyFax",_invoice.CompanyFax),
                //new ReportParameter("pCompanyTollFree",_invoice.CompanyTollFree),
                //new ReportParameter("pInvoiceNumber",_invoice.InvoiceNo.ToString()),
                //new ReportParameter("pTerms",_invoice.CustomerTerms),
                //new ReportParameter("pShippingTerms",_invoice.CustomerShippingTerms),
                //new ReportParameter("pPurchaseOrder",_invoice.PurchaseOrder),
                //new ReportParameter("pSpecialNotes",_invoice.SpecialNotes),
                //new ReportParameter("pStoreName",_invoice.CustomerName),
                //new ReportParameter("pStoreContact",_invoice.CustomerContact),
                //new ReportParameter("pStoreAddress",_invoice.CustomerAddress),
                //new ReportParameter("pStorePhone",_invoice.CustomerPhone),
                //new ReportParameter("pSubtotal",_invoice.SubTotal.ToString()),
                //new ReportParameter("pGST",_invoice.Gst.ToString()),
                //new ReportParameter("pTotal",_invoice.NetTotal.ToString()),
                //new ReportParameter("pGSTno",_invoice.GSTNo),
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
