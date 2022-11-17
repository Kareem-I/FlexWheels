using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexWheelsNew.Models;

namespace FlexWheelsNew.Configurations
{
    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .HasKey(x => x.StoreID);

            builder
              .Property(x => x.StoreID)
              .ValueGeneratedOnAdd()
              .IsRequired(true);

            builder
                .Property(x => x.StoreLocation)
                .IsRequired();

            builder
                .HasMany(x => x.Bicycle)
                .WithOne(x => x.Store)
                .IsRequired(false);

            builder
                .HasMany(x => x.Bicycle)
                .WithOne(y => y.Store)
                .IsRequired(false);
        }
    }
}
