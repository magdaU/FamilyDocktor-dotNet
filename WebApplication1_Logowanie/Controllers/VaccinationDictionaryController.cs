using FamilyDoctor.DAL;
using FamilyDoctor.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FamilyDoctor.Controllers
{
    public class VaccinationDictionaryController : Controller
    {
        private FamilyDoctorContext db = new FamilyDoctorContext();

        // GET 
        public ActionResult Index()
        {
            return View(db.VaccinationDictionary.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            VaccinationDictionary vaccinationdictionary = db.VaccinationDictionary.Find(id);
            if (vaccinationdictionary == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationdictionary);
        }

        // GET: /Kurs1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VaccinationDictionary vaccinationdictionary = db.VaccinationDictionary.Find(id);
            if (vaccinationdictionary == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationdictionary);
        }

        //
        // POST: /Kurs1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VaccinationDictionary vaccinationdictionary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccinationdictionary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccinationdictionary);
        }

        // GET: /Kurs1/Delete/5
        public ActionResult Delete(int id = 0)
        {
            VaccinationDictionary vaccinationdictionary = db.VaccinationDictionary.Find(id);
            if (vaccinationdictionary == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationdictionary);
        }

        // POST: /Kurs1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccinationDictionary vaccinationdictionary = db.VaccinationDictionary.Find(id);
            db.VaccinationDictionary.Remove(vaccinationdictionary);
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
        public ActionResult Create(Models.VaccinationDictionary value)
        {
            db.VaccinationDictionary.Add(value);
            db.SaveChanges();
            return View("Index", db.VaccinationDictionary.ToList());
        }
    }
}
