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

namespace InvoiceMaker
{
    public partial class ReadProduct : Form
    {
        internal List<String> errmsg;
        public ReadProduct()
        {
            InitializeComponent();
            listBox1.HorizontalScrollbar = true;
        }

        private void CancelRead_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BrowseExcelProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel Files|*.xls";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                ExcelReadWindow excel = new ExcelReadWindow(openFileDialog1.FileName);
                excel.ShowDialog();
                errmsg = excel.errors;
                listBox1.DataSource = errmsg;

            }
        }
    }
}
