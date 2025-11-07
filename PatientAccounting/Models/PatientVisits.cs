using System;
using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class PatientVisits
    {
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string document { get; set; } = string.Empty;

        [Required]
        public bool completed { get; set; }

        [Required]
        public DateTime adding_date { get; set; }

        [Required]
        public int id_doctor_hospitals { get; set; }

        [Required]
        public int id_visit_type { get; set; }

        [Required]
        public int id_analysis { get; set; }

        [Required]
        public int id_entry_type { get; set; }


        [Required]
        public int id_card { get; set; }
    }
}