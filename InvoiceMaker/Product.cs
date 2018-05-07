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
        internal String ItemNumber { get; set; }
        internal String ItemDescription { get; set; }
        // Items come in packs of cartons
        // TODO: Validation CANNOT BE ZERO
        internal Int32 CartonTotal { get; set; }
        // Location in GWW Warehouse
        // TODO: Determine if it is a fixed amount of locations
        internal String WarehouseLocation { get; set; }
        // Cost for GWW
        // DO NOT GIVE THIS INFO IN INVOICE
        internal float WholesaleCost { get; set; }
        // Price for GWW Customer
        internal float SalePrice { get; set; }
        // Barcode; Sometimes information not available
        internal String UPC { get; set; }

        // Everything is filled.
        public Product(string itemNumber, string itemDescription, Int32 cartonTotal, string warehouseLocation, float wholesaleCost, float salePrice, String uPC)
        {
            ItemNumber = itemNumber;
            ItemDescription = itemDescription;
            CartonTotal = cartonTotal;
            WarehouseLocation = warehouseLocation;
            WholesaleCost = wholesaleCost;
            SalePrice = salePrice;
            UPC = uPC;
        }

        // Missing UPC
        public Product(string itemNumber, string itemDescription, Int32 cartonTotal, string warehouseLocation, float wholesaleCost, float salePrice)
        {
            ItemNumber = itemNumber;
            ItemDescription = itemDescription;
            CartonTotal = cartonTotal;
            WarehouseLocation = warehouseLocation;
            WholesaleCost = wholesaleCost;
            SalePrice = salePrice;
            UPC = null;
        }
    }
}
