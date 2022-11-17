using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexWheelsNew.Models;

namespace FlexWheelsNew.Configurations
{
    public class BicycleConfig : IEntityTypeConfiguration<Bicycle>
    {
        public void Configure(EntityTypeBuilder<Bicycle> builder)
        {
            builder
                .HasKey(x => x.bicycle_id);

            builder
                .Property(x => x.bicycle_id)
                .ValueGeneratedOnAdd()
                .IsRequired();


            builder
                .Property(x => x.bicycle_brandname)
                .IsRequired();
            builder
               .Property(x => x.bicycleprice)
               .IsRequired();


            builder            // The connected foreignkey to connect the bicycle to a store
                .HasOne(y => y.Store)
                .WithMany(x => x.Bicycle)
                .IsRequired(true);

         

        }
    }
}
