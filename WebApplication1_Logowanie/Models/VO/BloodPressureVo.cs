using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models.VO
{
    public class BloodPressureVo
    {
        public int patientId { get; set; }
        public ICollection<BloodPressure> BloodPressure { get; set; }
    }
} 