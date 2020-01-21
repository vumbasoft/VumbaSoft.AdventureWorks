using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VumbaSoft.AdventureWorks.Components.Mvc;
using VumbaSoft.AdventureWorks.Data.Mapping;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;
using System.Reflection;

namespace VumbaSoft.AdventureWorks.Data.Core
{
    public class Context : DbContext
    {
        static Context()
        {
            ObjectMapper.MapObjects();
        }
        protected Context()
        {
        }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Type[] models = typeof(BaseModel)
                .Assembly
                .GetTypes()
                .Where(type =>
                    type.IsAbstract == false &&
                    typeof(BaseModel).IsAssignableFrom(type))
                .ToArray();

            foreach (Type model in models)
                if (builder.Model.FindEntityType(model.FullName) == null)
                    builder.Model.AddEntityType(model);


            //TODO: Pending implementation of defoult setting of HasMaxLent to String properties to 128

            //foreach (var property in builder.Model
            //                                .GetEntityTypes()
            //                                .SelectMany(t => t.GetProperties())
            //                                .Where(p => p.ClrType == typeof(decimal) ||
            //                                p.ClrType == typeof(decimal?))
            //                                .Select(p => builder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name))
            //        )
            //            {
            //                property.HasColumnType("decimal(18,4)");
            //            }


            foreach (IMutableEntityType entity in builder.Model.GetEntityTypes())
                foreach (PropertyInfo property in entity.ClrType.GetProperties())
                    {
                        if (typeof(Decimal?).IsAssignableFrom(property.PropertyType))
                            if (property.GetCustomAttribute<NumberAttribute>(false) is NumberAttribute number)
                                builder.Entity(entity.ClrType).Property(property.Name).HasColumnType($"decimal({number.Precision},{number.Scale})");
                            else
                                throw new Exception($"Decimal property has to have {nameof(NumberAttribute)} specified. Default [{nameof(NumberAttribute)[0..^9]}(18, 2)]");

                        if (property.GetCustomAttribute<IndexAttribute>(false) is IndexAttribute index)
                            builder.Entity(entity.ClrType).HasIndex(property.Name).IsUnique(index.IsUnique);

                        //TODO: Pending implementation of defoult setting of HasMaxLent to String properties to 128
                        if (typeof(String).IsAssignableFrom(property.PropertyType))
                            builder.Entity(entity.ClrType).Property(property.Name).HasMaxLength(128);
                    }

                foreach (IMutableForeignKey key in builder.Model.GetEntityTypes().SelectMany(entity => entity.GetForeignKeys()))
                    key.DeleteBehavior = DeleteBehavior.Restrict;
            
            //TODO: Bulk copy all configuration Fuent API to configuration
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
        }
    }
}
