using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models.VO
{
    public class MedicalIndicationVo
    {
        public int patientId { get; set; }
        public ICollection<MedicalIndication> MedicalIndication { get; set; }
    }
}