using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexWheelsNew.Models;

namespace FlexWheelsNew.Configurations
{
    public class Bicycle_bookingsConfig : IEntityTypeConfiguration<Bicycle_bookings>
    {
        public void Configure(EntityTypeBuilder<Bicycle_bookings> builder)
        {
            builder
                .HasKey(x => new { x.bicycle_id, x.booking_id });

         
        }
    }
}