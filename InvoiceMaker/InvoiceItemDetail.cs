﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace InvoiceMaker
{
    public class InvoiceItemDetail
    {
        public String InvoiceID { get; set; }
        public Int32 QTY { get; set; }
        public int GrabCarton { get; set; }
        public String ItemNo { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
        public int CartonTotal { get; set; }
        public float InvoiceItemSellPrice { get; set; }
        public float InvoiceItemAmount { get; set; }
        public String InvoiceItemNote { get; set; }
    }
}