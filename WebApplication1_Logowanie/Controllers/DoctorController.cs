using FamilyDoctor.DAL;
using FamilyDoctor.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FamilyDoctor.Controllers
{
    public class DoctorController : Controller
    {

        private FamilyDoctorContext db = new FamilyDoctorContext();

        // GET Patients
        public ActionResult Index()
        {
            return View(db.Doctor.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: /Kurs1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        //
        // POST: /Kurs1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: /Kurs1/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: /Kurs1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctor.Find(id);
            db.Doctor.Remove(doctor);
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
        public ActionResult Create(Doctor value)
        {
            db.Doctor.Add(value);
            db.SaveChanges();
            return View("Index", db.Doctor.ToList());
        }
    }
}
