using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models
{
    public class VaccinationDictionary
    {
      
        public int ID { get; set; }

        public string Disease { get; set; }

        public string VaccinationName { get; set; }

        public object vaccinationDictionary { get; internal set; }

        public int vaccinationdictionaryId { get; internal set; }

        internal static object ToList(int id)
        {
            throw new NotImplementedException();
        }
    }

}