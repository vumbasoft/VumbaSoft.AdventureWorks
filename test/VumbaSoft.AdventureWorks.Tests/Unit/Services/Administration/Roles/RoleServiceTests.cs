﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VumbaSoft.AdventureWorks.Components.Extensions;
using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Resources;
using VumbaSoft.AdventureWorks.Tests;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace VumbaSoft.AdventureWorks.Services.Tests
{
    public class RoleServiceTests : IDisposable
    {
        private TestingContext context;
        private RoleService service;
        private Role role;

        public RoleServiceTests()
        {
            context = new TestingContext();
            service = Substitute.ForPartsOf<RoleService>(new UnitOfWork(new TestingContext(context)));

            role = SetUpData();
        }
        public void Dispose()
        {
            context.Dispose();
            service.Dispose();
        }

        [Fact]
        public void SeedPermissions_FirstDepth()
        {
            RoleView view = ObjectsFactory.CreateRoleView();

            service.SeedPermissions(view);

            List<MvcTreeNode> expected = CreatePermissions().Nodes;
            List<MvcTreeNode> actual = view.Permissions.Nodes;

            for (Int32 i = 0; i < expected.Count || i < actual.Count; i++)
            {
                Assert.Equal(expected[i].Id, actual[i].Id);
                Assert.Equal(expected[i].Title, actual[i].Title);
                Assert.Equal(expected[i].Children.Count, actual[i].Children.Count);
            }
        }

        [Fact]
        public void SeedPermissions_SecondDepth()
        {
            RoleView view = ObjectsFactory.CreateRoleView();

            service.SeedPermissions(view);

            List<MvcTreeNode> expected = CreatePermissions().Nodes.SelectMany(node => node.Children).ToList();
            List<MvcTreeNode> actual = view.Permissions.Nodes.SelectMany(node => node.Children).ToList();

            for (Int32 i = 0; i < expected.Count || i < actual.Count; i++)
            {
                Assert.Equal(expected[i].Id, actual[i].Id);
                Assert.Equal(expected[i].Title, actual[i].Title);
                Assert.Equal(expected[i].Children.Count, actual[i].Children.Count);
            }
        }

        [Fact]
        public void SeedPermissions_ThirdDepth()
        {
            RoleView view = ObjectsFactory.CreateRoleView();

            service.SeedPermissions(view);

            List<MvcTreeNode> expected = CreatePermissions().Nodes.SelectMany(node => node.Children).SelectMany(node => node.Children).OrderBy(node => node.Id).ToList();
            List<MvcTreeNode> actual = view.Permissions.Nodes.SelectMany(node => node.Children).SelectMany(node => node.Children).OrderBy(node => node.Id).ToList();

            for (Int32 i = 0; i < expected.Count || i < actual.Count; i++)
            {
                Assert.Equal(expected[i].Id, actual[i].Id);
                Assert.Equal(expected[i].Title, actual[i].Title);
                Assert.Equal(expected[i].Children.Count, actual[i].Children.Count);
            }
        }

        [Fact]
        public void SeedPermissions_BranchesWithoutId()
        {
            RoleView view = ObjectsFactory.CreateRoleView();

            service.SeedPermissions(view);

            IEnumerable<MvcTreeNode> nodes = view.Permissions.Nodes;
            IEnumerable<MvcTreeNode> branches = GetBranchNodes(nodes);

            Assert.Empty(branches.Where(branch => branch.Id != null));
        }

        [Fact]
        public void SeedPermissions_LeafsWithId()
        {
            RoleView view = ObjectsFactory.CreateRoleView();

            service.SeedPermissions(view);

            IEnumerable<MvcTreeNode> nodes = view.Permissions.Nodes;
            IEnumerable<MvcTreeNode> leafs = GetLeafNodes(nodes);

            Assert.Empty(leafs.Where(leaf => leaf.Id == null));
        }

        [Fact]
        public void GetViews_ReturnsRoleViews()
        {
            RoleView[] actual = service.GetViews().ToArray();
            RoleView[] expected = context
                .Set<Role>()
                .AsNoTracking()
                .ProjectTo<RoleView>()
                .OrderByDescending(view => view.Id)
                .ToArray();

            for (Int32 i = 0; i < expected.Length || i < actual.Length; i++)
            {
                Assert.Equal(expected[i].Permissions.SelectedIds, actual[i].Permissions.SelectedIds);
                Assert.Equal(expected[i].CreationDate, actual[i].CreationDate);
                Assert.Equal(expected[i].Title, actual[i].Title);
                Assert.Equal(expected[i].Id, actual[i].Id);
            }
        }

        [Fact]
        public void GetView_NoRole_ReturnsNull()
        {
            Assert.Null(service.GetView(0));
        }

        [Fact]
        public void GetView_ReturnsViewById()
        {
            service.When(sub => sub.SeedPermissions(Arg.Any<RoleView>())).DoNotCallBase();

            RoleView expected = Mapper.Map<RoleView>(role);
            RoleView actual = service.GetView(role.Id)!;

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.NotEmpty(actual.Permissions.SelectedIds);
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public void GetView_SetsSelectedIds()
        {
            service.When(sub => sub.SeedPermissions(Arg.Any<RoleView>())).DoNotCallBase();

            IEnumerable<Int32> expected = role.Permissions.Select(rolePermission => rolePermission.PermissionId).OrderBy(id => id);
            IEnumerable<Int32> actual = service.GetView(role.Id)!.Permissions.SelectedIds.OrderBy(id => id);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetView_SeedsPermissions()
        {
            service.When(sub => sub.SeedPermissions(Arg.Any<RoleView>())).DoNotCallBase();

            RoleView view = service.GetView(role.Id)!;

            service.Received().SeedPermissions(view);
        }

        [Fact]
        public void Create_Role()
        {
            RoleView view = ObjectsFactory.CreateRoleView();

            service.Create(view);

            Role actual = context.Set<Role>().AsNoTracking().Single(model => model.Id != role.Id);
            RoleView expected = view;

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Title, actual.Title);
        }

        [Fact]
        public void Create_RolePermissions()
        {
            RoleView view = ObjectsFactory.CreateRoleView();
            view.Permissions = CreatePermissions();

            service.Create(view);

            IEnumerable<Int32> expected = view.Permissions.SelectedIds.OrderBy(permissionId => permissionId);
            IEnumerable<Int32> actual = context
                .Set<RolePermission>()
                .AsNoTracking()
                .Where(rolePermission => rolePermission.RoleId != role.Id)
                .Select(rolePermission => rolePermission.PermissionId)
                .OrderBy(permissionId => permissionId);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Edit_Role()
        {
            RoleView view = ObjectsFactory.CreateRoleView();
            view.Title = role.Title += "Test";

            service.Edit(view);

            Role actual = context.Set<Role>().AsNoTracking().Single();
            Role expected = role;

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public void Edit_RolePermissions()
        {
            Permission permission = ObjectsFactory.CreatePermission(100);
            context.Add(permission);
            context.SaveChanges();

            RoleView view = ObjectsFactory.CreateRoleView();
            view.Permissions = CreatePermissions();
            view.Permissions.SelectedIds.Remove(view.Permissions.SelectedIds.First());
            view.Permissions.SelectedIds.Add(permission.Id);

            service.Edit(view);

            IEnumerable<Int32> actual = context.Set<RolePermission>().AsNoTracking().Select(rolePermission => rolePermission.PermissionId).OrderBy(permissionId => permissionId);
            IEnumerable<Int32> expected = view.Permissions.SelectedIds.OrderBy(permissionId => permissionId);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_NullsAccountRoles()
        {
            Account account = ObjectsFactory.CreateAccount();
            account.RoleId = role.Id;
            account.Role = null;

            context.Add(account);
            context.SaveChanges();

            service.Delete(role.Id);

            Assert.Contains(context.Set<Account>().AsNoTracking(), model => model.Id == account.Id && model.RoleId == null);
        }

        [Fact]
        public void Delete_Role()
        {
            service.Delete(role.Id);

            Assert.Empty(context.Set<Role>().AsNoTracking());
        }

        private Role SetUpData()
        {
            Role role = ObjectsFactory.CreateRole();
            foreach (String controller in new[] { "Roles", "Profile" })
                foreach (String action in new[] { "Edit", "Delete" })
                    role.Permissions.Add(new RolePermission
                    {
                        Permission = new Permission
                        {
                            Area = controller == "Roles" ? "Administration" : null,
                            Controller = controller,
                            Action = action
                        }
                    });

            context.Add(role);
            context.SaveChanges();

            return role;
        }

        private MvcTree CreatePermissions()
        {
            MvcTreeNode root = new MvcTreeNode(Resource.ForString("All"));
            MvcTree expectedTree = new MvcTree();

            expectedTree.Nodes.Add(root);
            expectedTree.SelectedIds = new HashSet<Int32>(role.Permissions.Select(rolePermission => rolePermission.PermissionId));

            IEnumerable<PermissionView> permissions = role
                .Permissions
                .Select(rolePermission => rolePermission.Permission)
                .Select(permission => new PermissionView
                {
                    Id = permission.Id,
                    Action = Resource.ForAction(permission.Action),
                    Area = permission.Area == null ? null : Resource.ForArea(permission.Area),
                    Controller = Resource.ForController(permission.Area + permission.Controller)
                });

            foreach (IGrouping<String?, PermissionView> area in permissions.GroupBy(permission => permission.Area).OrderBy(permission => permission.Key ?? permission.FirstOrDefault().Controller))
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

            return expectedTree;
        }

        private IEnumerable<MvcTreeNode> GetLeafNodes(IEnumerable<MvcTreeNode> nodes)
        {
            List<MvcTreeNode> leafs = nodes.Where(node => node.Children.Count == 0).ToList();
            foreach (MvcTreeNode branch in nodes.Where(node => node.Children.Count > 0))
                leafs.AddRange(GetLeafNodes(branch.Children));

            return leafs;
        }
        private IEnumerable<MvcTreeNode> GetBranchNodes(IEnumerable<MvcTreeNode> nodes)
        {
            List<MvcTreeNode> branches = nodes.Where(node => node.Children.Count > 0).ToList();
            foreach (MvcTreeNode branch in branches.ToArray())
                branches.AddRange(GetBranchNodes(branch.Children));

            return branches;
        }
    }
}
