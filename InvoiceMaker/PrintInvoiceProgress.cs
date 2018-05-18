using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace InvoiceMaker
{
    public partial class PrintInvoiceProgress : Form
    {
        public Invoice _invoice;
        public List<InvoiceItemDetail> _list;

        public PrintInvoiceProgress(Invoice invoice, List<InvoiceItemDetail> list)
        {
            InitializeComponent();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.SetDisplayMode(DisplayMode.Normal);

            _invoice = invoice;
            _list = list;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Variables needed for ReportViewer Render method
            Warning[] warnings;
            string[] streamids;
            string mimeType, encoding, extension;
            string ExcelFileName = @"C:\Invoices\Excel\"+_invoice.InvoiceID + ".xlsx";
            string PDFFileName = @"C:\Invoices\PDF\" + _invoice.InvoiceID + ".pdf";

            Directory.CreateDirectory(Path.GetDirectoryName(ExcelFileName));
            Directory.CreateDirectory(Path.GetDirectoryName(PDFFileName));

            //Init data source
            InvoiceItemDetailBindingSource.DataSource = _list;

            String address = _invoice.CustomerAddress;
            String[] words = address.Split(',');

            String customerStreet = words[0].TrimStart();
            String customerProvince = words[1].TrimStart();
            String customerPostal = words[2].TrimStart();

            ProvinceTax provinceTax = ProvinceTaxDatabase.GetProvinceByName(_invoice.customer.Province);

            //Set parameter for your report
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyName",_invoice.CompanyName),
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyAddress",_invoice.CompanyAddress),
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyPhoneNumber",_invoice.CompanyPhoneNumber),
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyFax",_invoice.CompanyFax),
                new Microsoft.Reporting.WinForms.ReportParameter("pCompanyTollFree",_invoice.CompanyTollFree),

                new Microsoft.Reporting.WinForms.ReportParameter("pInvoiceNumber",_invoice.InvoiceNo.ToString()),

                new Microsoft.Reporting.WinForms.ReportParameter("pStoreName",_invoice.CustomerName),
                new Microsoft.Reporting.WinForms.ReportParameter("pStoreContact",_invoice.CustomerContact),
                new Microsoft.Reporting.WinForms.ReportParameter("pTerms",_invoice.CustomerTerms),
                new Microsoft.Reporting.WinForms.ReportParameter("pShippingTerms",_invoice.CustomerShippingTerms),
                new Microsoft.Reporting.WinForms.ReportParameter("pPurchaseOrder",_invoice.PurchaseOrder),
                new Microsoft.Reporting.WinForms.ReportParameter("pSpecialNotes",_invoice.SpecialNotes),

                new Microsoft.Reporting.WinForms.ReportParameter("pStoreStreet",customerStreet),
                new Microsoft.Reporting.WinForms.ReportParameter("pStoreProvince",customerProvince),
                new Microsoft.Reporting.WinForms.ReportParameter("pStorePostal",customerPostal),
                new Microsoft.Reporting.WinForms.ReportParameter("pStorePhone",_invoice.CustomerPhone),

                new Microsoft.Reporting.WinForms.ReportParameter("pSubtotal",_invoice.SubTotal.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pGSTPercent",provinceTax.gst.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pGST",_invoice.Gst.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pPSTPercent",provinceTax.pst.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pPST",_invoice.Pst.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal",_invoice.NetTotal.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pGSTno",_invoice.GSTNo),
                new Microsoft.Reporting.WinForms.ReportParameter("pBackorderNotes",_invoice.BackorderNotes),
                new Microsoft.Reporting.WinForms.ReportParameter("pSalesRep",_invoice.customer.Rep),
                new Microsoft.Reporting.WinForms.ReportParameter("pBackorderNotes",_invoice.BackorderNotes),

                new Microsoft.Reporting.WinForms.ReportParameter("pFreight",_invoice.freight.ToString()),
            };
            this.reportViewer1.LocalReport.SetParameters(p);

            this.reportViewer1.RefreshReport();

            FileStream newFile = new FileStream(ExcelFileName, FileMode.Create);

            string renderFormat = (ExcelFileName.EndsWith(".xlsx") ? "EXCELOPENXML" : "Excel");
            byte[] bytes = this.reportViewer1.LocalReport.Render(renderFormat, null, out mimeType, out encoding, out extension, out streamids, out warnings);
            newFile.Write(bytes, 0, bytes.Length);
            newFile.Close();


            Byte[] mybytes = this.reportViewer1.LocalReport.Render("PDF");
            using (FileStream fs = File.Create(PDFFileName))
            {
                fs.Write(mybytes, 0, mybytes.Length);
            }
            
        }

    }
}
