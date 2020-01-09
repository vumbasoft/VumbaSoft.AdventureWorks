using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace VumbaSoft.AdventureWorks.Data.Migrations.Tests
{
    public class InitialDataTests : IDisposable
    {
        private Configuration configuration;
        private TestingContext context;

        public InitialDataTests()
        {
            context = new TestingContext();
            configuration = new Configuration(context, null);
            configuration.SeedData();
        }
        public void Dispose()
        {
            configuration.Dispose();
            context.Dispose();
        }

        [Fact]
        public void RolesTable_HasSysAdmin()
        {
            Assert.Single(context.Set<Role>(), role => role.Title == "Sys_Admin");
        }

        [Fact]
        public void AccountsTable_HasAdmin()
        {
            Assert.Single(context.Set<Account>(), account => account.Username == "admin" && account.Role?.Title == "Sys_Admin");
        }

        [Theory]
        [InlineData("Administration", "Accounts", "Index")]
        [InlineData("Administration", "Accounts", "Create")]
        [InlineData("Administration", "Accounts", "Details")]
        [InlineData("Administration", "Accounts", "Edit")]
        [InlineData("Administration", "Roles", "Index")]
        [InlineData("Administration", "Roles", "Create")]
        [InlineData("Administration", "Roles", "Details")]
        [InlineData("Administration", "Roles", "Edit")]
        [InlineData("Administration", "Roles", "Delete")]
        [InlineData("Demografic", "Continents", "Index")]
        [InlineData("Demografic", "Continents", "Create")]
        [InlineData("Demografic", "Continents", "Details")]
        [InlineData("Demografic", "Continents", "Edit")]
        [InlineData("Demografic", "Continents", "Delete")]
        [InlineData("Demografic", "ContinentRegions", "Index")]
        [InlineData("Demografic", "ContinentRegions", "Create")]
        [InlineData("Demografic", "ContinentRegions", "Details")]
        [InlineData("Demografic", "ContinentRegions", "Edit")]
        [InlineData("Demografic", "ContinentRegions", "Delete")]
        [InlineData("Demografic", "Countries", "Index")]
        [InlineData("Demografic", "Countries", "Create")]
        [InlineData("Demografic", "Countries", "Details")]
        [InlineData("Demografic", "Countries", "Edit")]
        [InlineData("Demografic", "Countries", "Delete")]
        [InlineData("Demografic", "Regions", "Index")]
        [InlineData("Demografic", "Regions", "Create")]
        [InlineData("Demografic", "Regions", "Details")]
        [InlineData("Demografic", "Regions", "Edit")]
        [InlineData("Demografic", "Regions", "Delete")]
        [InlineData("Demografic", "Provinces", "Index")]
        [InlineData("Demografic", "Provinces", "Create")]
        [InlineData("Demografic", "Provinces", "Details")]
        [InlineData("Demografic", "Provinces", "Edit")]
        [InlineData("Demografic", "Provinces", "Delete")]
        [InlineData("Demografic", "Districts", "Index")]
        [InlineData("Demografic", "Districts", "Create")]
        [InlineData("Demografic", "Districts", "Details")]
        [InlineData("Demografic", "Districts", "Edit")]
        [InlineData("Demografic", "Districts", "Delete")]
        [InlineData("Demografic", "Localities", "Index")]
        [InlineData("Demografic", "Localities", "Create")]
        [InlineData("Demografic", "Localities", "Details")]
        [InlineData("Demografic", "Localities", "Edit")]
        [InlineData("Demografic", "Localities", "Delete")]
        [InlineData("Demografic", "Cities", "Index")]
        [InlineData("Demografic", "Cities", "Create")]
        [InlineData("Demografic", "Cities", "Details")]
        [InlineData("Demografic", "Cities", "Edit")]
        [InlineData("Demografic", "Cities", "Delete")]
        [InlineData("Demografic", "AdventureworkFacilities", "Index")]
        [InlineData("Demografic", "AdventureworkFacilities", "Create")]
        [InlineData("Demografic", "AdventureworkFacilities", "Details")]
        [InlineData("Demografic", "AdventureworkFacilities", "Edit")]
        [InlineData("Demografic", "AdventureworkFacilities", "Delete")]
        [InlineData("Demografic", "Tenants", "Index")]
        [InlineData("Demografic", "Tenants", "Create")]
        [InlineData("Demografic", "Tenants", "Details")]
        [InlineData("Demografic", "Tenants", "Edit")]
        [InlineData("Demografic", "Tenants", "Delete")]
        [InlineData("Demograficdotnet", "Tenants", "Index")]
        [InlineData("Demograficdotnet", "Tenants", "Create")]
        [InlineData("Demograficdotnet", "Tenants", "Details")]
        [InlineData("Demograficdotnet", "Tenants", "Edit")]
        [InlineData("Demograficdotnet", "Tenants", "Delete")]
        [InlineData("LookupSettings", "CustomCareTypes", "Index")]
        [InlineData("LookupSettings", "CustomCareTypes", "Create")]
        [InlineData("LookupSettings", "CustomCareTypes", "Details")]
        [InlineData("LookupSettings", "CustomCareTypes", "Edit")]
        [InlineData("LookupSettings", "CustomCareTypes", "Delete")]
        public void PermissionsTable_HasPermission(String area, String controller, String action)
        {
            Assert.Single(context.Set<Permission>(), permission =>
                permission.Controller == controller &&
                permission.Action == action &&
                permission.Area == area);
        }

        [Fact]
        public void PermissionsTable_HasExactNumberOfPermissions()
        {
            Int32 actual = context.Set<Permission>().Count();
            Int32 expected = GetType()
                .GetMethod(nameof(PermissionsTable_HasPermission))!
                .GetCustomAttributes<InlineDataAttribute>()
                .Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RolesPermissionsTable_HasAllSysAdminPermissions()
        {
            IEnumerable<Int32> expected = context
                .Set<Permission>()
                .Select(permission => permission.Id)
                .OrderBy(permissionId => permissionId);

            IEnumerable<Int32> actual = context
                .Set<RolePermission>()
                .Where(permission => permission.Role.Title == "Sys_Admin")
                .Select(rolePermission => rolePermission.PermissionId)
                .OrderBy(permissionId => permissionId);

            Assert.Equal(expected, actual);
        }
    }
}
