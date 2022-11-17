using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FlexWheelsNew.Models;
using FlexWheelsNew.Configurations;

namespace FlexWheelsNew
{
    public class Database : DbContext
    {
        public DbSet<Bicycle> Bicycle { get; set; }
       
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Bicycle_bookings> Bicycle_bookings { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Store> Store { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FlexWheelsDatabase;Trusted_Connection=True;");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder
                .ApplyConfiguration(new BicycleConfig());

            modelBuilder
                .ApplyConfiguration(new BookingsConfig());

            modelBuilder
                .ApplyConfiguration(new Bicycle_bookingsConfig());


            modelBuilder
                .ApplyConfiguration(new CustomerConfig());

            modelBuilder
               .ApplyConfiguration(new StoreConfig());




        }
    }
}
