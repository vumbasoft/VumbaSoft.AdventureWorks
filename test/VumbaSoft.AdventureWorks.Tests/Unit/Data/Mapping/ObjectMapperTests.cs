﻿using AutoMapper;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using Xunit;

namespace VumbaSoft.AdventureWorks.Data.Mapping.Tests
{
    public class ObjectMapperTests
    {
        static ObjectMapperTests()
        {
            ObjectMapper.MapObjects();
        }

        [Fact]
        public void MapRoles_Role_RoleView()
        {
            Role expected = ObjectsFactory.CreateRole();
            RoleView actual = Mapper.Map<RoleView>(expected);

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Id, actual.Id);
            Assert.NotNull(actual.Permissions);
        }

        [Fact]
        public void MapRoles_RoleView_Role()
        {
            RoleView expected = ObjectsFactory.CreateRoleView();
            Role actual = Mapper.Map<Role>(expected);

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Empty(actual.Permissions);
        }
    }
}
