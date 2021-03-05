using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestProject.Models
{
    public partial class test_1Context : DbContext
    {
        public test_1Context()
        {
        }

        public test_1Context(DbContextOptions<test_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentState> PaymentState { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5CQB4CQ\\SQLEXPRESS;Initial Catalog=test_1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CardHolder)
                    .IsRequired()
                    .HasColumnName("card_holder")
                    .HasMaxLength(50);

                entity.Property(e => e.CreditCardNumber)
                    .IsRequired()
                    .HasColumnName("credit_card_number")
                    .HasMaxLength(50);

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expiration_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SecurityCode)
                    .HasColumnName("security_code")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<PaymentState>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.PaymentStatus)
                    .HasColumnName("payment_status")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.PaymentState)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
