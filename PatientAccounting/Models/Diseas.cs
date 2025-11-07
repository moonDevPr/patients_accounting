using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class Diseas
    {
        public int id { get; set; }

        [Required]
        [MaxLength(10)]
        public string code { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? description { get; set; }

        public bool active { get; set; }
        public int priority { get; set; }
        public bool primary { get; set; }

        public int id_diseas_type { get; set; }
    }
}