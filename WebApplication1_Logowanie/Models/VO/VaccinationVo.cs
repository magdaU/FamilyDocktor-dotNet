using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models.VO
{
    public class VaccinationVo
    {
        public int patientId { get; set; }
        public ICollection<Vaccination> Vaccination { get; set; }
    }
}
