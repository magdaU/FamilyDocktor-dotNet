using FamilyDoctor.DAL;
using FamilyDoctor.Models;
using FamilyDoctor.Models.VO;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System;

namespace FamilyDoctor.Controllers
{
    public class VaccinationController : Controller
    {
        private FamilyDoctorContext db = new FamilyDoctorContext();

        public ActionResult Index(int id = 0)
        {
            Patient patient = db.Patient.Find(id);
            var vaccinationVo = new VaccinationVo
            {
                Vaccination = patient.Vaccination.ToList(),
                patientId = id
            };
            return View(vaccinationVo);
        }

        public ActionResult Details(int id = 0, int id2 = 0)
        {
            Vaccination vaccination = db.Vaccination.Find(id);
            Patient patient = db.Patient.Find(id);
            var vaccinationEditVo = new VaccinationEditVo
            {
                ID = vaccination.ID,
                PatientId = id2,
                AllVaccination = vaccination.AllVaccination,
                NextVaccination = vaccination.NextVaccination,
                Details = vaccination.Details,
                Date = vaccination.Date,
                Name = vaccination.Name
            };
            if (vaccination == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationEditVo);
        }

        // GET: /Kurs1/Edit/5
        public ActionResult Edit(int id = 0, int id2 = 0)
        {
            Vaccination vaccination = db.Vaccination.Find(id);
            var vaccinationEditVo = new VaccinationEditVo
            {
                ID = vaccination.ID,
                PatientId = id2,
                AllVaccination = vaccination.AllVaccination,
                NextVaccination = vaccination.NextVaccination,
                Details = vaccination.Details,
                Date = vaccination.Date,
                Name = vaccination.Name
            };
            if (vaccination == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationEditVo);
        }

        // POST: /Kurs1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VaccinationEditVo vaccination)
        {
            if (ModelState.IsValid)
            {
                Vaccination vaccinationEntity = db.Vaccination.Find(vaccination.ID);
                vaccinationEntity.AllVaccination = vaccination.AllVaccination;
                vaccinationEntity.NextVaccination = vaccination.NextVaccination;
                vaccinationEntity.Details = vaccination.Details;
                vaccinationEntity.Date = vaccination.Date;
                vaccinationEntity.Name = vaccination.Name;

                db.Entry(vaccinationEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = vaccination.PatientId });
            }
            return View(vaccination);
        }


        // GET: /Kurs1/Delete/5
        public ActionResult Delete(int id = 0, int id2 = 0)
        {
            Vaccination vaccination = db.Vaccination.Find(id);
            Patient patient = db.Patient.Find(id);

            var vaccinationEditVo = new VaccinationEditVo
            {
                ID = vaccination.ID,
                PatientId = id2,
                AllVaccination = vaccination.AllVaccination,
                NextVaccination = vaccination.NextVaccination,
                Details = vaccination.Details,
                Date = vaccination.Date,
                Name = vaccination.Name
            };
            if (vaccination == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationEditVo);
        }

        // POST: /Kurs1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            Vaccination vaccination = db.Vaccination.Find(id);
            db.Vaccination.Remove(vaccination);
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
        public ActionResult Create(Vaccination value)
        {
            int patientId = value.ID;

            Patient patient = db.Patient.Find(value.ID);
            patient.Vaccination.Add(value);

            db.SaveChanges();

            return RedirectToAction("Index", new { id = patientId });
        }
    }
}
   