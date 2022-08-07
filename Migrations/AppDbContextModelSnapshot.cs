﻿// <auto-generated />
using System;
using EPIWalletAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EPIWalletAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EPIWalletAPI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("AccessRoleID")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccessRoleID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Employee.EmployeeAddress", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suburb")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("EmployeeAddress");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Employee.Employees", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TitlesID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("TitlesID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.AccessRole", b =>
                {
                    b.Property<int>("AccessRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessRoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccessRoleID");

                    b.ToTable("accessRoles");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.ApprovalStatus", b =>
                {
                    b.Property<int>("ApprovalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApprovalID");

                    b.ToTable("approvalStatuses");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.HasIndex("TypeID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.ExpenseItem", b =>
                {
                    b.Property<int>("ExpenseItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExpenseRequestID")
                        .HasColumnType("int");

                    b.Property<double>("estimateCost")
                        .HasColumnType("float");

                    b.Property<string>("itemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpenseItemID");

                    b.HasIndex("ExpenseRequestID");

                    b.ToTable("ExpenseItems");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.ExpenseType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("ExpenseTypes");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.Guest", b =>
                {
                    b.Property<int>("GuestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuestID");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.ReasonForRejection", b =>
                {
                    b.Property<int>("ReasonForRejectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApprovalID")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusApprovalID")
                        .HasColumnType("int");

                    b.HasKey("ReasonForRejectionID");

                    b.HasIndex("StatusApprovalID");

                    b.ToTable("ReasonForRejections");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.Sponsor", b =>
                {
                    b.Property<int>("SponsorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SponsorID");

                    b.HasIndex("EventID");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.ExpenseRequest", b =>
                {
                    b.Property<int>("ExpenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApprovalID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.Property<int>("VendorID")
                        .HasColumnType("int");

                    b.Property<double>("totalEstimate")
                        .HasColumnType("float");

                    b.HasKey("ExpenseID");

                    b.HasIndex("ApprovalID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TypeID");

                    b.HasIndex("VendorID");

                    b.ToTable("ExpenseRequests");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Titles", b =>
                {
                    b.Property<int>("TitlesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TitlesID");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Vendor.VendorAddress", b =>
                {
                    b.Property<int>("VendorAddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suburb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VendorID")
                        .HasColumnType("int");

                    b.HasKey("VendorAddressID");

                    b.HasIndex("VendorID");

                    b.ToTable("VendorAddress");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Vendor.Vendors", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorID");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.ApplicationUser", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Entities.AccessRole", "AccessRole")
                        .WithMany()
                        .HasForeignKey("AccessRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPIWalletAPI.Models.Employee.Employees", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessRole");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Employee.EmployeeAddress", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Employee.Employees", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Employee.Employees", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Titles", "Titles")
                        .WithMany()
                        .HasForeignKey("TitlesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Titles");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.Event", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Entities.ExpenseType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.ExpenseItem", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.ExpenseRequest", "ExpenseRequest")
                        .WithMany("expenseItems")
                        .HasForeignKey("ExpenseRequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseRequest");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.ReasonForRejection", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Entities.ApprovalStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusApprovalID");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.Sponsor", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.ExpenseRequest", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Entities.ApprovalStatus", "Approval")
                        .WithMany()
                        .HasForeignKey("ApprovalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPIWalletAPI.Models.Employee.Employees", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPIWalletAPI.Models.Entities.ExpenseType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPIWalletAPI.Models.Vendor.Vendors", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approval");

                    b.Navigation("Employee");

                    b.Navigation("Type");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Vendor.VendorAddress", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Vendor.Vendors", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.ExpenseRequest", b =>
                {
                    b.Navigation("expenseItems");
                });
#pragma warning restore 612, 618
        }
    }
}
