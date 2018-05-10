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
        internal List<String> errors;
        public ExcelReadWindow(String excelFile)
        {
            
            InitializeComponent();
            file = excelFile;
            errors = new List<String>();
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
            for (int row = 4; row < maxRow; ++row)
            {
                String errmsg = String.Empty;
                prod.ItemNo = worksheet.Cells[row, 0].Value.ToString();
                if (worksheet.Cells[row, 1].Value != null && worksheet.Cells[row, 1].Value.ToString().Length < 10)
                {
                    prod.Location = worksheet.Cells[row, 1].Value.ToString();
                }
                else
                {
                    errmsg += "Invalid Location: " + worksheet.Cells[row, 1].Value + " ";
                }
                
                if(worksheet.Cells[row, 2].Value != null && worksheet.Cells[row, 2].Value.ToString().Length < 50)
                {
                    prod.ItemDesc = worksheet.Cells[row, 2].Value.ToString();
                }
                else
                {
                    errmsg += "Invalid Description: " + worksheet.Cells[row, 2].Value + " ";
                }
                if (worksheet.Cells[row, 3].Value != null && Int32.TryParse(worksheet.Cells[row, 3].Value.ToString(), out tempCart))
                {
                    prod.PerCarton = tempCart;
                }
                else
                {
                    errmsg += "Invalid Carton: " + worksheet.Cells[row, 3].Value + " ";
                }
                if (worksheet.Cells[row, 4].Value != null && Single.TryParse(worksheet.Cells[row, 4].Value.ToString(), out tempCost))
                {
                    prod.Cost = tempCost;
                }
                else
                {
                    errmsg += "Invalid cost: " + worksheet.Cells[row, 4].Value + " ";
                }
                if (worksheet.Cells[row, 5].Value != null && Single.TryParse(worksheet.Cells[row, 5].Value.ToString(), out tempPrice))
                {
                    prod.SellPrice = tempPrice;
                }
                else
                {
                    prod.SellPrice = 0;
                    errmsg += "Invalid Price: " + worksheet.Cells[row, 5].Value + " ";
                }
                if (worksheet.Cells[row, 6].Value != null && Int64.TryParse(worksheet.Cells[row, 6].Value.ToString(), out tempUPC))
                {
                    prod.UPC = tempUPC;
                }
                else
                {
                    prod.UPC = 0;
                }
                if(errmsg.Length != 0)
                {
                    errmsg = errmsg.Insert(0, "Error for Item number " + prod.ItemNo + " on row " + row + ": ");
                    errors.Add(errmsg);
                    continue;
                }
                Product prodInDB = ProductDatabase.SearchProductByItemNo(prod.ItemNo);
                if (prodInDB == null)
                {
                    prod.ItemDesc = InsertEscape(prod.ItemDesc);
                    ProductDatabase.AddProduct(prod.ItemNo, prod.ItemDesc, prod.PerCarton, prod.Location, prod.Cost, prod.SellPrice, prod.UPC);
                }
                else
                {
                    if (prodInDB.ItemDesc == prod.ItemDesc)
                    {
                        prod.ItemDesc = InsertEscape(prod.ItemDesc);
                        ProductDatabase.EditProduct(prod.ItemNo, prod.ItemNo, prod.ItemDesc, prod.PerCarton, prod.Location, prod.Cost, prod.SellPrice, prod.UPC);
                    }
                    else
                    {
                        HandleItemNoConflict(prod);
                    }
                }
                backgroundWorker1.ReportProgress((int)(readProgress * row));
            }
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

        private String InsertEscape(String desc)
        {
            for (int index = 0; index < desc.Length; ++index)
            {
                if (desc.ElementAt<char>(index) == '\'')
                {
                    desc = desc.Insert(index, "'");
                    index++;
                }
            }
            return desc;
        }

        private void HandleItemNoConflict(Product prodToAdd)
        {
            char append = 'a';
            String tempItemNo = prodToAdd.ItemNo + append++;
         
            List<Product> prods = ProductDatabase.SearchProductsByItemNoOneWildCard(prodToAdd.ItemNo);
            for(int i = 0; i < prods.Count; i++)
            {
                if(prods[i].ItemNo == tempItemNo )
                {
                    if (prods[i].ItemDesc == prodToAdd.ItemDesc)
                    {
                        prodToAdd.ItemNo = tempItemNo;
                        prodToAdd.ItemDesc = InsertEscape(prodToAdd.ItemDesc);
                        ProductDatabase.EditProduct(prodToAdd.ItemNo, prodToAdd.ItemNo, prodToAdd.ItemDesc, prodToAdd.PerCarton, prodToAdd.Location, prodToAdd.Cost, prodToAdd.SellPrice, prodToAdd.UPC);
                        return;
                    }
                    else
                    {
                        tempItemNo = prodToAdd.ItemNo + append++;
                    }
                }
            }
            prodToAdd.ItemNo = tempItemNo;
            prodToAdd.ItemDesc = InsertEscape(prodToAdd.ItemDesc);
            ProductDatabase.AddProduct(prodToAdd.ItemNo, prodToAdd.ItemDesc, prodToAdd.PerCarton, prodToAdd.Location, prodToAdd.Cost, prodToAdd.SellPrice, prodToAdd.UPC);
        }
    }
}
