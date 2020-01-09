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
    }
}
