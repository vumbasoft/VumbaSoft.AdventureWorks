using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VumbaSoft.AdventureWorks.Objects;

namespace VumbaSoft.AdventureWorks.Data.FluentApiConfig
{
    class ContinentConfiguration : IEntityTypeConfiguration<Continent>
    {
        //TODO: Create individual fluent API configuration files
        public void Configure(EntityTypeBuilder<Continent> builder)
        {
            builder.Property(p => p.Remarks).HasMaxLength(128);
        }
    }
}
