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
            
            Product prod = new Product("", "", 0, "", 0, 0, 0);
            int tempCart;
            Int64 tempUPC;
            float tempCost, tempPrice;
            Workbook ex = Workbook.Load(file);
            Worksheet worksheet = ex.Worksheets[0];
            int maxRow = worksheet.Cells.Rows.Count;
            double readProgress = 100d / maxRow;
            int lastrow = 0;
            for (int row = 4; row < maxRow; ++row)
            {
                prod.ItemNo = worksheet.Cells[row, 0].Value.ToString();
                prod.Location = worksheet.Cells[row, 1].Value.ToString();
                prod.ItemDesc = worksheet.Cells[row, 2].Value.ToString();
                if (worksheet.Cells[row, 3].Value != null && Int32.TryParse(worksheet.Cells[row, 3].Value.ToString(), out tempCart))
                {
                    prod.PerCarton = tempCart;
                }
                else
                {
                    prod.PerCarton = 1;
                }
                if (worksheet.Cells[row, 4].Value != null && Single.TryParse(worksheet.Cells[row, 4].Value.ToString(), out tempCost))
                {
                    prod.Cost = tempCost;
                }
                else
                {
                    prod.Cost = 0;
                }
                if (worksheet.Cells[row, 5].Value != null && Single.TryParse(worksheet.Cells[row, 5].Value.ToString(), out tempPrice))
                {
                    prod.SellPrice = tempPrice;
                }
                else
                {
                    prod.SellPrice = 0;
                }
                if (worksheet.Cells[row, 6].Value != null && Int64.TryParse(worksheet.Cells[row, 6].Value.ToString(), out tempUPC))
                {
                    prod.UPC = tempUPC;
                }
                else
                {
                    prod.UPC = 0;
                }
                if (Program.SearchProductsByItemNo(prod.ItemNo).Count == 0)
                    Program.AddProduct(prod.ItemNo, prod.ItemDesc, prod.PerCarton, prod.Location, prod.Cost, prod.SellPrice, prod.UPC);
                else
                    Program.EditProduct(prod.ItemNo, prod.ItemNo, prod.ItemDesc, prod.PerCarton, prod.Location, prod.Cost, prod.SellPrice, prod.UPC);
                backgroundWorker1.ReportProgress((int)(readProgress * row));
                lastrow = row;
            }
            Debug.Print("Last Row is " + lastrow);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            this.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
