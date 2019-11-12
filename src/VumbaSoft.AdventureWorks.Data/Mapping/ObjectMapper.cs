﻿using AutoMapper;
using AutoMapper.Configuration;
using VumbaSoft.AdventureWorks.Objects;
using System.Collections.Generic;

namespace VumbaSoft.AdventureWorks.Data.Mapping
{
    public class ObjectMapper
    {
        public static void MapObjects()
        {
            Mapper.Reset();
            Mapper.Initialize(Map());
        }

        private MapperConfigurationExpression Configuration { get; }

        private ObjectMapper(MapperConfigurationExpression configuration)
        {
            Configuration = configuration;
            Configuration.ValidateInlineMaps = false;
            Configuration.AddConditionalObjectMapper().Conventions.Add(pair => pair.SourceType.Namespace != "Castle.Proxies");
        }

        private static MapperConfigurationExpression Map()
        {
            ObjectMapper mapper = new ObjectMapper(new MapperConfigurationExpression());

            mapper.MapRoles();

            return mapper.Configuration;
        }

        private void MapRoles()
        {
            Configuration.CreateMap<Role, RoleView>()
                .ForMember(role => role.Permissions, member => member.Ignore());
            Configuration.CreateMap<RoleView, Role>()
                .ForMember(role => role.Permissions, member => member.MapFrom(role => new List<RolePermission>()));
        }
    }
}
