using FamilyDoctor.DAL;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using FamilyDoctor.Models;
using FamilyDoctor.Models.VO;

namespace FamilyDoctor.Controllers
{
    public class PatientDocumentController : Controller
    {

        private FamilyDoctorContext db = new FamilyDoctorContext();


        // GET: PatientDocumentController1
        public ActionResult Index(int id = 0)
        {
            Patient patient = db.Patient.Find(id);
            var patientDocumentVo = new PatientDocumentVo
            {
                PatientDocument = patient.PatientDocument.ToList(),
                patientId = id
            };
            return View(patientDocumentVo);
        }

        public ActionResult Details(int id = 0, int id2 = 0)
        {
            PatientDocument patientdocument = db.PatientDocument.Find(id);
            Patient patient = db.Patient.Find(id);
            var patientdocumentEditVo = new PatientDocumentEditVo
            {
                ID = patientdocument.ID,
                PatientId = id2,
                Details = patientdocument.Details,
                Date = patientdocument.Date,
                DocumentName = patientdocument.DocumentName,
                TypeDocument = patientdocument.TypeDocument
            };
            if (patientdocument == null)
            {
                return HttpNotFound();
            }
            return View(patientdocumentEditVo);
        }

        // GET: /Kurs1/Edit/5
        public ActionResult Edit(int id = 0, int id2 = 0)
        {
            PatientDocument patientdocument = db.PatientDocument.Find(id);
            var patientdocumentEditVo = new PatientDocumentEditVo
            {
                ID = patientdocument.ID,
                PatientId = id2,
                Details = patientdocument.Details,
                Date = patientdocument.Date,
                DocumentName = patientdocument.DocumentName,
                TypeDocument = patientdocument.TypeDocument
            };
            if (patientdocument == null)
            {
                return HttpNotFound();
            }
            return View(patientdocumentEditVo);
        }

        // POST: /Kurs1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientDocumentEditVo patientdocument)
        {
            if (ModelState.IsValid)
            {
                PatientDocument patientdocumentEntity = db.PatientDocument.Find(patientdocument.ID);
                patientdocumentEntity.Details = patientdocument.Details;
                patientdocumentEntity.Date = patientdocument.Date;
                patientdocumentEntity.DocumentName = patientdocument.DocumentName;
                patientdocumentEntity.TypeDocument = patientdocument.TypeDocument;

                db.Entry(patientdocumentEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = patientdocument.PatientId });
            }
            return View(patientdocument);
        }


        // GET: /Kurs1/Delete/5
        public ActionResult Delete(int id = 0, int id2 = 0)
        {
            PatientDocument patientdocument = db.PatientDocument.Find(id);
            Patient patient = db.Patient.Find(id2);

            var patientdocumentEditVo = new PatientDocumentEditVo
            {
                ID = patientdocument.ID,
                PatientId = id2,
                Details = patientdocument.Details,
                Date = patientdocument.Date,
                DocumentName = patientdocument.DocumentName,
                TypeDocument = patientdocument.TypeDocument
            };
    
            if (patientdocument == null)
            {
                return HttpNotFound();
            }
            return View(patientdocumentEditVo);
        }

        // POST: /Kurs1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            PatientDocument patientdocument = db.PatientDocument.Find(id);
            db.PatientDocument.Remove(patientdocument);
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
        public ActionResult Create(PatientDocument value)
        {
            int patientId = value.ID;

            Patient patient = db.Patient.Find(value.ID);
            patient.PatientDocument.Add(value);

            db.SaveChanges();

            return RedirectToAction("Index", new { id = patientId });
        }

    }

}
