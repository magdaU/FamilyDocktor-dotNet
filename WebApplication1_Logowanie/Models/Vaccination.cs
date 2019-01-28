using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models
{
    public class Vaccination
    {
        public int ID { get; set; }

        public Boolean AllVaccination { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime NextVaccination { get; set; }

        public string Details { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }

        public string Name { get; set; }


        internal static object ToList(int id)
        {
            throw new NotImplementedException();
        }
    }

}