﻿// <auto-generated />
using System;
using EPIWalletAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EPIWalletAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220710125331_add_address_basic_Crud_and_employee_Crud")]
    partial class add_address_basic_Crud_and_employee_Crud
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int?>("EmployeeID")
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

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventID = 1,
                            TypeID = 1,
                            date = new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            description = "Organized work social by the team",
                            name = "Work Social"
                        },
                        new
                        {
                            EventID = 2,
                            TypeID = 1,
                            date = new DateTime(2009, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            description = "Organized Breakfast",
                            name = "Morning Social"
                        });
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.ExpenseType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.HasIndex("EventID");

                    b.ToTable("ExpenseTypes");

                    b.HasData(
                        new
                        {
                            TypeID = 1,
                            EventID = 1,
                            Type = "Social"
                        });
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

                    b.ToTable("Sponsors");

                    b.HasData(
                        new
                        {
                            SponsorID = 1,
                            Amount = 399.22000000000003,
                            Company = "Striker Investments",
                            Email = "strikerproducts@gmail.com",
                            EventID = 17,
                            Surname = "Heuston",
                            name = "Bryan"
                        });
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

            modelBuilder.Entity("EPIWalletAPI.Models.Vendor", b =>
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

                    b.Property<int>("VendorAddressID")
                        .HasColumnType("int");

                    b.HasKey("VendorID");

                    b.ToTable("Vendors");

                    b.HasData(
                        new
                        {
                            VendorID = 1,
                            Availability = true,
                            Description = "Main Bakery on 4th Street",
                            Name = "Bryan",
                            VendorAddressID = 1
                        });
                });

            modelBuilder.Entity("EPIWalletAPI.Models.VendorAddress", b =>
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

                    b.Property<int?>("VendorID1")
                        .HasColumnType("int");

                    b.HasKey("VendorAddressID");

                    b.HasIndex("VendorID1");

                    b.ToTable("VendorAddresses");

                    b.HasData(
                        new
                        {
                            VendorAddressID = 1,
                            AddressLine1 = "578 Saint Street",
                            AddressLine2 = "No 57",
                            Country = "South Africa",
                            Province = "Gauteng",
                            Suburb = "Menlo Park",
                            VendorID = 1
                        });
                });

            modelBuilder.Entity("EPIWalletAPI.Models.Employee.EmployeeAddress", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Employee.Employees", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

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

            modelBuilder.Entity("EPIWalletAPI.Models.Entities.ExpenseType", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("EPIWalletAPI.Models.VendorAddress", b =>
                {
                    b.HasOne("EPIWalletAPI.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorID1");

                    b.Navigation("Vendor");
                });
#pragma warning restore 612, 618
        }
    }
}
