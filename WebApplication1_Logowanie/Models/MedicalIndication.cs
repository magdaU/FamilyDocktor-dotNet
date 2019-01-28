using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models
{
    public class MedicalIndication
    {
        public int ID { get; set; }

        public string ImportantInformation { get; set; }

        public string Frequency { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string Drug { get; set; }

        public string MedicalAdvice { get; set; }

        public string Dosage { get; internal set; }

        internal static object ToList(int id)
        {
            throw new NotImplementedException();
        }


    }
}