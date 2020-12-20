using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiPractice.Models
{
    public partial class PracticeCovidContext : DbContext
    {
        public PracticeCovidContext()
        {
        }

        public PracticeCovidContext(DbContextOptions<PracticeCovidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GlobalCases> GlobalCases { get; set; }
        public virtual DbSet<NumCasesPerCountry> NumCasesPerCountry { get; set; }
        public virtual DbSet<PercentCases> PercentCases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn_string);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GlobalCases>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfCases).HasColumnName("numberOfCases");
            });

            modelBuilder.Entity<NumCasesPerCountry>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Countries)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PercentCases>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Countries)
                    .HasColumnName("countries")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PercentCases1).HasColumnName("percentCases");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
