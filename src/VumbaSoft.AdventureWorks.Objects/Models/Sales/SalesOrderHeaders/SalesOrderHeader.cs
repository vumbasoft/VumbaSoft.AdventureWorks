using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SalesOrderHeader : BaseModel
    {
        public Int32 SalesOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
        public Boolean? OnlineOrderFlag { get; set; }
        public String SalesOrderNumber { get; set; }
        public String PurchaseOrderNumber { get; set; }
        public String AccountNumber { get; set; }
        public Int32 CustomerId { get; set; }
        public Int32 ContactId { get; set; }
        public Int32? SalesPersonId { get; set; }
        public Int32? TerritoryId { get; set; }
        public Int32 BillToAddressId { get; set; }
        public Int32 ShipToAddressId { get; set; }
        public Int32 ShipMethodId { get; set; }
        public Int32? CreditCardId { get; set; }
        public String CreditCardApprovalCode { get; set; }
        public Int32? CurrencyRateId { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal TaxAmt { get; set; }
        public Decimal Freight { get; set; }
        public Decimal TotalDue { get; set; }
        public String Comment { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Address BillToAddress { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual CurrencyRate CurrencyRate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual ShipMethod ShipMethod { get; set; }
        public virtual Address ShipToAddress { get; set; }
        public virtual SalesTerritory Territory { get; set; }
        public virtual List<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual List<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
    }
}
