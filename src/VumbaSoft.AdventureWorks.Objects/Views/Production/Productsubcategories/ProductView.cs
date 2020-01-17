using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductView : BaseView
    {
        public String Title { get; set; }
        public String ProductNumber { get; set; }
        public Boolean? MakeFlag { get; set; }
        public Boolean? FinishedGoodsFlag { get; set; }
        public String Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public String Size { get; set; }
        public String SizeUnitMeasureCode { get; set; }
        public String WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public Int32 DaysToManufacture { get; set; }
        public String ProductLine { get; set; }
        public String Class { get; set; }
        public String Style { get; set; }
        public Int32? ProductSubcategoryId { get; set; }
        public Int32? ProductModelId { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }

        public virtual ProductModel ProductModel { get; set; }
        public virtual ProductSubcategory ProductSubcategory { get; set; }
        public virtual UnitMeasure SizeUnitMeasureCodeNavigation { get; set; }
        public virtual UnitMeasure WeightUnitMeasureCodeNavigation { get; set; }
        public virtual List<BillOfMaterial> BillOfMaterialsComponent { get; set; }
        public virtual List<BillOfMaterial> BillOfMaterialsProductAssembly { get; set; }
        public virtual List<ProductCostHistory> ProductCostHistory { get; set; }
        public virtual List<ProductDocument> ProductDocument { get; set; }
        public virtual List<ProductInventory> ProductInventory { get; set; }
        public virtual List<ProductListPriceHistory> ProductListPriceHistory { get; set; }
        public virtual List<ProductProductPhoto> ProductProductPhoto { get; set; }
        public virtual List<ProductReview> ProductReview { get; set; }
        public virtual List<ProductVendor> ProductVendor { get; set; }
        public virtual List<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual List<ShoppingCartItem> ShoppingCartItem { get; set; }
        public virtual List<SpecialOfferProduct> SpecialOfferProduct { get; set; }
        public virtual List<TransactionHistory> TransactionHistory { get; set; }
        public virtual List<WorkOrder> WorkOrder { get; set; }
    }
}
