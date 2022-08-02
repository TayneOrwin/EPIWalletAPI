using EPIWalletAPI.Models.Employee;


using EPIWalletAPI.Models.EventInvite;

using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EPIWalletAPI.Models.Identity;
using EPIWalletAPI.Models.Vendor;

namespace EPIWalletAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() // initialise
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

       public DbSet<ApplicationUser> ApplicationUsers { get; set; }
       public DbSet<Event> Events { get; set; }

        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        
        public DbSet<Titles> Titles { get; set; }
        
        public DbSet<Employees> Employees { get; set; }

        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<VendorAddress> VendorAddress { get; set; }

        public DbSet<ReasonForRejection> ReasonForRejections { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
       public DbSet<ExpenseRequest> ExpenseRequests { get; set; }
        public DbSet<ApprovalStatus> approvalStatuses{ get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         



 








        }


    }
}
