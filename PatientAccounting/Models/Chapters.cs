using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class Chapters
    {
        public int id { get; set; }

        [Required]
        [MaxLength(5)]
        public string number { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string code_range { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string title { get; set; } = string.Empty;
    }
}   