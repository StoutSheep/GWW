using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    class Product
    {
        // Unique identifier for product
        String ItemNo { get; set; }
        String ItemDesc { get; set; }
        // Items come in packs of cartons
        // TODO: Validation CANNOT BE ZERO
        int PerCarton { get; set; }
        // Location in GWW Warehouse
        // TODO: Determine if it is a fixed amount of locations
        String Location { get; set; }
        // Cost for GWW
        // DO NOT GIVE THIS INFO IN INVOICE
        float Cost { get; set; }
        // Price for GWW Customer
        float SellPrice { get; set; }
        // Barcode; Sometimes information not available
        int UPC { get; set; }

        // Everything is filled.
        public Product(string itemNo, string itemDesc, int perCarton, string location, float cost, float sellPrice, int upc)
        {
            ItemNo = itemNo;
            ItemDesc = itemDesc;
            PerCarton = perCarton;
            Location = location;
            Cost = cost;
            SellPrice = sellPrice;
            UPC = upc;
        }

        // Missing UPC
        public Product(string itemNo, string itemDesc, int perCarton, string location, float cost, float sellPrice)
        {
            ItemNo = itemNo;
            ItemDesc = itemDesc;
            PerCarton = perCarton;
            Location = location;
            Cost = cost;
            SellPrice = sellPrice;
            UPC = 0;
        }
    }
}
