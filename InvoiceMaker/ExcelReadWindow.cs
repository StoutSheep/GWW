using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;

namespace InvoiceMaker
{
    public partial class ExcelReadWindow : Form
    {
        
        String file;
        public ExcelReadWindow(String excelFile)
        {
            
            InitializeComponent();
            file = excelFile;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
            Product prod = new Product("", "", 0, "", 0, 0, "");
            int tempCart;
            float tempCost;
            Workbook ex = Workbook.Load(file);
            Worksheet worksheet = ex.Worksheets[0];
            int maxRow = worksheet.Cells.Rows.Count;
            double readProgress = 100d / maxRow;
            for (int row = 4; row < maxRow; ++row)
            {
                prod.ItemNumber = worksheet.Cells[row, 0].Value.ToString();
                prod.WarehouseLocation = worksheet.Cells[row, 1].Value.ToString();
                prod.ItemDescription = worksheet.Cells[row, 2].Value.ToString();
                if (worksheet.Cells[row, 3].Value != null && Int32.TryParse(worksheet.Cells[row, 3].Value.ToString(), out tempCart))
                {
                    prod.CartonTotal = tempCart;
                }
                else
                {
                    prod.CartonTotal = 1;
                }
                if (worksheet.Cells[row, 4].Value != null && Single.TryParse(worksheet.Cells[row, 4].Value.ToString(), out tempCost))
                {
                    prod.WholesaleCost = tempCost;
                }
                else
                {
                    prod.WholesaleCost = 0;
                }
                if (worksheet.Cells[row, 5].Value != null)
                    prod.UPC = worksheet.Cells[row, 5].Value.ToString();
                else
                    prod.UPC = null;
                Program.AddProduct(prod.ItemNumber, prod.ItemDescription, prod.CartonTotal, prod.WarehouseLocation, prod.WholesaleCost, prod.SalePrice, prod.UPC);
                int stuff = (int)readProgress * row;
                Debug.Print(stuff + "");
                backgroundWorker1.ReportProgress((int)(readProgress * row));
            }*/
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            this.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //Debug.Print(progressBar1.Value+"");
           // progressBar1.Update();
        }
    }
}
