using System;
using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class DoctorSchedle
    {
        public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string day_of_week { get; set; } = string.Empty;

        [Required]
        public int duration_appointment { get; set; }

        [Required]
        public DateTime start_time { get; set; }

        public DateTime? end_time { get; set; }

        [Required]
        public int? id_hospital { get; set; }

        [Required]
        public int? id_doctor { get; set; }
    }
}
