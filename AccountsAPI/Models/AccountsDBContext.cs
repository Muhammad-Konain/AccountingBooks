using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class AccountsDBContext : DbContext
    {
        public AccountsDBContext()
        {
        }

        public AccountsDBContext(DbContextOptions<AccountsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountTransaction> AccountTransactions { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<EntryType> EntryTypes { get; set; }
        public virtual DbSet<FinancialYear> FinancialYears { get; set; }
        public virtual DbSet<GeneralJournal> GeneralJournals { get; set; }
        public virtual DbSet<TAccount> TAccounts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<VoucherType> VoucherTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1ONEJCL\\SQLEXPRESS;Database=AccountsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountTransaction>(entity =>
            {
                entity.ToTable("account_transaction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(20, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.Direction)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.Gjentry).HasColumnName("gjentry");

                entity.Property(e => e.TaccountId).HasColumnName("taccount_id");

                entity.HasOne(d => d.GjentryNavigation)
                    .WithMany(p => p.AccountTransactions)
                    .HasForeignKey(d => d.Gjentry)
                    .HasConstraintName("fk_acctrans_genjournal");

                entity.HasOne(d => d.Taccount)
                    .WithMany(p => p.AccountTransactions)
                    .HasForeignKey(d => d.TaccountId)
                    .HasConstraintName("fk_acctrans_taccount");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("account_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<EntryType>(entity =>
            {
                entity.ToTable("entry_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<FinancialYear>(entity =>
            {
                entity.ToTable("financial_year");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<GeneralJournal>(entity =>
            {
                entity.ToTable("General_Journal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Entrytypeid).HasColumnName("entrytypeid");

                entity.Property(e => e.Voucherid).HasColumnName("voucherid");

                entity.HasOne(d => d.Entrytype)
                    .WithMany(p => p.GeneralJournals)
                    .HasForeignKey(d => d.Entrytypeid)
                    .HasConstraintName("fk_generaljournal_entrytype");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.GeneralJournals)
                    .HasForeignKey(d => d.Voucherid)
                    .HasConstraintName("fk_gj_voucher");
            });

            modelBuilder.Entity<TAccount>(entity =>
            {
                entity.ToTable("T_Account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountType).HasColumnName("account_type");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Editby).HasColumnName("editby");

                entity.Property(e => e.IsTerminal)
                    .HasColumnName("is_terminal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentAccount).HasColumnName("parent_account");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.AccountTypeNavigation)
                    .WithMany(p => p.TAccounts)
                    .HasForeignKey(d => d.AccountType)
                    .HasConstraintName("fk_acc_acctype");

                entity.HasOne(d => d.CreatedbyNavigation)
                    .WithMany(p => p.TAccountCreatedbyNavigations)
                    .HasForeignKey(d => d.Createdby)
                    .HasConstraintName("fk_acc_user");

                entity.HasOne(d => d.EditbyNavigation)
                    .WithMany(p => p.TAccountEditbyNavigations)
                    .HasForeignKey(d => d.Editby)
                    .HasConstraintName("fk_taccount_users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Status)
                    .HasColumnName("_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("fk_user_roles");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("voucher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Voucherdate)
                    .HasColumnType("datetime")
                    .HasColumnName("voucherdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Vouchertype).HasColumnName("vouchertype");

                entity.HasOne(d => d.VouchertypeNavigation)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.Vouchertype)
                    .HasConstraintName("fk_voucher_vouchertype");
            });

            modelBuilder.Entity<VoucherType>(entity =>
            {
                entity.ToTable("voucher_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
