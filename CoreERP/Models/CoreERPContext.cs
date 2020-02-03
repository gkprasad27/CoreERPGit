﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreERP.Models
{
    public partial class CoreERPContext : DbContext
    {
        public CoreERPContext()
        {
        }

        public CoreERPContext(DbContextOptions<CoreERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountingClass> AccountingClass { get; set; }
        public virtual DbSet<ApprovalType> ApprovalType { get; set; }
        public virtual DbSet<AsignmentAcctoAccClass> AsignmentAcctoAccClass { get; set; }
        public virtual DbSet<AsignmentCashAccBranch> AsignmentCashAccBranch { get; set; }
     
        public virtual DbSet<AssetMaster> AssetMaster { get; set; }
        public virtual DbSet<Balances> Balances { get; set; }
        public virtual DbSet<Invoice> Billing { get; set; }
        public virtual DbSet<BillingNoSeries> BillingNoSeries { get; set; }
        public virtual DbSet<BillingReturns> BillingReturns { get; set; }
        public virtual DbSet<BranchTransfer> BranchTransfer { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<BrandModel> BrandModel { get; set; }
        public virtual DbSet<CardType> CardType { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CostCenters> CostCenters { get; set; }
        public virtual DbSet<Counters> Counters { get; set; }
        public virtual DbSet<CustomerReceipts> CustomerReceipts { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Divisions> Divisions { get; set; }
        public virtual DbSet<EmployeeInBranches> EmployeeInBranches { get; set; }
        public virtual DbSet<EmployeeType> EmployeeType { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Finance> Finance { get; set; }
        public virtual DbSet<GlaccGroup> GlaccGroup { get; set; }
        public virtual DbSet<GlaccSubGroup> GlaccSubGroup { get; set; }
        public virtual DbSet<GlaccUnderSubGroup> GlaccUnderSubGroup { get; set; }
        public virtual DbSet<Glaccounts> Glaccounts { get; set; }
        public virtual DbSet<GlsubCode> GlsubCode { get; set; }
        public virtual DbSet<Gst> Gst { get; set; }
        public virtual DbSet<Interpretation> Interpretation { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<ItemMaster> ItemMaster { get; set; }
        public virtual DbSet<LeaveTypes> LeaveTypes { get; set; }
        public virtual DbSet<MatTranTypes> MatTranTypes { get; set; }
        public virtual DbSet<MaterialGroup> MaterialGroup { get; set; }
        public virtual DbSet<MenuAccesses> MenuAccesses { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<NoAssignment> NoAssignment { get; set; }
        public virtual DbSet<NoSeries> NoSeries { get; set; }

        public virtual DbSet<PartnerCreation> PartnerCreation { get; set; }
        public virtual DbSet<PartnerType> PartnerType { get; set; }
        public virtual DbSet<ProfitCenters> ProfitCenters { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseItems> PurchaseItems { get; set; }
        public virtual DbSet<PurchaseRequisitions> PurchaseRequisitions { get; set; }
        public virtual DbSet<PurchaseReturns> PurchaseReturns { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesItems> SalesItems { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }
        public virtual DbSet<TaxIntegration> TaxIntegration { get; set; }
        public virtual DbSet<TaxMasters> TaxMasters { get; set; }
        public virtual DbSet<VendorPayments> VendorPayments { get; set; }
        public virtual DbSet<VoucherClass> VoucherClass { get; set; }
        public virtual DbSet<VoucherProcessing> VoucherProcessing { get; set; }
        public virtual DbSet<VoucherTransaction> VoucherTransaction { get; set; }
        public virtual DbSet<VoucherTypes> VoucherTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
             //   optionsBuilder.UseSqlServer("Server=192.168.2.26;Database=CoreERP;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=192.168.2.26;Database=ERP;User Id=sa; pwd=dotnet@!@#; MultipleActiveResultSets=true;");
                //"Server=192.168.2.26;Database=CoreERP;Trusted_Connection=True;"
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountingClass>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Type).HasMaxLength(10);
            });

            modelBuilder.Entity<ApprovalType>(entity =>
            {
                entity.HasKey(e => e.ApprovalId);

                entity.Property(e => e.ApprovalId)
                    .HasColumnName("ApprovalID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApprovalScreen).HasMaxLength(50);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.RecommendedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<AsignmentAcctoAccClass>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.AccClass).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.InventoryAcc).HasMaxLength(50);

                entity.Property(e => e.PurchaseAcc).HasMaxLength(50);

                entity.Property(e => e.SaleAcc).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);
            });

            modelBuilder.Entity<AsignmentCashAccBranch>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.BankGlacc)
                    .HasColumnName("BankGLAcc")
                    .HasMaxLength(8);

                entity.Property(e => e.BranchCode).HasMaxLength(30);

                entity.Property(e => e.CashGlacc)
                    .HasColumnName("CashGLAcc")
                    .HasMaxLength(8);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);
            });

         
        
            modelBuilder.Entity<AssetMaster>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(14);

                entity.Property(e => e.Address1).HasMaxLength(40);

                entity.Property(e => e.Address2).HasMaxLength(40);

                entity.Property(e => e.Address3).HasMaxLength(40);

                entity.Property(e => e.Address4).HasMaxLength(40);

                entity.Property(e => e.AquationValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AsseetName).HasMaxLength(20);

                entity.Property(e => e.AssetNo).HasMaxLength(20);

                entity.Property(e => e.CompCode).HasMaxLength(4);

                entity.Property(e => e.DepresiationUptoDate).HasMaxLength(30);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Glcode)
                    .HasColumnName("GLCode")
                    .HasMaxLength(30);

                entity.Property(e => e.MeasureofDepresiation).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20);

                entity.Property(e => e.PinCode).HasMaxLength(6);

                entity.Property(e => e.Place).HasMaxLength(30);

                entity.Property(e => e.RateOfDeprecation).HasMaxLength(30);

                entity.Property(e => e.State).HasMaxLength(20);

                entity.Property(e => e.UsefulHike).HasMaxLength(30);

                entity.Property(e => e.UsefulHikemonth)
                    .HasColumnName("usefulHikemonth")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Balances>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.AccountName).HasMaxLength(200);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CrAmount).HasMaxLength(20);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DrAmount).HasMaxLength(20);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionNo).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Address3).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.Baseamount).HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.BillsReceivableAccount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardAccount).HasMaxLength(50);

                entity.Property(e => e.CardAmount).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CashAccount).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CheckAmount).HasMaxLength(50);

                entity.Property(e => e.CheckNo).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.Dbdamount)
                    .HasColumnName("DBDAmount")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext10).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Ext6).HasMaxLength(50);

                entity.Property(e => e.Ext7).HasMaxLength(50);

                entity.Property(e => e.Ext8).HasMaxLength(50);

                entity.Property(e => e.Ext9).HasMaxLength(50);

                entity.Property(e => e.FinanceAccount).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Influaction).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PayTm)
                    .HasColumnName("PayTM")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.PhonePay).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rtgs)
                    .HasColumnName("RTGS")
                    .HasMaxLength(16);

                entity.Property(e => e.Rtgsamount)
                    .HasColumnName("RTGSAmount")
                    .HasMaxLength(50);

                entity.Property(e => e.Rtgsid)
                    .HasColumnName("RTGSID")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BillingNoSeries>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.NumberSeries).HasMaxLength(50);

                entity.Property(e => e.Year).HasMaxLength(15);
            });

            modelBuilder.Entity<BillingReturns>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Address3).HasMaxLength(50);

                entity.Property(e => e.Baseamount).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardAmount).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Influaction).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rtgs)
                    .HasColumnName("RTGS")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BranchTransfer>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Address3).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.Baseamount).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BillsReceivableAccount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardAccount).HasMaxLength(50);

                entity.Property(e => e.CardAmount).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CashAccount).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Ext6).HasMaxLength(50);

                entity.Property(e => e.Ext7).HasMaxLength(50);

                entity.Property(e => e.FinanceAccount).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Influaction).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rtgs)
                    .HasColumnName("RTGS")
                    .HasMaxLength(16);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.HasKey(e => e.BranchCode);

                entity.Property(e => e.BranchCode).HasMaxLength(24);

                entity.Property(e => e.Address1).HasMaxLength(40);

                entity.Property(e => e.Address2).HasMaxLength(40);

                entity.Property(e => e.Address3).HasMaxLength(40);

                entity.Property(e => e.Address4).HasMaxLength(40);

                //entity.Property(e => e.).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BankAccountNumber).HasMaxLength(30);

                entity.Property(e => e.BankBranch).HasMaxLength(30);

                entity.Property(e => e.BankName).HasMaxLength(30);

              //  entity.Property(e => e.Building).HasMaxLength(20);

                entity.Property(e => e.CompanyCode).HasMaxLength(14);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(20);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("IFSCCode")
                    .HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNo).HasMaxLength(20);

                entity.Property(e => e.PinCode).HasMaxLength(6);

                entity.Property(e => e.Place).HasMaxLength(30);

                entity.Property(e => e.State).HasMaxLength(20);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(14);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustomerCare).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);
            });

            modelBuilder.Entity<BrandModel>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.ClosingStock).HasMaxLength(50);

                entity.Property(e => e.CompName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Ext6).HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.InputTaxCode).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.MaterialGroupCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.OutputTaxCode).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.CardName).HasMaxLength(50);

                entity.Property(e => e.CardType1)
                    .HasColumnName("Card_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.CompanyCode);

                entity.Property(e => e.CompanyCode).HasMaxLength(4);

                entity.Property(e => e.Address1).HasMaxLength(40);

                entity.Property(e => e.Address2).HasMaxLength(40);

                entity.Property(e => e.Address3).HasMaxLength(40);

                entity.Property(e => e.Address4).HasMaxLength(40);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NatureOfBusiness).HasMaxLength(50);

                entity.Property(e => e.PanNo).HasMaxLength(20);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20);

                entity.Property(e => e.PinCode).HasMaxLength(6);

                entity.Property(e => e.Place).HasMaxLength(30);

                entity.Property(e => e.State).HasMaxLength(20);

                entity.Property(e => e.TanNo).HasMaxLength(20);
            });

            modelBuilder.Entity<CostCenters>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address4)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CompCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsiblePerson)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Counters>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(200);

                entity.Property(e => e.Ext4).HasMaxLength(200);

                entity.Property(e => e.Prefix).HasMaxLength(20);
            });

            modelBuilder.Entity<CustomerReceipts>(entity =>
            {
                entity.HasKey(e => e.SeqId);

                entity.Property(e => e.SeqId);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.AdjAmount).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CheckNo).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CreditAcc).HasMaxLength(50);

                entity.Property(e => e.DebitAcc).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.ItemReference).HasMaxLength(50);

                entity.Property(e => e.PartyNo).HasMaxLength(50);

                entity.Property(e => e.ReceiptFrom).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasMaxLength(4);

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CompanyDesc).HasMaxLength(50);

                entity.Property(e => e.CompanyGroupCode).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasMaxLength(50);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.ResponsiblePersonCode).HasMaxLength(50);

                entity.Property(e => e.ResponsiblePersonDesc).HasMaxLength(50);
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => e.DesigCode);

                entity.Property(e => e.DesigCode)
                    .HasColumnName("Desig_Code")
                    .HasMaxLength(4);

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CompanyDesc).HasMaxLength(50);

                entity.Property(e => e.CompanyGroupCode).HasMaxLength(50);

                entity.Property(e => e.DesigName)
                    .HasColumnName("Desig_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.DesigShortName)
                    .HasColumnName("Desig_Short_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Formno)
                    .HasColumnName("formno")
                    .HasMaxLength(50);

                entity.Property(e => e.GradeCode)
                    .HasColumnName("Grade_Code")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("time_stamp")
                    .HasMaxLength(50);

                entity.Property(e => e.Trmno)
                    .HasColumnName("trmno")
                    .HasMaxLength(50);

                entity.Property(e => e.Usrid)
                    .HasColumnName("usrid")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Divisions>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(40);
            });

            modelBuilder.Entity<EmployeeInBranches>(entity =>
            {
                entity.HasKey(e => new { e.BranchCode, e.EmpCode });

                entity.Property(e => e.BranchCode).HasMaxLength(4);

                entity.Property(e => e.EmpCode).HasMaxLength(14);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasMaxLength(4);

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CompanyDesc).HasMaxLength(50);

                entity.Property(e => e.CompanyGroupCode).HasMaxLength(50);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(14);

                entity.Property(e => e.Aadhar).HasMaxLength(50);

                entity.Property(e => e.AccessCard).HasMaxLength(20);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.BankAccNo).HasMaxLength(50);

                entity.Property(e => e.BankBranch).HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(100);

                entity.Property(e => e.BolldGroup).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Designation).HasMaxLength(20);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Esinumber)
                    .HasColumnName("ESINumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.FatherName).HasMaxLength(50);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("IFSCCode")
                    .HasMaxLength(20);

                entity.Property(e => e.JoinDate).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Pan).HasMaxLength(50);

                entity.Property(e => e.Pfnumber)
                    .HasColumnName("PFNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.RecommendedBy).HasMaxLength(50);

                entity.Property(e => e.RelDate).HasMaxLength(50);

                entity.Property(e => e.ReportingTo).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Shift).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Uannumber)
                    .HasColumnName("UANNumber")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Finance>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.AssetCategory).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.DbdexcludeGst)
                    .HasColumnName("DBDExcludeGST")
                    .HasMaxLength(50);

                entity.Property(e => e.DbdincGst)
                    .HasColumnName("DBDIncGST")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DownPayment).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Facilitation).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.FinancerName).HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Insurance).HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.LoanAmt).HasMaxLength(50);

                entity.Property(e => e.LoanNo).HasMaxLength(50);

                entity.Property(e => e.MarginAmt).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.NoOfAdvEmi)
                    .HasColumnName("NoOfAdvEMI")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.ProcessFee).HasMaxLength(50);

                entity.Property(e => e.ProductType).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Roi)
                    .HasColumnName("ROI")
                    .HasMaxLength(16);

                entity.Property(e => e.SchemeName).HasMaxLength(50);

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.Tenure).HasMaxLength(50);
            });

            modelBuilder.Entity<GlaccGroup>(entity =>
            {
                entity.HasKey(e => e.GroupCode);

                entity.ToTable("GLAccGroup");

                entity.Property(e => e.GroupCode).HasMaxLength(4);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.GroupName).HasMaxLength(50);

                entity.Property(e => e.NumberRange).HasMaxLength(40);
            });

            modelBuilder.Entity<GlaccSubGroup>(entity =>
            {
                entity.HasKey(e => e.SubGroupCode);

                entity.ToTable("GLAccSubGroup");

                entity.Property(e => e.SubGroupCode).HasMaxLength(4);

                entity.Property(e => e.AccGroup).HasMaxLength(4);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.SubGroupName).HasMaxLength(50);

                entity.Property(e => e.UnderSubGroupCode).HasMaxLength(10);
            });

            modelBuilder.Entity<GlaccUnderSubGroup>(entity =>
            {
                entity.HasKey(e => e.UnderSubGroupCode);

                entity.ToTable("GLAccUnderSubGroup");

                entity.Property(e => e.UnderSubGroupCode).HasMaxLength(4);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.GroupName).HasMaxLength(50);

                entity.Property(e => e.SubGroupName).HasMaxLength(50);

                entity.Property(e => e.UnderSubGroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<Glaccounts>(entity =>
            {
                entity.HasKey(e => e.Glcode);

                entity.ToTable("GLAccounts");

                entity.Property(e => e.Glcode)
                    .HasColumnName("GLCode")
                    .HasMaxLength(8);

                entity.Property(e => e.AccGroup).HasMaxLength(4);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Nactureofaccount).HasMaxLength(40);

                entity.Property(e => e.StatementType).HasMaxLength(4);
            });

            modelBuilder.Entity<GlsubCode>(entity =>
            {
                entity.HasKey(e => e.SubCode);

                entity.ToTable("GLSubCode");

                entity.Property(e => e.SubCode).HasMaxLength(8);

                entity.Property(e => e.Description).HasMaxLength(30);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Glcode)
                    .HasColumnName("GLCode")
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Gst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GST");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompName).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.StateCode).HasMaxLength(50);

                entity.Property(e => e.StateName).HasMaxLength(50);
            });

            modelBuilder.Entity<Interpretation>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.DiscountReceivedAc).HasMaxLength(50);

                entity.Property(e => e.DiscountallowAc).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(20);

                entity.Property(e => e.Ext4).HasMaxLength(20);

                entity.Property(e => e.FrightAc).HasMaxLength(50);

                entity.Property(e => e.InstallationChargesAc).HasMaxLength(50);

                entity.Property(e => e.OtherExpensesAc).HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(14);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Drcrindicator)
                    .HasColumnName("DRCRIndicator")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.OtherExpences).HasMaxLength(50);

                entity.Property(e => e.PurchaseValue).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.ReceivingUnit).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.SaleValue).HasMaxLength(50);

                entity.Property(e => e.SendingUnit).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.SubGlacc)
                    .HasColumnName("SubGLAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.Property(e => e.Uom)
                    .HasColumnName("UOM")
                    .HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<ItemMaster>(entity =>
            {
                entity.HasKey(e => e.ItemNumber);

                entity.Property(e => e.ItemNumber).HasMaxLength(10);

                entity.Property(e => e.AccClass).HasMaxLength(20);

                entity.Property(e => e.Brand).HasMaxLength(100);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(200);

                entity.Property(e => e.Ext2).HasMaxLength(200);

                entity.Property(e => e.Ext3).HasMaxLength(200);

                entity.Property(e => e.Ext4).HasMaxLength(200);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.UnitId).HasMaxLength(50);

                entity.Property(e => e.PackingSize).HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.InputTaxCode).HasMaxLength(50);

                entity.Property(e => e.InventoryAccount).HasMaxLength(50);

                entity.Property(e => e.ItemGroup).HasMaxLength(100);

                entity.Property(e => e.MaxQty)
                    .HasColumnName("MaxQTY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MinQty)
                    .HasColumnName("MinQTY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.Mrpprice).HasColumnName("MRPPrice");

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.OutputTaxCode).HasMaxLength(50);

                entity.Property(e => e.PurchaseAccount).HasMaxLength(50);

                entity.Property(e => e.ReOrdQty).HasColumnName("ReOrdQTY");

                entity.Property(e => e.SalesAccount).HasMaxLength(50);
            });

            modelBuilder.Entity<LeaveTypes>(entity =>
            {
                entity.HasKey(e => e.LeaveCode);

                entity.Property(e => e.LeaveCode).HasMaxLength(40);

                entity.Property(e => e.CompanyCode).HasMaxLength(40);

               

                //entity.Property(e => e.Id)
                //    .HasColumnName("ID")
                //    .HasMaxLength(14);

                entity.Property(e => e.LeaveMaxLimit).HasMaxLength(40);

                entity.Property(e => e.LeaveName).HasMaxLength(40);
            });

            modelBuilder.Entity<MatTranTypes>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Mat_Tran_Types");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DrCrIndicator).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.NoSeries).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<MaterialGroup>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(14);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustomerCare).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.GroupName).HasMaxLength(50);

                entity.Property(e => e.HsnCode).HasMaxLength(20);
            });

            modelBuilder.Entity<MenuAccesses>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.RoleId })
                    .HasName("PK_MenuAccess");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasMaxLength(200);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(200);
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                //entity.Property(e => e.BranchCode).HasMaxLength(50);

                //entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                //entity.Property(e => e.Ext2).HasMaxLength(20);

                //entity.Property(e => e.Ext3).HasMaxLength(200);

                //entity.Property(e => e.Ext4).HasMaxLength(200);

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<NoAssignment>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.CompanyCode).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.MaterialGroup).HasMaxLength(50);

                entity.Property(e => e.NoType).HasMaxLength(30);

                entity.Property(e => e.NumberInterval).HasMaxLength(30);
            });

            modelBuilder.Entity<NoSeries>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.NoType).HasMaxLength(20);

                entity.Property(e => e.NumberSeries).HasMaxLength(50);

                entity.Property(e => e.PartnerType).HasMaxLength(50);
            });

          

            modelBuilder.Entity<PartnerCreation>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(40);

                entity.Property(e => e.Address2).HasMaxLength(40);

                entity.Property(e => e.Address3).HasMaxLength(40);

                entity.Property(e => e.Address4).HasMaxLength(40);

                entity.Property(e => e.Balance).HasMaxLength(50);

                entity.Property(e => e.BalanceType).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(4);

                entity.Property(e => e.CompCode).HasMaxLength(4);

                entity.Property(e => e.ContactPerson).HasMaxLength(20);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.GlcontrolAcc)
                    .HasColumnName("GLControlAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(20);

                entity.Property(e => e.Nacture).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Partnertype).HasMaxLength(50);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.PinCode).HasMaxLength(6);

                entity.Property(e => e.Country).HasMaxLength(30);

                entity.Property(e => e.State).HasMaxLength(20);
            });

            modelBuilder.Entity<PartnerType>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.AccountType).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);
            });

            modelBuilder.Entity<ProfitCenters>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address4)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CompCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsiblePerson)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustGstno)
                    .HasColumnName("CustGSTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryNoteNo).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Freight).HasMaxLength(50);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceAmount).HasMaxLength(20);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ModelCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.OtherExpences).HasMaxLength(20);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PurchaseAccount).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.SalePrice).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.VendorCode).HasMaxLength(50);

                entity.Property(e => e.VendorName).HasMaxLength(50);
            });

            modelBuilder.Entity<PurchaseItems>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Adjusted).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.ChequeNo).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.PaymentAmount).HasMaxLength(50);

                entity.Property(e => e.PaymentReference).HasMaxLength(50);

                entity.Property(e => e.VendorAccount).HasMaxLength(50);

                entity.Property(e => e.VoucherNo).HasMaxLength(50);
            });

            modelBuilder.Entity<PurchaseRequisitions>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_PurchaseRequisition");

                entity.Property(e => e.Code).HasMaxLength(14);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustGstno)
                    .HasColumnName("CustGSTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryNoteNo).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Freight).HasMaxLength(50);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceAmount).HasMaxLength(20);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ModelCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.OtherExpences).HasMaxLength(20);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PurchaseAccount).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.RecommendedBy).HasMaxLength(50);

                entity.Property(e => e.SalePrice).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.VendorCode).HasMaxLength(50);

                entity.Property(e => e.VendorName).HasMaxLength(50);
            });

            modelBuilder.Entity<PurchaseReturns>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryNoteNo).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Freight).HasMaxLength(50);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceAmount).HasMaxLength(20);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ModelCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.OtherExpences).HasMaxLength(20);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PurchaseAccount).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.VendorCode).HasMaxLength(50);

                entity.Property(e => e.VendorName).HasMaxLength(50);
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SalesItems>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(14);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BillsReceivableAccount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardAccount).HasMaxLength(50);

                entity.Property(e => e.CardAmount).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CashAccount).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Ext6).HasMaxLength(50);

                entity.Property(e => e.Ext7).HasMaxLength(50);

                entity.Property(e => e.Ext8).HasMaxLength(50);

                entity.Property(e => e.FinanceAccount).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Influaction).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rtgs)
                    .HasColumnName("RTGS")
                    .HasMaxLength(16);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Segment>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sizes>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);
            });

            modelBuilder.Entity<TaxIntegration>(entity =>
            {
                entity.HasKey(e => e.TaxCode);

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.BranchCode).HasMaxLength(8);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(30);

                entity.Property(e => e.CompanyCode).HasMaxLength(8);

                entity.Property(e => e.Description).HasMaxLength(30);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(30);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(30);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TaxMasters>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.BaseAmountInPerCentage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxType).HasMaxLength(20);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<VendorPayments>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Account).HasMaxLength(20);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.ChequeNo).HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustomerAccount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.PartyNo).HasMaxLength(50);

                entity.Property(e => e.PayementNo).HasMaxLength(20);

                entity.Property(e => e.Reference).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.VoucherNo).HasMaxLength(50);
            });

            modelBuilder.Entity<VoucherClass>(entity =>
            {
                entity.HasKey(e => e.VoucherCode);

                entity.Property(e => e.VoucherCode).HasMaxLength(4);

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.VouchrType).HasMaxLength(50);
            });

            modelBuilder.Entity<VoucherProcessing>(entity =>
            {
                entity.HasKey(e => e.VoucherNo);

                entity.Property(e => e.VoucherNo).HasMaxLength(50);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CheckNo).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.CustAccount).HasMaxLength(50);

                entity.Property(e => e.Division).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.ExtVoucherNo).HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.RefNo).HasMaxLength(50);

                entity.Property(e => e.SubAccount).HasMaxLength(50);

                entity.Property(e => e.Transaction).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.Property(e => e.VoucherType).HasMaxLength(50);
            });

            modelBuilder.Entity<VoucherTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .HasMaxLength(40);

                entity.Property(e => e.AccYear).HasMaxLength(50);

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BanTaxAmt).HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgstacc)
                    .HasColumnName("CGSTAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.CheckNo).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CustAccount).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.ExtVoucherNo).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.GlsubCode)
                    .HasColumnName("GLSubCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Igstacc)
                    .HasColumnName("IGSTAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.OffSettingAcc).HasMaxLength(50);

                entity.Property(e => e.RefNo).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgstacc)
                    .HasColumnName("SGSTAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugstacc)
                    .HasColumnName("UGSTAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.VoucherNo).HasMaxLength(40);

                entity.Property(e => e.VoucherType).HasMaxLength(50);
            });

            modelBuilder.Entity<VoucherTypes>(entity =>
            {
                entity.HasKey(e => e.VoucherCode);

                entity.Property(e => e.VoucherCode).HasMaxLength(4);

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.NoSeries).HasMaxLength(50);

                entity.Property(e => e.Period).HasMaxLength(50);

                entity.Property(e => e.Prefix).HasMaxLength(50);

                entity.Property(e => e.Transaction).HasMaxLength(50);

                entity.Property(e => e.VoucherType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
           return base.SaveChanges();
        }
    }
}
