using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDoctor.Models
{
    public class VisitPlaceDictionary
    {
        public int ID { get; set; }

        public int PhoneNumber { get; set; }

        public string Town { get; set; }

        public string Adress { get; set; }

        public string NumberAdress { get; set; }

        public string CodeTown { get; set; }

        public string PlaceName { get; set; }
     

        internal static object ToList(int id)
        {
            throw new NotImplementedException();
        }
    }

}