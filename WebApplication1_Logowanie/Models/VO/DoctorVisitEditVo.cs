using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models.VO
{
    public class DoctorVisitEditVo
    {
        public int ID { get; set; }
        public int PatientId { get; set; }
        public String Doctor { get; set; }
        public String Place { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        internal static object ToList(int id)
        {
            throw new NotImplementedException();
        }

    }
}