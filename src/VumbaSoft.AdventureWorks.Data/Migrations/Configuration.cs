using Microsoft.EntityFrameworkCore;
using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Data.Logging;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Data.Migrations
{
    public sealed class Configuration : IDisposable
    {
        private IUnitOfWork UnitOfWork { get; }
        private DbContext Context { get; }

        public Configuration(DbContext context, DbContext? audit)
        {
            UnitOfWork = new UnitOfWork(context, audit == null ? null : new AuditLogger(audit, 0));
            Context = context;
        }

        public void UpdateDatabase()
        {
            Context.Database.Migrate();

            SeedData();
        }
        public void SeedData()
        {
            SeedPermissions();
            SeedRoles();

            SeedAccounts();
        }

        private void SeedPermissions()
        {
            List<Permission> permissions = new List<Permission>
            {
                new Permission { Area = "Administration", Controller = "Accounts", Action = "Index" },
                new Permission { Area = "Administration", Controller = "Accounts", Action = "Create" },
                new Permission { Area = "Administration", Controller = "Accounts", Action = "Details" },
                new Permission { Area = "Administration", Controller = "Accounts", Action = "Edit" },

                new Permission { Area = "Administration", Controller = "Roles", Action = "Index" },
                new Permission { Area = "Administration", Controller = "Roles", Action = "Create" },
                new Permission { Area = "Administration", Controller = "Roles", Action = "Details" },
                new Permission { Area = "Administration", Controller = "Roles", Action = "Edit" },
                new Permission { Area = "Administration", Controller = "Roles", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "Continents", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "Continents", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "Continents", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "Continents", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "Continents", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "ContinentRegions", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "ContinentRegions", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "ContinentRegions", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "ContinentRegions", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "ContinentRegions", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "Countries", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "Countries", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "Countries", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "Countries", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "Countries", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "Regions", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "Regions", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "Regions", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "Regions", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "Regions", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "Provinces", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "Provinces", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "Provinces", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "Provinces", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "Provinces", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "Districts", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "Districts", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "Districts", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "Districts", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "Districts", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "Localities", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "Localities", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "Localities", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "Localities", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "Localities", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "Cities", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "Cities", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "Cities", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "Cities", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "Cities", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "AdventureworkFacilities", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "AdventureworkFacilities", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "AdventureworkFacilities", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "AdventureworkFacilities", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "AdventureworkFacilities", Action = "Delete" },

                new Permission { Area = "Demografic", Controller = "Tenants", Action = "Index" },
                new Permission { Area = "Demografic", Controller = "Tenants", Action = "Create" },
                new Permission { Area = "Demografic", Controller = "Tenants", Action = "Edit" },
                new Permission { Area = "Demografic", Controller = "Tenants", Action = "Details" },
                new Permission { Area = "Demografic", Controller = "Tenants", Action = "Delete" },

                new Permission { Area = "LookupSettings", Controller = "CustomCareTypes", Action = "Index" },
                new Permission { Area = "LookupSettings", Controller = "CustomCareTypes", Action = "Create" },
                new Permission { Area = "LookupSettings", Controller = "CustomCareTypes", Action = "Edit" },
                new Permission { Area = "LookupSettings", Controller = "CustomCareTypes", Action = "Details" },
                new Permission { Area = "LookupSettings", Controller = "CustomCareTypes", Action = "Delete" },

                new Permission { Area = "HumanResources", Controller = "Departments", Action = "Index" },
                new Permission { Area = "HumanResources", Controller = "Departments", Action = "Create" },
                new Permission { Area = "HumanResources", Controller = "Departments", Action = "Edit" },
                new Permission { Area = "HumanResources", Controller = "Departments", Action = "Details" },
                new Permission { Area = "HumanResources", Controller = "Departments", Action = "Delete" },

                new Permission { Area = "HumanResources", Controller = "Employees", Action = "Index" },
                new Permission { Area = "HumanResources", Controller = "Employees", Action = "Create" },
                new Permission { Area = "HumanResources", Controller = "Employees", Action = "Edit" },
                new Permission { Area = "HumanResources", Controller = "Employees", Action = "Details" },
                new Permission { Area = "HumanResources", Controller = "Employees", Action = "Delete" },

                new Permission { Area = "HumanResources", Controller = "EmployeeAddresses", Action = "Index" },
                new Permission { Area = "HumanResources", Controller = "EmployeeAddresses", Action = "Create" },
                new Permission { Area = "HumanResources", Controller = "EmployeeAddresses", Action = "Edit" },
                new Permission { Area = "HumanResources", Controller = "EmployeeAddresses", Action = "Details" },
                new Permission { Area = "HumanResources", Controller = "EmployeeAddresses", Action = "Delete" },

                new Permission { Area = "HumanResources", Controller = "EmployeeDepartmentHistories", Action = "Index" },
                new Permission { Area = "HumanResources", Controller = "EmployeeDepartmentHistories", Action = "Create" },
                new Permission { Area = "HumanResources", Controller = "EmployeeDepartmentHistories", Action = "Edit" },
                new Permission { Area = "HumanResources", Controller = "EmployeeDepartmentHistories", Action = "Details" },
                new Permission { Area = "HumanResources", Controller = "EmployeeDepartmentHistories", Action = "Delete" },

                new Permission { Area = "HumanResources", Controller = "EmployeePayHistories", Action = "Index" },
                new Permission { Area = "HumanResources", Controller = "EmployeePayHistories", Action = "Create" },
                new Permission { Area = "HumanResources", Controller = "EmployeePayHistories", Action = "Edit" },
                new Permission { Area = "HumanResources", Controller = "EmployeePayHistories", Action = "Details" },
                new Permission { Area = "HumanResources", Controller = "EmployeePayHistories", Action = "Delete" },

                new Permission { Area = "HumanResources", Controller = "JobCandidates", Action = "Index" },
                new Permission { Area = "HumanResources", Controller = "JobCandidates", Action = "Create" },
                new Permission { Area = "HumanResources", Controller = "JobCandidates", Action = "Edit" },
                new Permission { Area = "HumanResources", Controller = "JobCandidates", Action = "Details" },
                new Permission { Area = "HumanResources", Controller = "JobCandidates", Action = "Delete" },

                new Permission { Area = "HumanResources", Controller = "Shifts", Action = "Index" },
                new Permission { Area = "HumanResources", Controller = "Shifts", Action = "Create" },
                new Permission { Area = "HumanResources", Controller = "Shifts", Action = "Edit" },
                new Permission { Area = "HumanResources", Controller = "Shifts", Action = "Details" },
                new Permission { Area = "HumanResources", Controller = "Shifts", Action = "Delete" },

                new Permission { Area = "Person", Controller = "Addresses", Action = "Index" },
                new Permission { Area = "Person", Controller = "Addresses", Action = "Create" },
                new Permission { Area = "Person", Controller = "Addresses", Action = "Edit" },
                new Permission { Area = "Person", Controller = "Addresses", Action = "Details" },
                new Permission { Area = "Person", Controller = "Addresses", Action = "Delete" },

                new Permission { Area = "Person", Controller = "AddressTypes", Action = "Index" },
                new Permission { Area = "Person", Controller = "AddressTypes", Action = "Create" },
                new Permission { Area = "Person", Controller = "AddressTypes", Action = "Edit" },
                new Permission { Area = "Person", Controller = "AddressTypes", Action = "Details" },
                new Permission { Area = "Person", Controller = "AddressTypes", Action = "Delete" },

                new Permission { Area = "Person", Controller = "Contacts", Action = "Index" },
                new Permission { Area = "Person", Controller = "Contacts", Action = "Create" },
                new Permission { Area = "Person", Controller = "Contacts", Action = "Edit" },
                new Permission { Area = "Person", Controller = "Contacts", Action = "Details" },
                new Permission { Area = "Person", Controller = "Contacts", Action = "Delete" },

                new Permission { Area = "Person", Controller = "ContactTypes", Action = "Index" },
                new Permission { Area = "Person", Controller = "ContactTypes", Action = "Create" },
                new Permission { Area = "Person", Controller = "ContactTypes", Action = "Edit" },
                new Permission { Area = "Person", Controller = "ContactTypes", Action = "Details" },
                new Permission { Area = "Person", Controller = "ContactTypes", Action = "Delete" },

                new Permission { Area = "Person", Controller = "CountryRegions", Action = "Index" },
                new Permission { Area = "Person", Controller = "CountryRegions", Action = "Create" },
                new Permission { Area = "Person", Controller = "CountryRegions", Action = "Edit" },
                new Permission { Area = "Person", Controller = "CountryRegions", Action = "Details" },
                new Permission { Area = "Person", Controller = "CountryRegions", Action = "Delete" },

                new Permission { Area = "Person", Controller = "StateProvinces", Action = "Index" },
                new Permission { Area = "Person", Controller = "StateProvinces", Action = "Create" },
                new Permission { Area = "Person", Controller = "StateProvinces", Action = "Edit" },
                new Permission { Area = "Person", Controller = "StateProvinces", Action = "Details" },
                new Permission { Area = "Person", Controller = "StateProvinces", Action = "Delete" },

                new Permission { Area = "Production", Controller = "BillOfMaterials", Action = "Index" },
                new Permission { Area = "Production", Controller = "BillOfMaterials", Action = "Create" },
                new Permission { Area = "Production", Controller = "BillOfMaterials", Action = "Edit" },
                new Permission { Area = "Production", Controller = "BillOfMaterials", Action = "Details" },
                new Permission { Area = "Production", Controller = "BillOfMaterials", Action = "Delete" },

                new Permission { Area = "Production", Controller = "Cultures", Action = "Index" },
                new Permission { Area = "Production", Controller = "Cultures", Action = "Create" },
                new Permission { Area = "Production", Controller = "Cultures", Action = "Edit" },
                new Permission { Area = "Production", Controller = "Cultures", Action = "Details" },
                new Permission { Area = "Production", Controller = "Cultures", Action = "Delete" },

                new Permission { Area = "Production", Controller = "Documents", Action = "Index" },
                new Permission { Area = "Production", Controller = "Documents", Action = "Create" },
                new Permission { Area = "Production", Controller = "Documents", Action = "Edit" },
                new Permission { Area = "Production", Controller = "Documents", Action = "Details" },
                new Permission { Area = "Production", Controller = "Documents", Action = "Delete" },

                new Permission { Area = "Production", Controller = "Illustrations", Action = "Index" },
                new Permission { Area = "Production", Controller = "Illustrations", Action = "Create" },
                new Permission { Area = "Production", Controller = "Illustrations", Action = "Edit" },
                new Permission { Area = "Production", Controller = "Illustrations", Action = "Details" },
                new Permission { Area = "Production", Controller = "Illustrations", Action = "Delete" },

                new Permission { Area = "Production", Controller = "Locations", Action = "Index" },
                new Permission { Area = "Production", Controller = "Locations", Action = "Create" },
                new Permission { Area = "Production", Controller = "Locations", Action = "Edit" },
                new Permission { Area = "Production", Controller = "Locations", Action = "Details" },
                new Permission { Area = "Production", Controller = "Locations", Action = "Delete" },

                new Permission { Area = "Production", Controller = "Productsubcategories", Action = "Index" },
                new Permission { Area = "Production", Controller = "Productsubcategories", Action = "Create" },
                new Permission { Area = "Production", Controller = "Productsubcategories", Action = "Edit" },
                new Permission { Area = "Production", Controller = "Productsubcategories", Action = "Details" },
                new Permission { Area = "Production", Controller = "Productsubcategories", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductCategories", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductCategories", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductCategories", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductCategories", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductCategories", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductCostHistories", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductCostHistories", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductCostHistories", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductCostHistories", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductCostHistories", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductDescriptions", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductDescriptions", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductDescriptions", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductDescriptions", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductDescriptions", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductDocuments", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductDocuments", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductDocuments", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductDocuments", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductDocuments", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductInventories", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductInventories", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductInventories", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductInventories", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductInventories", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductListPriceHistories", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductListPriceHistories", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductListPriceHistories", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductListPriceHistories", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductListPriceHistories", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductModels", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductModels", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductModels", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductModels", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductModels", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductModelIllustrations", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductModelIllustrations", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductModelIllustrations", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductModelIllustrations", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductModelIllustrations", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductModelProductDescriptionCultures", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductModelProductDescriptionCultures", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductModelProductDescriptionCultures", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductModelProductDescriptionCultures", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductModelProductDescriptionCultures", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductPhotos", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductPhotos", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductPhotos", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductPhotos", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductPhotos", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductProductPhotos", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductProductPhotos", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductProductPhotos", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductProductPhotos", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductProductPhotos", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductReviews", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductReviews", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductReviews", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductReviews", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductReviews", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ProductSubcategories", Action = "Index" },
                new Permission { Area = "Production", Controller = "ProductSubcategories", Action = "Create" },
                new Permission { Area = "Production", Controller = "ProductSubcategories", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ProductSubcategories", Action = "Details" },
                new Permission { Area = "Production", Controller = "ProductSubcategories", Action = "Delete" },

                new Permission { Area = "Production", Controller = "ScrapReasons", Action = "Index" },
                new Permission { Area = "Production", Controller = "ScrapReasons", Action = "Create" },
                new Permission { Area = "Production", Controller = "ScrapReasons", Action = "Edit" },
                new Permission { Area = "Production", Controller = "ScrapReasons", Action = "Details" },
                new Permission { Area = "Production", Controller = "ScrapReasons", Action = "Delete" },

                new Permission { Area = "Production", Controller = "TransactionHistories", Action = "Index" },
                new Permission { Area = "Production", Controller = "TransactionHistories", Action = "Create" },
                new Permission { Area = "Production", Controller = "TransactionHistories", Action = "Edit" },
                new Permission { Area = "Production", Controller = "TransactionHistories", Action = "Details" },
                new Permission { Area = "Production", Controller = "TransactionHistories", Action = "Delete" },

                new Permission { Area = "Production", Controller = "TransactionHistoryArchives", Action = "Index" },
                new Permission { Area = "Production", Controller = "TransactionHistoryArchives", Action = "Create" },
                new Permission { Area = "Production", Controller = "TransactionHistoryArchives", Action = "Edit" },
                new Permission { Area = "Production", Controller = "TransactionHistoryArchives", Action = "Details" },
                new Permission { Area = "Production", Controller = "TransactionHistoryArchives", Action = "Delete" },

                new Permission { Area = "Production", Controller = "UnitMeasures", Action = "Index" },
                new Permission { Area = "Production", Controller = "UnitMeasures", Action = "Create" },
                new Permission { Area = "Production", Controller = "UnitMeasures", Action = "Edit" },
                new Permission { Area = "Production", Controller = "UnitMeasures", Action = "Details" },
                new Permission { Area = "Production", Controller = "UnitMeasures", Action = "Delete" },

                new Permission { Area = "Production", Controller = "WorkOrders", Action = "Index" },
                new Permission { Area = "Production", Controller = "WorkOrders", Action = "Create" },
                new Permission { Area = "Production", Controller = "WorkOrders", Action = "Edit" },
                new Permission { Area = "Production", Controller = "WorkOrders", Action = "Details" },
                new Permission { Area = "Production", Controller = "WorkOrders", Action = "Delete" },

                new Permission { Area = "Production", Controller = "WorkOrderRoutings", Action = "Index" },
                new Permission { Area = "Production", Controller = "WorkOrderRoutings", Action = "Create" },
                new Permission { Area = "Production", Controller = "WorkOrderRoutings", Action = "Edit" },
                new Permission { Area = "Production", Controller = "WorkOrderRoutings", Action = "Details" },
                new Permission { Area = "Production", Controller = "WorkOrderRoutings", Action = "Delete" },

                new Permission { Area = "Purchasing", Controller = "ProductVendors", Action = "Index" },
                new Permission { Area = "Purchasing", Controller = "ProductVendors", Action = "Create" },
                new Permission { Area = "Purchasing", Controller = "ProductVendors", Action = "Edit" },
                new Permission { Area = "Purchasing", Controller = "ProductVendors", Action = "Details" },
                new Permission { Area = "Purchasing", Controller = "ProductVendors", Action = "Delete" },

                new Permission { Area = "Purchasing", Controller = "PurchaseOrderDetails", Action = "Index" },
                new Permission { Area = "Purchasing", Controller = "PurchaseOrderDetails", Action = "Create" },
                new Permission { Area = "Purchasing", Controller = "PurchaseOrderDetails", Action = "Edit" },
                new Permission { Area = "Purchasing", Controller = "PurchaseOrderDetails", Action = "Details" },
                new Permission { Area = "Purchasing", Controller = "PurchaseOrderDetails", Action = "Delete" },

                new Permission { Area = "Purchasing", Controller = "PurchaseOrderHeaders", Action = "Index" },
                new Permission { Area = "Purchasing", Controller = "PurchaseOrderHeaders", Action = "Create" },
                new Permission { Area = "Purchasing", Controller = "PurchaseOrderHeaders", Action = "Edit" },
                new Permission { Area = "Purchasing", Controller = "PurchaseOrderHeaders", Action = "Details" },
                new Permission { Area = "Purchasing", Controller = "PurchaseOrderHeaders", Action = "Delete" },

                new Permission { Area = "Purchasing", Controller = "ShipMethods", Action = "Index" },
                new Permission { Area = "Purchasing", Controller = "ShipMethods", Action = "Create" },
                new Permission { Area = "Purchasing", Controller = "ShipMethods", Action = "Edit" },
                new Permission { Area = "Purchasing", Controller = "ShipMethods", Action = "Details" },
                new Permission { Area = "Purchasing", Controller = "ShipMethods", Action = "Delete" },

                new Permission { Area = "Purchasing", Controller = "Vendors", Action = "Index" },
                new Permission { Area = "Purchasing", Controller = "Vendors", Action = "Create" },
                new Permission { Area = "Purchasing", Controller = "Vendors", Action = "Edit" },
                new Permission { Area = "Purchasing", Controller = "Vendors", Action = "Details" },
                new Permission { Area = "Purchasing", Controller = "Vendors", Action = "Delete" },

                new Permission { Area = "Purchasing", Controller = "VendorAddresses", Action = "Index" },
                new Permission { Area = "Purchasing", Controller = "VendorAddresses", Action = "Create" },
                new Permission { Area = "Purchasing", Controller = "VendorAddresses", Action = "Edit" },
                new Permission { Area = "Purchasing", Controller = "VendorAddresses", Action = "Details" },
                new Permission { Area = "Purchasing", Controller = "VendorAddresses", Action = "Delete" },

                new Permission { Area = "Purchasing", Controller = "VendorContacts", Action = "Index" },
                new Permission { Area = "Purchasing", Controller = "VendorContacts", Action = "Create" },
                new Permission { Area = "Purchasing", Controller = "VendorContacts", Action = "Edit" },
                new Permission { Area = "Purchasing", Controller = "VendorContacts", Action = "Details" },
                new Permission { Area = "Purchasing", Controller = "VendorContacts", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "ContactCreditCards", Action = "Index" },
                new Permission { Area = "Sales", Controller = "ContactCreditCards", Action = "Create" },
                new Permission { Area = "Sales", Controller = "ContactCreditCards", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "ContactCreditCards", Action = "Details" },
                new Permission { Area = "Sales", Controller = "ContactCreditCards", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "CountryRegionCurrencies", Action = "Index" },
                new Permission { Area = "Sales", Controller = "CountryRegionCurrencies", Action = "Create" },
                new Permission { Area = "Sales", Controller = "CountryRegionCurrencies", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "CountryRegionCurrencies", Action = "Details" },
                new Permission { Area = "Sales", Controller = "CountryRegionCurrencies", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "CreditCards", Action = "Index" },
                new Permission { Area = "Sales", Controller = "CreditCards", Action = "Create" },
                new Permission { Area = "Sales", Controller = "CreditCards", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "CreditCards", Action = "Details" },
                new Permission { Area = "Sales", Controller = "CreditCards", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "Currencies", Action = "Index" },
                new Permission { Area = "Sales", Controller = "Currencies", Action = "Create" },
                new Permission { Area = "Sales", Controller = "Currencies", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "Currencies", Action = "Details" },
                new Permission { Area = "Sales", Controller = "Currencies", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "CurrencyRates", Action = "Index" },
                new Permission { Area = "Sales", Controller = "CurrencyRates", Action = "Create" },
                new Permission { Area = "Sales", Controller = "CurrencyRates", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "CurrencyRates", Action = "Details" },
                new Permission { Area = "Sales", Controller = "CurrencyRates", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "Customers", Action = "Index" },
                new Permission { Area = "Sales", Controller = "Customers", Action = "Create" },
                new Permission { Area = "Sales", Controller = "Customers", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "Customers", Action = "Details" },
                new Permission { Area = "Sales", Controller = "Customers", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "CustomerAddresses", Action = "Index" },
                new Permission { Area = "Sales", Controller = "CustomerAddresses", Action = "Create" },
                new Permission { Area = "Sales", Controller = "CustomerAddresses", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "CustomerAddresses", Action = "Details" },
                new Permission { Area = "Sales", Controller = "CustomerAddresses", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "Individuals", Action = "Index" },
                new Permission { Area = "Sales", Controller = "Individuals", Action = "Create" },
                new Permission { Area = "Sales", Controller = "Individuals", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "Individuals", Action = "Details" },
                new Permission { Area = "Sales", Controller = "Individuals", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SalesOrderDetails", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SalesOrderDetails", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SalesOrderDetails", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SalesOrderDetails", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SalesOrderDetails", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SalesOrderHeaders", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SalesOrderHeaders", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SalesOrderHeaders", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SalesOrderHeaders", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SalesOrderHeaders", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SalesOrderHeaderSalesReasons", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SalesOrderHeaderSalesReasons", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SalesOrderHeaderSalesReasons", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SalesOrderHeaderSalesReasons", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SalesOrderHeaderSalesReasons", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SalesPersons", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SalesPersons", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SalesPersons", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SalesPersons", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SalesPersons", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SalesPersonQuotaHistories", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SalesPersonQuotaHistories", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SalesPersonQuotaHistories", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SalesPersonQuotaHistories", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SalesPersonQuotaHistories", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SalesReasons", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SalesReasons", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SalesReasons", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SalesReasons", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SalesReasons", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SalesTaxRates", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SalesTaxRates", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SalesTaxRates", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SalesTaxRates", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SalesTaxRates", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SalesTerritories", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SalesTerritories", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SalesTerritories", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SalesTerritories", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SalesTerritories", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SalesTerritoryHistories", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SalesTerritoryHistories", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SalesTerritoryHistories", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SalesTerritoryHistories", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SalesTerritoryHistories", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "ShoppingCartItems", Action = "Index" },
                new Permission { Area = "Sales", Controller = "ShoppingCartItems", Action = "Create" },
                new Permission { Area = "Sales", Controller = "ShoppingCartItems", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "ShoppingCartItems", Action = "Details" },
                new Permission { Area = "Sales", Controller = "ShoppingCartItems", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SpecialOffers", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SpecialOffers", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SpecialOffers", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SpecialOffers", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SpecialOffers", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "SpecialOfferProducts", Action = "Index" },
                new Permission { Area = "Sales", Controller = "SpecialOfferProducts", Action = "Create" },
                new Permission { Area = "Sales", Controller = "SpecialOfferProducts", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "SpecialOfferProducts", Action = "Details" },
                new Permission { Area = "Sales", Controller = "SpecialOfferProducts", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "Stores", Action = "Index" },
                new Permission { Area = "Sales", Controller = "Stores", Action = "Create" },
                new Permission { Area = "Sales", Controller = "Stores", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "Stores", Action = "Details" },
                new Permission { Area = "Sales", Controller = "Stores", Action = "Delete" },

                new Permission { Area = "Sales", Controller = "StoreContacts", Action = "Index" },
                new Permission { Area = "Sales", Controller = "StoreContacts", Action = "Create" },
                new Permission { Area = "Sales", Controller = "StoreContacts", Action = "Edit" },
                new Permission { Area = "Sales", Controller = "StoreContacts", Action = "Details" },
                new Permission { Area = "Sales", Controller = "StoreContacts", Action = "Delete" }
            };

            foreach (Permission permission in UnitOfWork.Select<Permission>().ToArray())
                if (permissions.RemoveAll(p => p.Area == permission.Area && p.Controller == permission.Controller && p.Action == permission.Action) == 0)
                {
                    UnitOfWork.DeleteRange(UnitOfWork.Select<RolePermission>().Where(role => role.PermissionId == permission.Id));
                    UnitOfWork.Delete(permission);
                }

            UnitOfWork.InsertRange(permissions);
            UnitOfWork.Commit();
        }

        private void SeedRoles()
        {
            if (!UnitOfWork.Select<Role>().Any(role => role.Title == "Sys_Admin"))
            {
                UnitOfWork.Insert(new Role { Title = "Sys_Admin", Permissions = new List<RolePermission>() });

                UnitOfWork.Commit();
            }

            Role admin = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Admin");
            Int32[] permissions = admin.Permissions.Select(role => role.PermissionId).ToArray();

            foreach (Permission permission in UnitOfWork.Select<Permission>())
                if (!permissions.Contains(permission.Id))
                    UnitOfWork.Insert(new RolePermission { RoleId = admin.Id, PermissionId = permission.Id });

            UnitOfWork.Commit();
        }

        private void SeedAccounts()
        {
            Account[] accounts =
            {
                new Account
                {
                    Username = "admin",
                    Passhash = "$2b$13$7bvpSIErsz9jVwF//6CMh.ChtRdkNO/9uB8yJkriInF3acE4scmHq",
                    Email = "admin@test.domains.com",
                    IsLocked = false,

                    RoleId = UnitOfWork.Select<Role>().Single(role => role.Title == "Sys_Admin").Id
                }
            };

            foreach (Account account in accounts)
            {
                if (UnitOfWork.Select<Account>().FirstOrDefault(model => model.Username == account.Username) is Account currentAccount)
                {
                    currentAccount.IsLocked = account.IsLocked;
                    currentAccount.RoleId = account.RoleId;

                    UnitOfWork.Update(currentAccount);
                }
                else
                {
                    UnitOfWork.Insert(account);
                }
            }

            UnitOfWork.Commit();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
            Context.Dispose();
        }
    }
}
