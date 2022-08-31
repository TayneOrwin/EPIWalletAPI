using EPIWalletAPI.Models.Employee;

using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EPIWalletAPI.Models.Identity;
using EPIWalletAPI.Models.Vendor;
using EPIWalletAPI.Models;



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

       public DbSet<ApplicationUserModel> ApplicationUserModels { get; set; }

       public DbSet<Event> Events { get; set; }

       public DbSet<ActiveLogin> ActiveLogins { get; set; }

       public DbSet<EventInvite> EventInvites { get; set; } 

        public DbSet<ProjectCode> ProjectCodes { get; set; }

        public DbSet<Company> Companies { get; set; }
    
        public DbSet<Models.Entities.ExpenseType> ExpenseTypes { get; set; }
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
        public DbSet<Entities.AccessRole> accessRoles { get;set; }
        public DbSet<Entities.TopUpRequest> topUpRequests { get; set; }
        public DbSet<ExpenseLine> expenseLines { get; set; }
        public DbSet<PaymentStatus> paymentStatuses { get; set; }
        public DbSet<EmployeeBankingDetails> employeeBankingDetails { get; set; }
        public DbSet<AccountType> accountType { get; set; }
        public DbSet<Entities.Receipt> receipts { get; set; }
        public DbSet<Entities.Quotation> quotation { get; set; }
        public DbSet<Entities.ProofOfPayment>proofOfPayment { get; set; }
        public DbSet<Entities.EventSponsor> eventSponsor { get; set; }
        public DbSet<Entities.GuestInvite> guestInvite { get; set; }
        public DbSet<Entities.EmployeeExpenseLine> employeeExpenseLine { get; set; }
        public DbSet<Entities.ExpenseLineRequest> expenseLineRequest { get; set; }
        public DbSet<Entities.Reconciliation> Reconciliations { get; set; }

        public DbSet<Entities.Reimbursement> Reimbursements { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Entities.VendorType> VendorType { get; set; }
        public DbSet<SponsorType> SponsorType { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         



 








        }


    }
}
