using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class Hospitals
    {
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string town { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string street { get; set; } = string.Empty;

        [Required]
        [MaxLength(5)]
        public string house { get; set; } = string.Empty;
    }
}