using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Collections.Generic;

namespace VumbaSoft.AdventureWorks.Tests
{
    public static class ObjectsFactory
    {
        public static Account CreateAccount(Int32 id = 1)
        {
            return new Account
            {
                Id = id,

                Username = $"Username{id}",
                Passhash = $"Passhash{id}",

                Email = $"{id}@tests.com",

                IsLocked = false,

                RecoveryToken = $"Token{id}",
                RecoveryTokenExpirationDate = DateTime.Now.AddMinutes(5),

                Role = CreateRole(id)
            };
        }
        public static AccountView CreateAccountView(Int32 id = 1)
        {
            return new AccountView
            {
                Id = id,

                Username = $"Username{id}",
                Email = $"{id}@tests.com",

                IsLocked = true,

                RoleTitle = $"Title{id}"
            };
        }
        public static AccountEditView CreateAccountEditView(Int32 id = 1)
        {
            return new AccountEditView
            {
                Id = id,

                Username = $"Username{id}",
                Email = $"{id}@tests.com",

                IsLocked = true,

                RoleId = id
            };
        }
        public static AccountCreateView CreateAccountCreateView(Int32 id = 1)
        {
            return new AccountCreateView
            {
                Id = id,

                Username = $"Username{id}",
                Password = $"Password{id}",

                Email = $"{id}@tests.com",

                RoleId = id
            };
        }

        public static AccountLoginView CreateAccountLoginView(Int32 id = 1)
        {
            return new AccountLoginView
            {
                Id = id,

                Username = $"Username{id}",
                Password = $"Password{id}"
            };
        }
        public static AccountResetView CreateAccountResetView(Int32 id = 1)
        {
            return new AccountResetView
            {
                Id = id,

                Token = $"Token{id}",
                NewPassword = $"NewPassword{id}"
            };
        }
        public static AccountRecoveryView CreateAccountRecoveryView(Int32 id = 1)
        {
            return new AccountRecoveryView
            {
                Id = id,

                Email = $"{id}@tests.com"
            };
        }

        public static ProfileEditView CreateProfileEditView(Int32 id = 1)
        {
            return new ProfileEditView
            {
                Id = id,

                Email = $"{id}@tests.com",
                Username = $"Username{id}",

                Password = $"Password{id}",
                NewPassword = $"NewPassword{id}"

            };
        }
        public static ProfileDeleteView CreateProfileDeleteView(Int32 id = 1)
        {
            return new ProfileDeleteView
            {
                Id = id,

                Password = $"Password{id}"
            };
        }

        public static Role CreateRole(Int32 id = 1)
        {
            return new Role
            {
                Id = id,

                Title = $"Title{id}",

                Accounts = new List<Account>(),
                Permissions = new List<RolePermission>()
            };
        }
        public static RoleView CreateRoleView(Int32 id = 1)
        {
            return new RoleView
            {
                Id = id,

                Title = $"Title{id}"
            };
        }

        public static Permission CreatePermission(Int32 id = 1)
        {
            return new Permission
            {
                Id = id,

                Area = $"Area{id}",
                Action = $"Action{id}",
                Controller = $"Controller{id}"
            };
        }
        public static RolePermission CreateRolePermission(Int32 id = 1)
        {
            return new RolePermission
            {
                Id = id,

                RoleId = id,
                Role = CreateRole(id),

                PermissionId = id,
                Permission = CreatePermission(id)
            };
        }

        public static TestModel CreateTestModel(Int32 id = 1)
        {
            return new TestModel
            {
                Id = id,

                Title = $"Title{id}"
            };
        }

        public static Continent CreateContinent(Int32 id = 1)
        {
            return new Continent
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static ContinentView CreateContinentView(Int32 id = 1)
        {
            return new ContinentView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static ContinentRegion CreateContinentRegion(Int32 id = 1)
        {
            return new ContinentRegion
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static ContinentRegionView CreateContinentRegionView(Int32 id = 1)
        {
            return new ContinentRegionView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static Country CreateCountry(Int32 id = 1)
        {
            return new Country
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static CountryView CreateCountryView(Int32 id = 1)
        {
            return new CountryView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static Region CreateRegion(Int32 id = 1)
        {
            return new Region
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static RegionView CreateRegionView(Int32 id = 1)
        {
            return new RegionView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static Province CreateProvince(Int32 id = 1)
        {
            return new Province
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static ProvinceView CreateProvinceView(Int32 id = 1)
        {
            return new ProvinceView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static District CreateDistrict(Int32 id = 1)
        {
            return new District
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static DistrictView CreateDistrictView(Int32 id = 1)
        {
            return new DistrictView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static Locality CreateLocality(Int32 id = 1)
        {
            return new Locality
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static LocalityView CreateLocalityView(Int32 id = 1)
        {
            return new LocalityView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static City CreateCity(Int32 id = 1)
        {
            return new City
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static CityView CreateCityView(Int32 id = 1)
        {
            return new CityView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static AdventureworkFacility CreateAdventureworkFacility(Int32 id = 1)
        {
            return new AdventureworkFacility
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static AdventureworkFacilityView CreateAdventureworkFacilityView(Int32 id = 1)
        {
            return new AdventureworkFacilityView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static Tenant CreateTenant(Int32 id = 1)
        {
            return new Tenant
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static TenantView CreateTenantView(Int32 id = 1)
        {
            return new TenantView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static CustomCareType CreateCustomCareType(Int32 id = 1)
        {
            return new CustomCareType
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }
        public static CustomCareTypeView CreateCustomCareTypeView(Int32 id = 1)
        {
            return new CustomCareTypeView
            {
                 Id = id,

                Title = $"Title{id}"
            };
        }

        public static Department CreateDepartment(Int32 id = 1)
        {
            return new Department
            {
                 Id = id
            };
        }
        public static DepartmentView CreateDepartmentView(Int32 id = 1)
        {
            return new DepartmentView
            {
                 Id = id
            };
        }

        public static Employee CreateEmployee(Int32 id = 1)
        {
            return new Employee
            {
                 Id = id
            };
        }
        public static EmployeeView CreateEmployeeView(Int32 id = 1)
        {
            return new EmployeeView
            {
                 Id = id
            };
        }

        public static EmployeeAddress CreateEmployeeAddress(Int32 id = 1)
        {
            return new EmployeeAddress
            {
                 Id = id
            };
        }
        public static EmployeeAddressView CreateEmployeeAddressView(Int32 id = 1)
        {
            return new EmployeeAddressView
            {
                 Id = id
            };
        }

        public static EmployeeDepartmentHistory CreateEmployeedepartmenthistory(Int32 id = 1)
        {
            return new EmployeeDepartmentHistory
            {
                 Id = id
            };
        }
        public static EmployeeDepartmentHistoryView CreateEmployeedepartmenthistoryView(Int32 id = 1)
        {
            return new EmployeeDepartmentHistoryView
            {
                 Id = id
            };
        }

        public static EmployeePayHistory CreateEmployeepayhistory(Int32 id = 1)
        {
            return new EmployeePayHistory
            {
                 Id = id
            };
        }
        public static EmployeePayHistoryView CreateEmployeepayhistoryView(Int32 id = 1)
        {
            return new EmployeePayHistoryView
            {
                 Id = id
            };
        }

        public static JobCandidate CreateJobCandidate(Int32 id = 1)
        {
            return new JobCandidate
            {
                 Id = id
            };
        }
        public static JobCandidateView CreateJobCandidateView(Int32 id = 1)
        {
            return new JobCandidateView
            {
                 Id = id
            };
        }

        public static Shift CreateShift(Int32 id = 1)
        {
            return new Shift
            {
                 Id = id
            };
        }
        public static ShiftView CreateShiftView(Int32 id = 1)
        {
            return new ShiftView
            {
                 Id = id
            };
        }

        public static Address CreateAddress(Int32 id = 1)
        {
            return new Address
            {
                 Id = id
            };
        }
        public static AddressView CreateAddressView(Int32 id = 1)
        {
            return new AddressView
            {
                 Id = id
            };
        }

        public static Addresstype CreateAddresstype(Int32 id = 1)
        {
            return new Addresstype
            {
                 Id = id
            };
        }
        public static AddresstypeView CreateAddresstypeView(Int32 id = 1)
        {
            return new AddresstypeView
            {
                 Id = id
            };
        }

        public static Contact CreateContact(Int32 id = 1)
        {
            return new Contact
            {
                 Id = id
            };
        }
        public static ContactView CreateContactView(Int32 id = 1)
        {
            return new ContactView
            {
                 Id = id
            };
        }

        public static ContactType CreateContactType(Int32 id = 1)
        {
            return new ContactType
            {
                 Id = id
            };
        }
        public static ContactTypeView CreateContactTypeView(Int32 id = 1)
        {
            return new ContactTypeView
            {
                 Id = id
            };
        }

        public static CountryRegion CreateCountryRegion(Int32 id = 1)
        {
            return new CountryRegion
            {
                 Id = id
            };
        }
        public static CountryRegionView CreateCountryRegionView(Int32 id = 1)
        {
            return new CountryRegionView
            {
                 Id = id
            };
        }

        public static StateProvince CreateStateProvince(Int32 id = 1)
        {
            return new StateProvince
            {
                 Id = id
            };
        }
        public static StateProvinceView CreateStateProvinceView(Int32 id = 1)
        {
            return new StateProvinceView
            {
                 Id = id
            };
        }

        public static BillOfMaterial CreateBillOfMaterial(Int32 id = 1)
        {
            return new BillOfMaterial
            {
                 Id = id
            };
        }
        public static BillOfMaterialView CreateBillOfMaterialView(Int32 id = 1)
        {
            return new BillOfMaterialView
            {
                 Id = id
            };
        }

        public static Culture CreateCulture(Int32 id = 1)
        {
            return new Culture
            {
                 Id = id
            };
        }
        public static CultureView CreateCultureView(Int32 id = 1)
        {
            return new CultureView
            {
                 Id = id
            };
        }

        public static Document CreateDocument(Int32 id = 1)
        {
            return new Document
            {
                 Id = id
            };
        }
        public static DocumentView CreateDocumentView(Int32 id = 1)
        {
            return new DocumentView
            {
                 Id = id
            };
        }

        public static Illustration CreateIllustration(Int32 id = 1)
        {
            return new Illustration
            {
                 Id = id
            };
        }
        public static IllustrationView CreateIllustrationView(Int32 id = 1)
        {
            return new IllustrationView
            {
                 Id = id
            };
        }

        public static Location CreateLocation(Int32 id = 1)
        {
            return new Location
            {
                 Id = id
            };
        }
        public static LocationView CreateLocationView(Int32 id = 1)
        {
            return new LocationView
            {
                 Id = id
            };
        }

        public static Product CreateProduct(Int32 id = 1)
        {
            return new Product
            {
                 Id = id
            };
        }
        public static ProductView CreateProductView(Int32 id = 1)
        {
            return new ProductView
            {
                 Id = id
            };
        }

        public static ProductCategory CreateProductCategory(Int32 id = 1)
        {
            return new ProductCategory
            {
                 Id = id
            };
        }
        public static ProductCategoryView CreateProductCategoryView(Int32 id = 1)
        {
            return new ProductCategoryView
            {
                 Id = id
            };
        }

        public static ProductCostHistory CreateProductCostHistory(Int32 id = 1)
        {
            return new ProductCostHistory
            {
                 Id = id
            };
        }
        public static ProductCostHistoryView CreateProductCostHistoryView(Int32 id = 1)
        {
            return new ProductCostHistoryView
            {
                 Id = id
            };
        }

        public static ProductDescription CreateProductDescription(Int32 id = 1)
        {
            return new ProductDescription
            {
                 Id = id
            };
        }
        public static ProductDescriptionView CreateProductDescriptionView(Int32 id = 1)
        {
            return new ProductDescriptionView
            {
                 Id = id
            };
        }

        public static ProductDocument CreateProductDocument(Int32 id = 1)
        {
            return new ProductDocument
            {
                 Id = id
            };
        }
        public static ProductDocumentView CreateProductDocumentView(Int32 id = 1)
        {
            return new ProductDocumentView
            {
                 Id = id
            };
        }

        public static ProductInventory CreateProductInventory(Int32 id = 1)
        {
            return new ProductInventory
            {
                 Id = id
            };
        }
        public static ProductInventoryView CreateProductInventoryView(Int32 id = 1)
        {
            return new ProductInventoryView
            {
                 Id = id
            };
        }

        public static ProductListPriceHistory CreateProductListPriceHistory(Int32 id = 1)
        {
            return new ProductListPriceHistory
            {
                 Id = id
            };
        }
        public static ProductListPriceHistoryView CreateProductListPriceHistoryView(Int32 id = 1)
        {
            return new ProductListPriceHistoryView
            {
                 Id = id
            };
        }

        public static ProductModel CreateProductModel(Int32 id = 1)
        {
            return new ProductModel
            {
                 Id = id
            };
        }
        public static ProductModelView CreateProductModelView(Int32 id = 1)
        {
            return new ProductModelView
            {
                 Id = id
            };
        }

        public static ProductModelIllustration CreateProductModelIllustration(Int32 id = 1)
        {
            return new ProductModelIllustration
            {
                 Id = id
            };
        }
        public static ProductModelIllustrationView CreateProductModelIllustrationView(Int32 id = 1)
        {
            return new ProductModelIllustrationView
            {
                 Id = id
            };
        }

        public static ProductModelProductDescriptionCulture CreateProductModelProductDescriptionCulture(Int32 id = 1)
        {
            return new ProductModelProductDescriptionCulture
            {
                 Id = id
            };
        }
        public static ProductModelProductDescriptionCultureView CreateProductModelProductDescriptionCultureView(Int32 id = 1)
        {
            return new ProductModelProductDescriptionCultureView
            {
                 Id = id
            };
        }

        public static ProductPhoto CreateProductPhoto(Int32 id = 1)
        {
            return new ProductPhoto
            {
                 Id = id
            };
        }
        public static ProductPhotoView CreateProductPhotoView(Int32 id = 1)
        {
            return new ProductPhotoView
            {
                 Id = id
            };
        }

        public static ProductProductPhoto CreateProductProductPhoto(Int32 id = 1)
        {
            return new ProductProductPhoto
            {
                 Id = id
            };
        }
        public static ProductProductPhotoView CreateProductProductPhotoView(Int32 id = 1)
        {
            return new ProductProductPhotoView
            {
                 Id = id
            };
        }

        public static ProductReview CreateProductReview(Int32 id = 1)
        {
            return new ProductReview
            {
                 Id = id
            };
        }
        public static ProductReviewView CreateProductReviewView(Int32 id = 1)
        {
            return new ProductReviewView
            {
                 Id = id
            };
        }

        public static ProductSubcategory CreateProductSubcategory(Int32 id = 1)
        {
            return new ProductSubcategory
            {
                 Id = id
            };
        }
        public static ProductSubcategoryView CreateProductSubcategoryView(Int32 id = 1)
        {
            return new ProductSubcategoryView
            {
                 Id = id
            };
        }

        public static ScrapReason CreateScrapReason(Int32 id = 1)
        {
            return new ScrapReason
            {
                 Id = id
            };
        }
        public static ScrapReasonView CreateScrapReasonView(Int32 id = 1)
        {
            return new ScrapReasonView
            {
                 Id = id
            };
        }

        public static TransactionHistory CreateTransactionHistory(Int32 id = 1)
        {
            return new TransactionHistory
            {
                 Id = id
            };
        }
        public static TransactionHistoryView CreateTransactionHistoryView(Int32 id = 1)
        {
            return new TransactionHistoryView
            {
                 Id = id
            };
        }

        public static TransactionHistoryArchive CreateTransactionHistoryArchive(Int32 id = 1)
        {
            return new TransactionHistoryArchive
            {
                 Id = id
            };
        }
        public static TransactionHistoryArchiveView CreateTransactionHistoryArchiveView(Int32 id = 1)
        {
            return new TransactionHistoryArchiveView
            {
                 Id = id
            };
        }

        public static UnitMeasure CreateUnitMeasure(Int32 id = 1)
        {
            return new UnitMeasure
            {
                 Id = id
            };
        }
        public static UnitMeasureView CreateUnitMeasureView(Int32 id = 1)
        {
            return new UnitMeasureView
            {
                 Id = id
            };
        }

        public static WorkOrder CreateWorkOrder(Int32 id = 1)
        {
            return new WorkOrder
            {
                 Id = id
            };
        }
        public static WorkOrderView CreateWorkOrderView(Int32 id = 1)
        {
            return new WorkOrderView
            {
                 Id = id
            };
        }

        public static WorkOrderRouting CreateWorkOrderRouting(Int32 id = 1)
        {
            return new WorkOrderRouting
            {
                 Id = id
            };
        }
        public static WorkOrderRoutingView CreateWorkOrderRoutingView(Int32 id = 1)
        {
            return new WorkOrderRoutingView
            {
                 Id = id
            };
        }

        public static ProductVendor CreateProductVendor(Int32 id = 1)
        {
            return new ProductVendor
            {
                 Id = id
            };
        }
        public static ProductVendorView CreateProductVendorView(Int32 id = 1)
        {
            return new ProductVendorView
            {
                 Id = id
            };
        }

        public static PurchaseOrderDetail CreatePurchaseOrderDetail(Int32 id = 1)
        {
            return new PurchaseOrderDetail
            {
                 Id = id
            };
        }
        public static PurchaseOrderDetailView CreatePurchaseOrderDetailView(Int32 id = 1)
        {
            return new PurchaseOrderDetailView
            {
                 Id = id
            };
        }

        public static PurchaseOrderHeader CreatePurchaseOrderHeader(Int32 id = 1)
        {
            return new PurchaseOrderHeader
            {
                 Id = id
            };
        }
        public static PurchaseOrderHeaderView CreatePurchaseOrderHeaderView(Int32 id = 1)
        {
            return new PurchaseOrderHeaderView
            {
                 Id = id
            };
        }

        public static ShipMethod CreateShipMethod(Int32 id = 1)
        {
            return new ShipMethod
            {
                 Id = id
            };
        }
        public static ShipMethodView CreateShipMethodView(Int32 id = 1)
        {
            return new ShipMethodView
            {
                 Id = id
            };
        }

        public static Vendor CreateVendor(Int32 id = 1)
        {
            return new Vendor
            {
                 Id = id
            };
        }
        public static VendorView CreateVendorView(Int32 id = 1)
        {
            return new VendorView
            {
                 Id = id
            };
        }

        public static VendorAddress CreateVendorAddress(Int32 id = 1)
        {
            return new VendorAddress
            {
                 Id = id
            };
        }
        public static VendorAddressView CreateVendorAddressView(Int32 id = 1)
        {
            return new VendorAddressView
            {
                 Id = id
            };
        }

        public static VendorContact CreateVendorContact(Int32 id = 1)
        {
            return new VendorContact
            {
                 Id = id
            };
        }
        public static VendorContactView CreateVendorContactView(Int32 id = 1)
        {
            return new VendorContactView
            {
                 Id = id
            };
        }

        public static ContactCreditCard CreateContactCreditCard(Int32 id = 1)
        {
            return new ContactCreditCard
            {
                 Id = id
            };
        }
        public static ContactCreditCardView CreateContactCreditCardView(Int32 id = 1)
        {
            return new ContactCreditCardView
            {
                 Id = id
            };
        }

        public static CountryRegionCurrency CreateCountryRegionCurrency(Int32 id = 1)
        {
            return new CountryRegionCurrency
            {
                 Id = id
            };
        }
        public static CountryRegionCurrencyView CreateCountryRegionCurrencyView(Int32 id = 1)
        {
            return new CountryRegionCurrencyView
            {
                 Id = id
            };
        }

        public static CreditCard CreateCreditCard(Int32 id = 1)
        {
            return new CreditCard
            {
                 Id = id
            };
        }
        public static CreditCardView CreateCreditCardView(Int32 id = 1)
        {
            return new CreditCardView
            {
                 Id = id
            };
        }

        public static Currency CreateCurrency(Int32 id = 1)
        {
            return new Currency
            {
                 Id = id
            };
        }
        public static CurrencyView CreateCurrencyView(Int32 id = 1)
        {
            return new CurrencyView
            {
                 Id = id
            };
        }

        public static CurrencyRate CreateCurrencyRate(Int32 id = 1)
        {
            return new CurrencyRate
            {
                 Id = id
            };
        }
        public static CurrencyRateView CreateCurrencyRateView(Int32 id = 1)
        {
            return new CurrencyRateView
            {
                 Id = id
            };
        }

        public static Customer CreateCustomer(Int32 id = 1)
        {
            return new Customer
            {
                 Id = id
            };
        }
        public static CustomerView CreateCustomerView(Int32 id = 1)
        {
            return new CustomerView
            {
                 Id = id
            };
        }

        public static CustomerAddress CreateCustomerAddress(Int32 id = 1)
        {
            return new CustomerAddress
            {
                 Id = id
            };
        }
        public static CustomerAddressView CreateCustomerAddressView(Int32 id = 1)
        {
            return new CustomerAddressView
            {
                 Id = id
            };
        }

        public static Individual CreateIndividual(Int32 id = 1)
        {
            return new Individual
            {
                 Id = id
            };
        }
        public static IndividualView CreateIndividualView(Int32 id = 1)
        {
            return new IndividualView
            {
                 Id = id
            };
        }

        public static SalesOrderDetail CreateSalesOrderDetail(Int32 id = 1)
        {
            return new SalesOrderDetail
            {
                 Id = id
            };
        }
        public static SalesOrderDetailView CreateSalesOrderDetailView(Int32 id = 1)
        {
            return new SalesOrderDetailView
            {
                 Id = id
            };
        }

        public static SalesOrderHeader CreateSalesOrderHeader(Int32 id = 1)
        {
            return new SalesOrderHeader
            {
                 Id = id
            };
        }
        public static SalesOrderHeaderView CreateSalesOrderHeaderView(Int32 id = 1)
        {
            return new SalesOrderHeaderView
            {
                 Id = id
            };
        }

        public static SalesOrderHeaderSalesReason CreateSalesOrderHeaderSalesReason(Int32 id = 1)
        {
            return new SalesOrderHeaderSalesReason
            {
                 Id = id
            };
        }
        public static SalesOrderHeaderSalesReasonView CreateSalesOrderHeaderSalesReasonView(Int32 id = 1)
        {
            return new SalesOrderHeaderSalesReasonView
            {
                 Id = id
            };
        }

        public static SalesPerson CreateSalesPerson(Int32 id = 1)
        {
            return new SalesPerson
            {
                 Id = id
            };
        }
        public static SalesPersonView CreateSalesPersonView(Int32 id = 1)
        {
            return new SalesPersonView
            {
                 Id = id
            };
        }

        public static SalesPersonQuotaHistory CreateSalesPersonQuotaHistory(Int32 id = 1)
        {
            return new SalesPersonQuotaHistory
            {
                 Id = id
            };
        }
        public static SalesPersonQuotaHistoryView CreateSalesPersonQuotaHistoryView(Int32 id = 1)
        {
            return new SalesPersonQuotaHistoryView
            {
                 Id = id
            };
        }

        public static SalesReason CreateSalesReason(Int32 id = 1)
        {
            return new SalesReason
            {
                 Id = id
            };
        }
        public static SalesReasonView CreateSalesReasonView(Int32 id = 1)
        {
            return new SalesReasonView
            {
                 Id = id
            };
        }

        public static SalesTaxRate CreateSalesTaxRate(Int32 id = 1)
        {
            return new SalesTaxRate
            {
                 Id = id
            };
        }
        public static SalesTaxRateView CreateSalesTaxRateView(Int32 id = 1)
        {
            return new SalesTaxRateView
            {
                 Id = id
            };
        }

        public static SalesTerritory CreateSalesTerritory(Int32 id = 1)
        {
            return new SalesTerritory
            {
                 Id = id
            };
        }
        public static SalesTerritoryView CreateSalesTerritoryView(Int32 id = 1)
        {
            return new SalesTerritoryView
            {
                 Id = id
            };
        }

        public static SalesTerritoryHistory CreateSalesTerritoryHistory(Int32 id = 1)
        {
            return new SalesTerritoryHistory
            {
                 Id = id
            };
        }
        public static SalesTerritoryHistoryView CreateSalesTerritoryHistoryView(Int32 id = 1)
        {
            return new SalesTerritoryHistoryView
            {
                 Id = id
            };
        }

        public static ShoppingCartItem CreateShoppingCartItem(Int32 id = 1)
        {
            return new ShoppingCartItem
            {
                 Id = id
            };
        }
        public static ShoppingCartItemView CreateShoppingCartItemView(Int32 id = 1)
        {
            return new ShoppingCartItemView
            {
                 Id = id
            };
        }

        public static SpecialOffer CreateSpecialOffer(Int32 id = 1)
        {
            return new SpecialOffer
            {
                 Id = id
            };
        }
        public static SpecialOfferView CreateSpecialOfferView(Int32 id = 1)
        {
            return new SpecialOfferView
            {
                 Id = id
            };
        }

        public static SpecialOfferProduct CreateSpecialOfferProduct(Int32 id = 1)
        {
            return new SpecialOfferProduct
            {
                 Id = id
            };
        }
        public static SpecialOfferProductView CreateSpecialOfferProductView(Int32 id = 1)
        {
            return new SpecialOfferProductView
            {
                 Id = id
            };
        }

        public static Store CreateStore(Int32 id = 1)
        {
            return new Store
            {
                 Id = id
            };
        }
        public static StoreView CreateStoreView(Int32 id = 1)
        {
            return new StoreView
            {
                 Id = id
            };
        }

        public static StoreContact CreateStoreContact(Int32 id = 1)
        {
            return new StoreContact
            {
                 Id = id
            };
        }
        public static StoreContactView CreateStoreContactView(Int32 id = 1)
        {
            return new StoreContactView
            {
                 Id = id
            };
        }
    }
}
