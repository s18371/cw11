using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class DoctorsDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public DoctorsDbContext()
        {

        }

        public DoctorsDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>((builder) =>
            {
                
                builder.HasKey(e => e.IdDoctor);
                builder.Property(e => e.IdDoctor).ValueGeneratedOnAdd();

                builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();

                builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();

                builder.Property(e => e.Email).HasMaxLength(100).IsRequired();

               


                builder.HasMany(a => a.Prescriptions)
                       .WithOne(a => a.Doctor)
                       .HasForeignKey(a => a.IdDoctor)
                       .IsRequired();

            });


           

            modelBuilder.Entity<Patient>((builder) =>
            {
                builder.HasKey(p => p.IdPatient);
                builder.Property(p=> p.IdPatient).ValueGeneratedOnAdd();
                builder.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();

                builder.HasMany(p => p.Prescriptions)
                       .WithOne(p => p.Patient)
                       .HasForeignKey(p => p.IdPatient)
                       .IsRequired();
            });

            modelBuilder.Entity<Medicament>((builder) =>
            {
                builder.HasKey(m => m.IdMedicament);
                builder.Property(m => m.IdMedicament).ValueGeneratedOnAdd();

                builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
                builder.Property(m => m.Description).HasMaxLength(100).IsRequired();
                builder.Property(m => m.Type).HasMaxLength(100).IsRequired();

                builder.HasMany(m => m.Prescription_Medicaments)
                       .WithOne(m => m.Medicament)
                       .HasForeignKey(m => m.IdMedicament)
                       .IsRequired();

                

            });

            modelBuilder.Entity<Prescription>((builder) =>
            {
                builder.HasKey(p => p.IdPrescription);
                builder.Property(p => p.IdPrescription).ValueGeneratedOnAdd();

                builder.Property(p => p.Date).IsRequired();
                builder.Property(p => p.DueDate).IsRequired();

                builder.HasMany(p => p.Prescription_Medicaments)
                       .WithOne(p => p.Prescription)
                       .HasForeignKey(p => p.IdPrescription)
                       .IsRequired();

            });


            modelBuilder.Entity<Prescription_Medicament>((builder) =>
            {
                builder.HasKey(a => new
                {
                    a.IdMedicament,
                    a.IdPrescription
                });

                builder.Property(p => p.Details).HasMaxLength(100).IsRequired();
                
            });



            var dictDoctors = new List<Doctor>();
            dictDoctors.Add(new Doctor { IdDoctor = 1, FirstName = "Lekarz1", LastName = "1", Email = "email1@gmail.com" });
            dictDoctors.Add(new Doctor { IdDoctor = 2, FirstName = "Lekarz2", LastName = "2", Email = "email2@gmail.com" });
            dictDoctors.Add(new Doctor { IdDoctor = 3, FirstName = "Lekarz3", LastName = "3", Email = "email3@gmail.com" });
            modelBuilder.Entity<Doctor>().HasData(dictDoctors);

            var dictPatients = new List<Patient>();
            dictPatients.Add(new Patient { IdPatient = 1, FirstName = "Pacjent1", LastName = "1", Birthday = DateTime.Now });
            dictPatients.Add(new Patient { IdPatient = 2, FirstName = "Pacjent2", LastName = "2", Birthday = DateTime.Now });
            dictPatients.Add(new Patient { IdPatient = 3, FirstName = "Pacjent3", LastName = "3", Birthday = DateTime.Now });
            modelBuilder.Entity<Patient>().HasData(dictPatients);

            var dictMedicaments = new List<Medicament>();
            dictMedicaments.Add(new Medicament { IdMedicament = 1, Name = "Lek1", Description = "Opis1", Type = "Typ1" });
            dictMedicaments.Add(new Medicament { IdMedicament = 2, Name = "Lek2", Description = "Opis2", Type = "Typ2" });
            dictMedicaments.Add(new Medicament { IdMedicament = 3, Name = "Lek3", Description = "Opis3", Type = "Typ3" });
            modelBuilder.Entity<Medicament>().HasData(dictMedicaments);

            var dictPrescriptions = new List<Prescription>();
            dictPrescriptions.Add(new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now,  IdDoctor = 1, IdPatient = 1 });
            dictPrescriptions.Add(new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now,  IdDoctor = 2, IdPatient = 2 });
            dictPrescriptions.Add(new Prescription { IdPrescription = 3, Date = DateTime.Now, DueDate = DateTime.Now,  IdDoctor = 3, IdPatient = 3 });
            modelBuilder.Entity<Prescription>().HasData(dictPrescriptions);

            var dictPrescription_Medicaments = new List<Prescription_Medicament>();
            dictPrescription_Medicaments.Add(new Prescription_Medicament { Dose = 1, Details = "Detal1", IdMedicament = 1, IdPrescription = 1 });
            dictPrescription_Medicaments.Add(new Prescription_Medicament { Dose = 2, Details = "Detal2",  IdMedicament = 2, IdPrescription = 2 });
            dictPrescription_Medicaments.Add(new Prescription_Medicament { Dose = 3, Details = "Detal3",  IdMedicament = 3, IdPrescription = 3 });
            modelBuilder.Entity<Prescription_Medicament>().HasData(dictPrescription_Medicaments);
        }
    }
}

