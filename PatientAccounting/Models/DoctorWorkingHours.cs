using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsAcounting.Models
{
    internal class DoctorWorkingHours
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
        public int? id_department_position { get; set; }
    }
}
