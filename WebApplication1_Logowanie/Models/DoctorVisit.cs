using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models
{
    public class DoctorVisit
    {
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Doctor { get; set; }

        public string Place { get; set; }

        internal static object ToList(int id)
        {
            throw new NotImplementedException();
        }
    }

}