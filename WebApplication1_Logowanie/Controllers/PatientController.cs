using FamilyDoctor.DAL;
using FamilyDoctor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using static FamilyDoctor.Models.Patient;

namespace FamilyDoctor.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {

        private FamilyDoctorContext db = new FamilyDoctorContext();

        // GET Patients
        public ActionResult Index()
        {
            return View(db.Patient.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Patient patient = db.Patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: /Kurs1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Patient patient = db.Patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /Kurs1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: /Kurs1/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Patient patient = db.Patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: /Kurs1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patient.Find(id);
            db.Patient.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient value)
        {

            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            db.Patient.Add(value);
            db.SaveChanges();
            TempData["notice"] = "Patient successfully created";
            return View("Index", db.Patient.ToList());
        }

 
    }
}
    


