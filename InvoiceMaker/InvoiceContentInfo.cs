using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public struct InvoiceContentInfo
    {
        //EntryID | InvoiceID | ItemNo | Quantity | BackOrder | SpecialNotes


        internal String ItemNo;
        internal int Quantity;
        internal int Backorder;
        internal String SpecialNotes;

        public InvoiceContentInfo(String itemNo, int quantity, int backorder, String specialNotes)
        {
            ItemNo = itemNo;
            Quantity = quantity;
            Backorder = backorder;
            SpecialNotes = specialNotes;

        }
    }
}
