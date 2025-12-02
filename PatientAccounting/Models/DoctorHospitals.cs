using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PatientsAccounting.Models
{
    public class DoctorsHospitals
    {
        public int id { get; set; }

        [Required]
        public int id_doctor { get; set; }

        [Required]
        public int id_hospital { get; set; }

        [Required]
        public bool active { get; set; }
    }

}