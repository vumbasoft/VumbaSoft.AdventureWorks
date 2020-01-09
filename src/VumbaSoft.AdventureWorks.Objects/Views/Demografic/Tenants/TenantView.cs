using NonFactors.Mvc.Lookup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class TenantView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public string Title { get; set; }
        public Int32 CityID { get; set; }
        public string Adress { get; set; }
        public Boolean IsInTrial { get; set; }
        public DateTime? TrialStartDate { get; set; }
        public DateTime? TrialEndDate { get; set; }
        public Boolean PaidOut { get; set; }
        public Boolean PeriodPaidOutId { get; set; }
        public DateTime? PaidStartDate { get; set; }
        public DateTime? PaidEndDate { get; set; }
        public Boolean Disabled { get; set; }
        public string DisabledReason { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? NextBillingDate { get; set; }
        //[Range(1, 100)]
        //[DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(18, 2)")]
        //public Decimal NextBillingDiscount { get; set; }
        public Boolean IsPremium { get; set; }
        public Boolean IsVIP { get; set; }
        public Boolean IsLocked { get; set; }
        public DateTime LockedDate { get; set; }
        public string LockedReason { get; set; }
        public Boolean Activated { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public string ActivatedReason { get; set; }
        public Boolean Upgraded { get; set; }
        public DateTime? UpgradedDate { get; set; }
        public Boolean Enabled { get; set; }
        public string PostalCode { get; set; }
        public string BusinessName { get; set; }
        public Int32? CustomCareTypeID { get; set; }
        public string LogoPath { get; set; }
    }
}
