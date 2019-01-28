using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models.VO
{
    public class PatientDocumentVo
    {
        public int patientId { get; set; }
        public ICollection<PatientDocument> PatientDocument { get; set; }
    }
}