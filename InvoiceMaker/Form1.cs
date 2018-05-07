﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using ExcelLibrary.SpreadSheet;

namespace InvoiceMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Debug.Print("hi");
            //ProductForm productForm = new ProductForm();
            //productForm.Font = new Font(productForm.Font.Name, productForm.Font.Size + 1, productForm.Font.Style);
            //productForm.Show();
            OpenFileDialog fd = new OpenFileDialog();

            if (fd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            ExcelReadWindow prog = new ExcelReadWindow(fd.FileName);
            prog.Show();
            /*
            FileInfo excelFile = new FileInfo(fd.FileName);
            Workbook ex = Workbook.Load(fd.FileName);
            Worksheet worksheet = ex.Worksheets[0];
            int maxRow = worksheet.Cells.Rows.Count;
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
            }*/
            
        }
        
    }
}
