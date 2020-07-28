using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DropDownExaple.Models;

namespace DropDownExaple.Data
{
    public partial class AllSampleCodeContext : DbContext
    {
        public AllSampleCodeContext()
        {
        }

        public AllSampleCodeContext(DbContextOptions<AllSampleCodeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CountryMaster> CountryMaster { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryMaster>(entity =>
            {
                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
