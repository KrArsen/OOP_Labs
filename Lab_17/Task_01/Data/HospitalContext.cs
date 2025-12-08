using System;
using Microsoft.EntityFrameworkCore;
using Task_01.Data.Models;

namespace Task_01.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HospitalDatabase;Integrated Security=True;TrustServerCertificate=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasMany(e => e.Visitations)
                    .WithOne(v => v.Patient)
                    .HasForeignKey(v => v.PatientId);

                entity.HasMany(e => e.Diagnoses)
                    .WithOne(d => d.Patient)
                    .HasForeignKey(d => d.PatientId);

                entity.HasMany(e => e.Prescriptions)
                    .WithOne(pm => pm.Patient)
                    .HasForeignKey(pm => pm.PatientId);
            });

            
            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(e => e.VisitationId);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(true);
            });

            
            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(e => e.DiagnoseId);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(true);
            });

            
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.MedicamentId);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true);
            });

            
            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                entity.HasOne(pm => pm.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(pm => pm.PatientId);

                entity.HasOne(pm => pm.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(pm => pm.MedicamentId);
            });
        }
    }
}
