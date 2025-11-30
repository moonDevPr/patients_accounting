using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PatientsAccounting.Models
{
    public class PatientCards
    {
        public int id { get; set; }

        [Required]
        public int code { get; set; }

        [Required]
        public int id_hospital { get; set; }

        [Required]
        public int id_patient { get; set; }

    }

}