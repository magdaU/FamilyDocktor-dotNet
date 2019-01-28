using FamilyDoctor.Models;
using System.Collections;
using System.Collections.Generic;

namespace FamilyDoctor.DAL
{
    public class FamilyDoctorInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FamilyDoctorContext>
    {


        protected override void Seed(FamilyDoctorContext context)
        {
            var lista = new List<BloodPressure>
            {
                 new BloodPressure { Diastolic = 70, Systolic = 120, HeartBeat = 60 }
            };
          
            lista.ForEach(p => context.BloodPressure.Add(p));
            context.SaveChanges();

            var
            medicalindications = new List<MedicalIndication>
            {
                new MedicalIndication
                {
                    MedicalAdvice ="3 dni lezec w łóżku ",
                    Drug="Paracetamol",
                    ImportantInformation="Nie wolno przyjmować innych leków przeciwbólowych",
                    Frequency="3 dni po 1 tabletce",
                    Dosage="Apap"
                }
            };
            medicalindications.ForEach(p => context.MedicalIndication.Add(p));
            context.SaveChanges();

           var
           patientdocuments = new List<PatientDocument>
           {
                new PatientDocument
                {
                    Details="Kopia badania",
                    Date=new System.DateTime(2017, 9, 0),
                    DocumentName="Usg",
                    TypeDocument="Kopia badania"
                }
           };
            patientdocuments.ForEach(p => context.PatientDocument.Add(p));
            context.SaveChanges();

            var
             vaccinations = new List<Vaccination>
           {
                new Vaccination
                {
                    Details="Kopia badania",
                    Date=new System.DateTime (2017, 9, 10),
                    Name="Vaxos",
                    NextVaccination=new System.DateTime (2017, 9, 10),
                    AllVaccination=false
                }
           };
            vaccinations.ForEach(p => context.Vaccination.Add(p));
            context.SaveChanges();

            var
               doctorvisits = new List<DoctorVisit>
           {
                new DoctorVisit
                {
                     Date=new System.DateTime(2017, 9, 10),
                     Doctor="Lubeński",
                     Place="Gdańsk"
                }
           };
            doctorvisits.ForEach(p => context.DoctorVisit.Add(p));
            context.SaveChanges();

            var
            doctors = new List<Doctor>
            {
                new Doctor{
                    FirstName = "Leopold",
                    LastName = "Kowalski",
                    Speciality = "Oncology",
                    PhoneNumber = 6702092,
                    DoctorAdress=" Trzy lipy 3"}
             };
            doctors.ForEach(p => context.Doctor.Add(p));
            context.SaveChanges();


            var
                vaccinationdictionarys = new List<VaccinationDictionary>
            {
                new VaccinationDictionary
                {
                    VaccinationName="Vaxoyl",
                    Disease="Swinka"
                }
             };
            vaccinationdictionarys.ForEach(p => context.VaccinationDictionary.Add(p));
            context.SaveChanges();

            var
                visitplacedictionarys = new List<VisitPlaceDictionary>
            {
                new VisitPlaceDictionary
                {
                    Adress="Chrobrego",
                    NumberAdress="3/1",
                    CodeTown="80-190",
                    Town="Gdańsk",
                    PlaceName="Endomedyst"
                }
             };
            visitplacedictionarys.ForEach(p => context.VisitPlaceDictionary.Add(p));
            context.SaveChanges();


            var
                patients = new List<Patient>
            {
                new Patient{
                    FirstName = "Krzysztof",
                    LastName = "Nowak",
                    Email = "lalala@akakp.pl",
                    PatientPhoneNumber=02929292,
                    BornDate=new System.DateTime(2017, 9, 0),
                    BloodPresures = lista,
                    PatientDocument= patientdocuments,
                    MedicalIndication=medicalindications,
                    Vaccination=vaccinations
                    }
                
            };

            patients.ForEach(p => context.Patient.Add(p));
            context.SaveChanges();

        }
    }
}

    
