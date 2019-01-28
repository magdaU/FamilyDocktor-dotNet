using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models.VO
{
    public class DoctorVisitVo
    {
        public int patientId { get; set; }
        public ICollection<DoctorVisit> DoctorVisit { get; set; }
    }
}
