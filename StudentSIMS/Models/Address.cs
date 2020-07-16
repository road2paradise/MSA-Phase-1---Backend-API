using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSIMS.Models
{


    public class Address
    {
        public int addressID { get; set; }
        public int streetNumber { get; set; }
        public string street { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public int postcode { get; set; }
        public int studentId { get; set; }
        public Student Student { get; set; }

    }
}
