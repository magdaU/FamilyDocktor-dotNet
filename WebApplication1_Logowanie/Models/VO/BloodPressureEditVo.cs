using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models.VO
{
    public class BloodPressureEditVo
    {

        public int ID { get; set; }
        public int PatientId { get; set; }

        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public int HeartBeat { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        internal static object ToList(int id)
        {
            throw new NotImplementedException();
        }

    }
}