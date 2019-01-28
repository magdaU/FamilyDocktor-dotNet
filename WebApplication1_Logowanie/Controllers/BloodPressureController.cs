using FamilyDoctor.DAL;
using FamilyDoctor.Models;
using FamilyDoctor.Models.VO;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FamilyDoctor.Controllers
{
    public class BloodPressureController : Controller
    {
        private FamilyDoctorContext db = new FamilyDoctorContext();


        // GET Patients
        public ActionResult Index(int id = 0) 
        {
            Patient patient = db.Patient.Find(id);
            var bloodPressureVo = new BloodPressureVo
            {
                BloodPressure = patient.BloodPresures.ToList(),
                patientId = id
            };
            return View(bloodPressureVo);
        }

        public ActionResult Details( int id = 0, int id2 = 0)
        {
            BloodPressure bloodpressure = db.BloodPressure.Find(id);
            Patient patient = db.Patient.Find(id);
            var bloodPressureEditVo = new BloodPressureEditVo
            {
                ID = bloodpressure.ID,
                PatientId = id2,
                Systolic = bloodpressure.Systolic,
                Diastolic = bloodpressure.Diastolic,
                HeartBeat = bloodpressure.HeartBeat,
                Date = bloodpressure.Date
            };
            if (bloodpressure == null)
            {
                return HttpNotFound();
            }
            return View(bloodPressureEditVo);
        }

        // GET: /Kurs1/Edit/5
        public ActionResult Edit(int id = 0, int id2 = 0)
        {
            BloodPressure bloodpressure = db.BloodPressure.Find(id);
            var bloodPressureEditVo = new BloodPressureEditVo
             {
                ID = bloodpressure.ID,
                PatientId = id2,
                Systolic = bloodpressure.Systolic,
                Diastolic = bloodpressure.Diastolic,
                HeartBeat = bloodpressure.HeartBeat,
                Date = bloodpressure.Date   
             };
            if (bloodpressure == null)
            {
                return HttpNotFound();
            }
            return View(bloodPressureEditVo);
        }

        // POST: /Kurs1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BloodPressureEditVo bloodpressure)
        {
            if (ModelState.IsValid)
            {
                BloodPressure bloodpressureEntity = db.BloodPressure.Find(bloodpressure.ID);
                bloodpressureEntity.Diastolic = bloodpressure.Diastolic;
                bloodpressureEntity.Systolic = bloodpressure.Systolic;
                bloodpressureEntity.HeartBeat = bloodpressure.HeartBeat;
                bloodpressureEntity.Date = bloodpressure.Date;
                
                db.Entry(bloodpressureEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = bloodpressure.PatientId });
            }
            return View(bloodpressure);
        }

        // GET: /Kurs1/Delete/5
        public ActionResult Delete(int id = 0, int id2 = 0)
        {
            BloodPressure bloodpressure = db.BloodPressure.Find(id);
            Patient patient = db.Patient.Find(id2);

            var bloodPressureEditVo = new BloodPressureEditVo
            {
                ID = bloodpressure.ID,
                PatientId = id2,
                Systolic = bloodpressure.Systolic,
                Diastolic = bloodpressure.Diastolic,
                HeartBeat = bloodpressure.HeartBeat,
                Date = bloodpressure.Date
            };

            if (bloodpressure == null)
            {
                return HttpNotFound();
            }
            return View(bloodPressureEditVo);
        }

        //// POST: /Kurs1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id, int id2)
        {
            BloodPressure bloodpressure = db.BloodPressure.Find(id);
            db.BloodPressure.Remove(bloodpressure);
            db.SaveChanges();
           return RedirectToAction("Index", new { id = id2});
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Create(int id  = 0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BloodPressure value)
        {
            int patientId = value.ID;

            Patient patient = db.Patient.Find(value.ID);
            patient.BloodPresures.Add(value);
            db.SaveChanges();

            return RedirectToAction("Index", new { id = patientId });

        }

 
    }

}





   