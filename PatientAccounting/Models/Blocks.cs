using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class Blocks
    {
        public int id { get; set; }

        [Required]
        [MaxLength(7)]
        public string code { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string title { get; set; } = string.Empty;

        public int id_chapter { get; set; }
    }
}