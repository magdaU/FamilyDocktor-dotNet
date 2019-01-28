using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FamilyDoctor.Models
{

    [Validator(typeof(Patient))]
    public class Patient
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Imie jest wymagane")]
        [DisplayName("Imie")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Nr telefonu jest wymagany")]
        [DisplayName("Nr telefonu")]
        public int PatientPhoneNumber { get; set; }

        [Required(ErrorMessage = "Data urodzenia jest wymagana")]
        [DisplayName("Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BornDate { get; set; }


        [Required(ErrorMessage = "Email jest wymagany")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail nie jest poprawny")]
        public string Email { get; set; }


        public List<Patient> AllPatient { get; set; }


        public virtual ICollection<BloodPressure> BloodPresures { get; set; }


        public void AddPressure(BloodPressure value)
        {
            this.BloodPresures.Add(value);
        }

        public virtual ICollection<MedicalIndication> MedicalIndication { get; set; }
        public virtual ICollection<PatientDocument> PatientDocument { get; set; }
        public virtual ICollection<DoctorVisit> DoctorVisit { get; set; }
        public virtual ICollection<Vaccination> Vaccination { get; set; }
        public object Medicalindications { get; internal set; }

        public void AddMedicalIndication(MedicalIndication value)
        {
            this.MedicalIndication.Add(value);
        }

        internal static object ToList(int id)
        {
            throw new NotImplementedException();
        }

        public void AddPatientDocument(PatientDocument value)
        {
            this.PatientDocument.Add(value);
        }
        public void AddDoctorVisit(DoctorVisit value)
        {
            this.DoctorVisit.Add(value);
        }
        public void AddVaccination(Vaccination value)
        {
            this.Vaccination.Add(value);
        }

    }
}