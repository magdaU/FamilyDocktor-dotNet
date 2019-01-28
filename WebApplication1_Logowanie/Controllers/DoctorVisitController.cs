using FamilyDoctor.DAL;
using FamilyDoctor.Models;
using FamilyDoctor.Models.VO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyDoctor.Controllers
{
    public class DoctorVisitController : Controller
    {

        private FamilyDoctorContext db = new FamilyDoctorContext();


        // GET Patients
        public ActionResult Index(int id = 0)
        {
            Patient patient = db.Patient.Find(id);
            var doctorVisitVo = new DoctorVisitVo
            {
                DoctorVisit = patient.DoctorVisit.ToList(),
                patientId = id
            };
            return View(doctorVisitVo);
        }


        public ActionResult Details(int id = 0, int id2 = 0)
        {
            DoctorVisit doctorvisit = db.DoctorVisit.Find(id);
            Patient patient = db.Patient.Find(id);
            var doctorvisitEditVo = new DoctorVisitEditVo
            {
                ID = doctorvisit.ID,
                PatientId = id2,
                Date = doctorvisit.Date,
                Doctor = doctorvisit.Doctor,
                Place = doctorvisit.Place

            };
            if (doctorvisit == null)
            {
                return HttpNotFound();
            }
            return View(doctorvisitEditVo);
        }


        // GET: /Kurs1/Edit/5
        public ActionResult Edit(int id = 0, int id2 = 0)
        {
            DoctorVisit doctorvisit = db.DoctorVisit.Find(id);
            var doctorvisitEditVo = new DoctorVisitEditVo
            {
                ID = doctorvisit.ID,
                PatientId = id2,
                Date = doctorvisit.Date,
                Doctor = doctorvisit.Doctor,
                Place = doctorvisit.Place
            };
            if (doctorvisit == null)
            {
                return HttpNotFound();
            }
            return View(doctorvisitEditVo);
        }

        // POST: /Kurs1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoctorVisitEditVo doctorvisit)
        {
            if (ModelState.IsValid)
            {
                DoctorVisit doctorvisitEntity = db.DoctorVisit.Find(doctorvisit.ID);
                doctorvisitEntity.Date = doctorvisit.Date;
                doctorvisitEntity.Doctor = doctorvisit.Doctor;
                doctorvisitEntity.Place = doctorvisit.Place;


                db.Entry(doctorvisitEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = doctorvisit.PatientId });
            }
            return View(doctorvisit);
        }


        // GET: /Kurs1/Delete/5
        public ActionResult Delete(int id = 0, int id2 = 0)
        {
            DoctorVisit doctorvisit = db.DoctorVisit.Find(id);
            Patient patient = db.Patient.Find(id2);

            var doctorvisitEditVo = new DoctorVisitEditVo
            {
                ID = doctorvisit.ID,
                PatientId = id2,
                Date = doctorvisit.Date,
                Doctor = doctorvisit.Doctor,
                Place = doctorvisit.Place
            };

            if (doctorvisit == null)
            {
                return HttpNotFound();
            }
            return View(doctorvisitEditVo);
        }

        // POST: /Kurs1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id = 0, int id2 = 0)
        {
            DoctorVisit doctorvisit = db.DoctorVisit.Find(id);
            db.DoctorVisit.Remove(doctorvisit);
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
        public ActionResult Create(DoctorVisit value)
        {
            int patientId = value.ID;

            Patient patient = db.Patient.Find(value.ID);
            patient.DoctorVisit.Add(value);

            db.SaveChanges();

            return View("Index", new { id = patientId });
        }
    }
}
