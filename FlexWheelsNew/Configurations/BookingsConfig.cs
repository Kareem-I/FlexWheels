using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexWheelsNew.Models;

namespace FlexWheelsNew.Configurations
{
    public class BookingsConfig : IEntityTypeConfiguration<Bookings>
    {
        public void Configure(EntityTypeBuilder<Bookings> builder)
        {
            builder
                .HasKey(x => x.booking_id); 

            builder
                .Property(x => x.booking_id)
                .ValueGeneratedOnAdd()
                .IsRequired();


            builder
                .Property(x => x.rent_date)
                .IsRequired(false);

            builder
           .Property(x => x.return_date)
           .IsRequired(false);

            builder
           .Property(x => x.price)
           .IsRequired();

        }
    }
}