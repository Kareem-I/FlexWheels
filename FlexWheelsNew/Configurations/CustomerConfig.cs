using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexWheelsNew.Models;

namespace FlexWheelsNew.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(x => x.CID);
            builder
               .Property(x => x.CID)
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder
               .Property(x => x.SocialSecurityNumber)
               .IsRequired();

            builder
                .Property(x => x.firstname)
                .IsRequired();

            builder
           .Property(x => x.lastname)
           .IsRequired();

            builder
           .Property(x => x.phone_number)
           .IsRequired();

            builder
           .Property(x => x.email)
           .IsRequired();

            builder
                 .HasMany(b => b.Bookings)
                 .WithOne(c => c.Customer)
                 .HasForeignKey(x => x.booking_id)
                 ;
            

        }
    }
}