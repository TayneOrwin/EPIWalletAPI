using EPIWalletAPI.Models.Employee;
using EPIWalletAPI.Models.Guest;
using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EPIWalletAPI.Models.Identity;

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

        public DbSet<Guests> Guest { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         



 








        }


    }
}
