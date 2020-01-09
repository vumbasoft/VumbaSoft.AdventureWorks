using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Components.Lookups;
using VumbaSoft.AdventureWorks.Components.Mvc;
using VumbaSoft.AdventureWorks.Components.Security;
using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using NonFactors.Mvc.Lookup;
using System;

namespace VumbaSoft.AdventureWorks.Controllers
{
    [AllowUnauthorized]
    public class LookupController : BaseController
    {
        private IUnitOfWork UnitOfWork { get; }

        public LookupController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [NonAction]
        public virtual JsonResult GetData(MvcLookup lookup, LookupFilter filter)
        {
            lookup.Filter = filter;

            return Json(lookup.GetData());
        }

        [AjaxOnly]
        public JsonResult Role(LookupFilter filter)
        {
            return GetData(new MvcLookup<Role, RoleView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult Continent(LookupFilter filter)
        {
            return GetData(new MvcLookup<Continent, ContinentView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult ContinentRegion(LookupFilter filter)
        {
            return GetData(new MvcLookup<ContinentRegion, ContinentRegionView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult Country(LookupFilter filter)
        {
            return GetData(new MvcLookup<Country, CountryView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult Region(LookupFilter filter)
        {
            return GetData(new MvcLookup<Region, RegionView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult Province(LookupFilter filter)
        {
            return GetData(new MvcLookup<Province, ProvinceView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult District(LookupFilter filter)
        {
            return GetData(new MvcLookup<District, DistrictView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult Locality(LookupFilter filter)
        {
            return GetData(new MvcLookup<Locality, LocalityView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult City(LookupFilter filter)
        {
            return GetData(new MvcLookup<City, CityView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult Tenant(LookupFilter filter)
        {
            return GetData(new MvcLookup<Tenant, TenantView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult Adventureworkfacility(LookupFilter filter)
        {
            return GetData(new MvcLookup<AdventureworkFacility, AdventureworkFacilityView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult Customcaretype(LookupFilter filter)
        {
            return GetData(new MvcLookup<CustomCareType, CustomCareTypeView>(UnitOfWork), filter);
        }

        protected override void Dispose(Boolean disposing)
        {
            UnitOfWork.Dispose();

            base.Dispose(disposing);
        }
    }
}
