using System;
using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class VisitDiagnoses
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string severity { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string comment { get; set; } = string.Empty;

        [Required]
        public bool primary { get; set; }

        [Required]
        [MaxLength(255)]
        public string change_reason { get; set; } = string.Empty;

        [Required]
        public int id_visit { get; set; }

        [Required]
        public int id_diseas { get; set; }
    }
}