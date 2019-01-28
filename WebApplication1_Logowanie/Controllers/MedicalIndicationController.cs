using FamilyDoctor.DAL;
using FamilyDoctor.Models;
using FamilyDoctor.Models.VO;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System;

namespace FamilyDoctor.Controllers
{
    public class MedicalIndicationController : Controller
    {

        private FamilyDoctorContext db = new FamilyDoctorContext();

        // GET: MedicalIndication
        public ActionResult Index(int id = 0)
        {
            Patient patient = db.Patient.Find(id);
            var medicalIndicationVo = new MedicalIndicationVo
            {
                MedicalIndication = patient.MedicalIndication.ToList(),
                patientId = id
            };

            return View(medicalIndicationVo);
        }

        public ActionResult Details(int id = 0, int id2 = 0) 
        {
            MedicalIndication medicalindication = db.MedicalIndication.Find(id);
            Patient patient = db.Patient.Find(id);

            var medicalindicationEditVo = new MedicalIndicationEditVo
            {
                ID = medicalindication.ID,
                PatientId = id2,
                StartDate = medicalindication.StartDate,
                Frequency = medicalindication.Frequency,
                ImportantInformation = medicalindication.ImportantInformation,
                MedicalAdvice = medicalindication.MedicalAdvice,
                Dosage = medicalindication.Dosage,
                Drug = medicalindication.Drug
            };
            if (medicalindication == null)
            {
                return HttpNotFound();
            }
            return View(medicalindicationEditVo);
        }

        // GET: /Kurs1/Edit/5
        public ActionResult Edit(int id = 0, int id2 = 0)
        {
            MedicalIndication medicalindication = db.MedicalIndication.Find(id);
            var medicalindicationEditVo = new MedicalIndicationEditVo
            {
                ID = medicalindication.ID,
                PatientId = id2,
                StartDate = medicalindication.StartDate,
                EndDate = medicalindication.EndDate,
                Frequency = medicalindication.Frequency,
                Drug = medicalindication.Drug,
                MedicalAdvice = medicalindication.MedicalAdvice,
                ImportantInformation = medicalindication.ImportantInformation,
                Dosage = medicalindication.Dosage
            };
            if (medicalindication == null)
            {
                return HttpNotFound();
            }
            return View(medicalindicationEditVo);
        }

        // POST: /Kurs1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicalIndicationEditVo medicalindication)
        {
            if (ModelState.IsValid)
            {
                MedicalIndication medicalindicationEntity = db.MedicalIndication.Find(medicalindication.ID);
                medicalindicationEntity.Dosage = medicalindication.Dosage;
                medicalindicationEntity.MedicalAdvice = medicalindication.MedicalAdvice;
                medicalindicationEntity.Drug = medicalindication.Drug;
                medicalindicationEntity.Frequency = medicalindication.Frequency;
                medicalindicationEntity.ImportantInformation = medicalindication.ImportantInformation;
                medicalindicationEntity.StartDate = medicalindication.StartDate;
                medicalindicationEntity.EndDate = medicalindication.EndDate;

                db.Entry(medicalindicationEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = medicalindication.PatientId });
            }
            return View(medicalindication);
        }

   
        // GET: /Kurs1/Delete/5
        public ActionResult Delete(int id = 0 , int id2 = 0)
        {
            MedicalIndication medicalindication = db.MedicalIndication.Find(id);
            Patient patient = db.Patient.Find(id2);

            var medicalindicationEditVo = new MedicalIndicationEditVo
            {
                ID = medicalindication.ID,
                PatientId = id2,
                StartDate = medicalindication.StartDate,
                EndDate = medicalindication.EndDate,
                Frequency = medicalindication.Frequency,
                Drug = medicalindication.Drug,
                MedicalAdvice = medicalindication.MedicalAdvice,
                ImportantInformation = medicalindication.ImportantInformation,
                Dosage = medicalindication.Dosage
            };
            if (medicalindication == null)
            {
                return HttpNotFound();
            }
            return View(medicalindicationEditVo);
        }

        // POST: /Kurs1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            MedicalIndication medicalindication = db.MedicalIndication.Find(id);
            db.MedicalIndication.Remove(medicalindication);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = id2 });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Create(int id = 0)
        {
            return View();
        }
      

        [HttpPost]
        public ActionResult Create(MedicalIndication value)
        {
            int patientId = value.ID;

            Patient patient = db.Patient.Find(value.ID);
            patient.MedicalIndication.Add(value);
            db.SaveChanges();

            var medicalindicationVo = new MedicalIndicationVo
            {
                MedicalIndication = patient.MedicalIndication.ToList(),
                patientId = value.ID
            };

            return View("Index", medicalindicationVo);
        }
    
    }
}
