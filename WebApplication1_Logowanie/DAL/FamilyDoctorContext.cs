using FamilyDoctor.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Collections;

namespace FamilyDoctor.DAL
{
    public class FamilyDoctorContext : DbContext
    {
        public FamilyDoctorContext() : base("FamilyDoctorContext")
        {

        }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<BloodPressure> BloodPressure { get;  set; }
        public DbSet<MedicalIndication> MedicalIndication { get; set; }
        public DbSet<DoctorVisit> DoctorVisit { get; set; }
        public DbSet<PatientDocument> PatientDocument { get; set; }
        public DbSet<Vaccination> Vaccination { get; set; }
        public DbSet<VaccinationDictionary> VaccinationDictionary { get; set; }
        public DbSet<VisitPlaceDictionary> VisitPlaceDictionary { get; set; }
 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}