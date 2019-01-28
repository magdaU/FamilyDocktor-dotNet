using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models
{
    public class Doctor
    { 
        public int ID { get; set; }

        public int PhoneNumber { get; set; }

        public string Speciality { get; set; }

        public string DoctorAdress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        internal static object ToList(int id)
        {
            throw new NotImplementedException();
        }
    }
}