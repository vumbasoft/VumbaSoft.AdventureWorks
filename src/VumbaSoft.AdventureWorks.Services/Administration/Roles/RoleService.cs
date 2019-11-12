﻿using VumbaSoft.AdventureWorks.Components.Extensions;
using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public virtual void SeedPermissions(RoleView view)
        {
            MvcTreeNode root = new MvcTreeNode(Resource.ForString("All"));
            view.Permissions.Nodes.Add(root);

            foreach (IGrouping<String?, PermissionView> area in GetAllPermissions().GroupBy(permission => permission.Area))
            {
                List<MvcTreeNode> nodes = new List<MvcTreeNode>();
                foreach (IGrouping<String, PermissionView> controller in area.GroupBy(permission => permission.Controller!))
                {
                    MvcTreeNode node = new MvcTreeNode(controller.Key);
                    foreach (PermissionView permission in controller)
                        node.Children.Add(new MvcTreeNode(permission.Id, permission.Action!));

                    nodes.Add(node);
                }

                if (area.Key == null)
                    root.Children.AddRange(nodes);
                else
                    root.Children.Add(new MvcTreeNode(area.Key) { Children = nodes });
            }
        }

        public IQueryable<RoleView> GetViews()
        {
            return UnitOfWork
                .Select<Role>()
                .To<RoleView>()
                .OrderByDescending(role => role.Id);
        }
        public RoleView? GetView(Int32 id)
        {
            RoleView? role = UnitOfWork.GetAs<Role, RoleView>(id);
            if (role != null)
            {
                role.Permissions.SelectedIds = new HashSet<Int32>(UnitOfWork
                    .Select<RolePermission>()
                    .Where(rolePermission => rolePermission.RoleId == role.Id)
                    .Select(rolePermission => rolePermission.PermissionId));

                SeedPermissions(role);
            }

            return role;
        }

        public void Create(RoleView view)
        {
            Role role = UnitOfWork.To<Role>(view);
            foreach (Int32 permissionId in view.Permissions.SelectedIds)
                role.Permissions.Add(new RolePermission
                {
                    RoleId = role.Id,
                    PermissionId = permissionId
                });

            UnitOfWork.Insert(role);
            UnitOfWork.Commit();
        }
        public void Edit(RoleView view)
        {
            List<Int32> permissions = view.Permissions.SelectedIds.ToList();
            Role role = UnitOfWork.Get<Role>(view.Id)!;
            role.Title = view.Title!;

            foreach (RolePermission rolePermission in role.Permissions.ToArray())
                if (!permissions.Remove(rolePermission.PermissionId))
                    UnitOfWork.Delete(rolePermission);

            foreach (Int32 permissionId in permissions)
                UnitOfWork.Insert(new RolePermission { RoleId = role.Id, PermissionId = permissionId });

            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            Role role = UnitOfWork.Get<Role>(id)!;
            role.Accounts.ForEach(account => account.RoleId = null);

            UnitOfWork.DeleteRange(role.Permissions);
            UnitOfWork.Delete(role);
            UnitOfWork.Commit();
        }

        private IEnumerable<PermissionView> GetAllPermissions()
        {
            return UnitOfWork
                .Select<Permission>()
                .ToArray()
                .Select(permission => new PermissionView
                {
                    Id = permission.Id,
                    Action = Resource.ForAction(permission.Action),
                    Area = permission.Area == null ? null : Resource.ForArea(permission.Area),
                    Controller = Resource.ForController(permission.Area + permission.Controller)
                })
                .OrderBy(permission => permission.Area ?? permission.Controller)
                .ThenBy(permission => permission.Controller)
                .ThenBy(permission => permission.Action);
        }
    }
}
