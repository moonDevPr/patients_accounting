using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class DiseasTypes
    {
        public int id { get; set; }

        [Required]
        [MaxLength(3)]
        public string code { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string title { get; set; } = string.Empty;

        [MaxLength(150)]
        public string? inclusion_text { get; set; }

        [MaxLength(150)]
        public string? exclusion_text { get; set; }

        public int id_block { get; set; }
    }
}