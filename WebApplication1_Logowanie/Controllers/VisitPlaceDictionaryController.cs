using FamilyDoctor.DAL;
using FamilyDoctor.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FamilyDoctor.Controllers
{
    public class VisitPlaceDictionaryController : Controller
    {
        private FamilyDoctorContext db = new FamilyDoctorContext();

        // GET 
        public ActionResult Index()
        {
            return View(db.VisitPlaceDictionary.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            VisitPlaceDictionary visitplacedictionary = db.VisitPlaceDictionary.Find(id);
            if (visitplacedictionary == null)
            {
                return HttpNotFound();
            }
            return View(visitplacedictionary);
        }

        // GET: /Kurs1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VisitPlaceDictionary visitplacedictionary = db.VisitPlaceDictionary.Find(id);
            if (visitplacedictionary == null)
            {
                return HttpNotFound();
            }
            return View(visitplacedictionary);
        }

        //
        // POST: /Kurs1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VisitPlaceDictionary visitplacedictionary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitplacedictionary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitplacedictionary);
        }

        // GET: /Kurs1/Delete/5
        public ActionResult Delete(int id = 0)
        {
            VisitPlaceDictionary visitplacedictionary = db.VisitPlaceDictionary.Find(id);
            if (visitplacedictionary == null)
            {
                return HttpNotFound();
            }
            return View(visitplacedictionary);
        }

        // POST: /Kurs1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitPlaceDictionary visitplacedictionary = db.VisitPlaceDictionary.Find(id);
            db.VisitPlaceDictionary.Remove(visitplacedictionary);
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
        public ActionResult Create(Models.VisitPlaceDictionary value)
        {
            db.VisitPlaceDictionary.Add(value);
            db.SaveChanges();
            return View("Index", db.VisitPlaceDictionary.ToList());
        }
    }
}