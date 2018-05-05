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
        String ItemNumber { get; set; }
        String ItemDescription { get; set; }
        // Items come in packs of cartons
        // TODO: Validation CANNOT BE ZERO
        String CartonTotal { get; set; }
        // Location in GWW Warehouse
        // TODO: Determine if it is a fixed amount of locations
        String WarehouseLocation { get; set; }
        // Cost for GWW
        // DO NOT GIVE THIS INFO IN INVOICE
        float WholesaleCost { get; set; }
        // Price for GWW Customer
        float SalePrice { get; set; }
        // Barcode; Sometimes information not available
        float UPC { get; set; }

        // Everything is filled.
        public Product(string itemNumber, string itemDescription, string cartonTotal, string warehouseLocation, float wholesaleCost, float salePrice, float uPC)
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
        public Product(string itemNumber, string itemDescription, string cartonTotal, string warehouseLocation, float wholesaleCost, float salePrice)
        {
            ItemNumber = itemNumber;
            ItemDescription = itemDescription;
            CartonTotal = cartonTotal;
            WarehouseLocation = warehouseLocation;
            WholesaleCost = wholesaleCost;
            SalePrice = salePrice;
            UPC = 0;
        }
    }
}
