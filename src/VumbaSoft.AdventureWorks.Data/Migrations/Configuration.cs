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
                new Permission { Area = "LookupSettings", Controller = "CustomCareTypes", Action = "Delete" }
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
