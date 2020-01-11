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
        public String Title { get; set; }
        public Int32 CityId { get; set; }
        public String Adress { get; set; }
        public Boolean IsInTrial { get; set; }
        public DateTime? TrialStartDate { get; set; }
        public DateTime? TrialEndDate { get; set; }
        public Boolean PaidOut { get; set; }
        public Boolean PeriodPaidOutId { get; set; }
        public DateTime? PaidStartDate { get; set; }
        public DateTime? PaidEndDate { get; set; }
        public Boolean Disabled { get; set; }
        public String DisabledReason { get; set; }
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
        public String LockedReason { get; set; }
        public Boolean Activated { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public String ActivatedReason { get; set; }
        public Boolean Upgraded { get; set; }
        public DateTime? UpgradedDate { get; set; }
        public Boolean Enabled { get; set; }
        public String PostalCode { get; set; }
        public String BusinessName { get; set; }
        public Int32? CustomCareTypeId { get; set; }
        public String? LogoPath { get; set; }
        public String? CityTitle { get; set; }
        public String? CustomCareTypeTitle { get; set; }
    }
}
