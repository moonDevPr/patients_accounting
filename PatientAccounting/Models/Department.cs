using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class Department
    {
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string title { get; set; } = string.Empty;
    }
}
