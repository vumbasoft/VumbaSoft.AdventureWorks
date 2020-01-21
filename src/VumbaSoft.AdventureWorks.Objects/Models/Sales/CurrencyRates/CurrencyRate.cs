using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CurrencyRate : BaseModel
    {
        public Int32 CurrencyId { get; set; }
        public Int32 ToCurrencyId { get; set; }

        public DateTime CurrencyRateDate { get; set; }
        public String FromCurrencyCode { get; set; }
        public String ToCurrencyCode { get; set; }
        public Decimal AverageRate { get; set; }
        public Decimal EndOfDayRate { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Currency ToCurrencyCodeNavigation { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
