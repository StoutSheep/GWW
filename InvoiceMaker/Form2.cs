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
    public partial class Form2 : Form
    {
        public Invoice _invoice;
        public List<InvoiceItemDetail> _list;

        public Form2(Invoice invoice, List<InvoiceItemDetail> list)
        {
            InitializeComponent();
            _invoice = invoice;
            _list = list;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //var invoiceDataSource = new ReportDataSource("InvoiceData", _invoice);
            //Init data source
            InvoiceItemDetailBindingSource.DataSource = _list;
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
                new Microsoft.Reporting.WinForms.ReportParameter("pSubtotal",_invoice.SubTotal.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pGST",_invoice.Gst.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal",_invoice.NetTotal.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pGSTno",_invoice.GSTNo),
            };
            this.reportViewer1.LocalReport.SetParameters(p);

            this.reportViewer1.RefreshReport();
            Console.WriteLine("Done.");
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
