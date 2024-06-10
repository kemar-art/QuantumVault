﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuantumVault.Persistence.DatabaseContext;

#nullable disable

namespace QuantumVault.Persistence.Migrations
{
    [DbContext(typeof(QuantumVaultDbContext))]
    partial class QuantumVaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuantumVault.Domain.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountNumber"), 10001L);

                    b.Property<decimal>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("QuantumVault.Domain.AccountType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("QuantumVault.Domain.AuditLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LoanApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LoanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LoanPaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PerformedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BranchId");

                    b.HasIndex("CardId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LoanApplicationId");

                    b.HasIndex("LoanId");

                    b.HasIndex("LoanPaymentId");

                    b.HasIndex("TransactionId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("QuantumVault.Domain.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("QuantumVault.Domain.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CardTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("QuantumVault.Domain.CardType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardTypes");
                });

            modelBuilder.Entity("QuantumVault.Domain.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OpeningBalance")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("QuantumVault.Domain.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("QuantumVault.Domain.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InterestRate")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("QuantumVault.Domain.LoanApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LoanTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LoanTypeId");

                    b.ToTable("LoanApplications");
                });

            modelBuilder.Entity("QuantumVault.Domain.LoanPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LoanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PaymentAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("LoanPayments");
                });

            modelBuilder.Entity("QuantumVault.Domain.LoanType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanTypes");
                });

            modelBuilder.Entity("QuantumVault.Domain.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TransactionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("QuantumVault.Domain.TransactionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("QuantumVault.Domain.Account", b =>
                {
                    b.HasOne("QuantumVault.Domain.Branch", "Branch")
                        .WithMany("Accounts")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuantumVault.Domain.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("QuantumVault.Domain.AuditLog", b =>
                {
                    b.HasOne("QuantumVault.Domain.Account", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("AccountId");

                    b.HasOne("QuantumVault.Domain.Branch", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("BranchId");

                    b.HasOne("QuantumVault.Domain.Card", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("CardId");

                    b.HasOne("QuantumVault.Domain.Customer", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("CustomerId");

                    b.HasOne("QuantumVault.Domain.Employee", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("QuantumVault.Domain.LoanApplication", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("LoanApplicationId");

                    b.HasOne("QuantumVault.Domain.Loan", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("LoanId");

                    b.HasOne("QuantumVault.Domain.LoanPayment", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("LoanPaymentId");

                    b.HasOne("QuantumVault.Domain.Transaction", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("QuantumVault.Domain.Card", b =>
                {
                    b.HasOne("QuantumVault.Domain.CardType", "CardType")
                        .WithMany("Cards")
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuantumVault.Domain.Customer", "Customer")
                        .WithMany("Cards")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("QuantumVault.Domain.Employee", b =>
                {
                    b.HasOne("QuantumVault.Domain.Branch", "Branch")
                        .WithMany("Employees")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("QuantumVault.Domain.Loan", b =>
                {
                    b.HasOne("QuantumVault.Domain.Customer", "Customer")
                        .WithMany("Loans")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("QuantumVault.Domain.LoanApplication", b =>
                {
                    b.HasOne("QuantumVault.Domain.Customer", "Customer")
                        .WithMany("LoanApplications")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuantumVault.Domain.LoanType", "LoanType")
                        .WithMany("LoanApplications")
                        .HasForeignKey("LoanTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("LoanType");
                });

            modelBuilder.Entity("QuantumVault.Domain.LoanPayment", b =>
                {
                    b.HasOne("QuantumVault.Domain.Loan", "Loan")
                        .WithMany("Payments")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("QuantumVault.Domain.Transaction", b =>
                {
                    b.HasOne("QuantumVault.Domain.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuantumVault.Domain.TransactionType", "TransactionType")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("QuantumVault.Domain.Account", b =>
                {
                    b.Navigation("AuditLogs");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("QuantumVault.Domain.Branch", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("AuditLogs");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("QuantumVault.Domain.Card", b =>
                {
                    b.Navigation("AuditLogs");
                });

            modelBuilder.Entity("QuantumVault.Domain.CardType", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("QuantumVault.Domain.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("AuditLogs");

                    b.Navigation("Cards");

                    b.Navigation("LoanApplications");

                    b.Navigation("Loans");
                });

            modelBuilder.Entity("QuantumVault.Domain.Employee", b =>
                {
                    b.Navigation("AuditLogs");
                });

            modelBuilder.Entity("QuantumVault.Domain.Loan", b =>
                {
                    b.Navigation("AuditLogs");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("QuantumVault.Domain.LoanApplication", b =>
                {
                    b.Navigation("AuditLogs");
                });

            modelBuilder.Entity("QuantumVault.Domain.LoanPayment", b =>
                {
                    b.Navigation("AuditLogs");
                });

            modelBuilder.Entity("QuantumVault.Domain.LoanType", b =>
                {
                    b.Navigation("LoanApplications");
                });

            modelBuilder.Entity("QuantumVault.Domain.Transaction", b =>
                {
                    b.Navigation("AuditLogs");
                });

            modelBuilder.Entity("QuantumVault.Domain.TransactionType", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
