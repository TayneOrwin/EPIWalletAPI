using EPIWalletAPI.Models.Employee;
using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPIWalletAPI.Models;



namespace EPIWalletAPI.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Event> Events { get; set; }

        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        
        public DbSet<Titles> Titles { get; set; }
        
        public DbSet<Employees> Employees { get; set; }


   

        public DbSet<VendorAddress> VendorAddresses { get; set; }
        public DbSet<Vendor> Vendors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasData(
                new
                {
                    EventID = 1,
                    name = "Work Social",
                    description = "Organized work social by the team",
                    date = DateTime.Parse("Jan 1, 2009"),
                    TypeID = 1

                }

                );




            modelBuilder.Entity<Event>()
                .HasData(
                new
                {
                    EventID = 2,
                    name = "Morning Social",
                    description = "Organized Breakfast",
             date = DateTime.Parse("Jan 3, 2009"),
 
            TypeID = 1

                }

                );



            modelBuilder.Entity<ExpenseType>()
                .HasData(
                new
                {
                    TypeID = 1,
                    Type = "Social",
                  EventID = 1

                }

                );



            modelBuilder.Entity<Sponsor>()
             .HasData(
             new
             {
                 SponsorID = 1,
                 EventID = 17,
                 name = "Bryan",
                 Surname = "Heuston",
                 Amount = 399.22,
                 Company = "Striker Investments",
                 Email = "strikerproducts@gmail.com"
             }
           );



            modelBuilder.Entity<Vendor>()
      .HasData(
      new
      {
          VendorID = 1,
          Name = "Bryan",
          Description = "Main Bakery on 4th Street",
          Availability = true,
          VendorAddressID = 1,
      }
    );



            modelBuilder.Entity<VendorAddress>()
      .HasData(
      new
      {
          VendorAddressID = 1,
          VendorID = 1,
          Country = "South Africa",
          Province = "Gauteng",
         Suburb = "Menlo Park",
         AddressLine1 =  "578 Saint Street",
         AddressLine2= "No 57"
      }
    );








        }


    }
}
