using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class Patients
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string surname { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string patronymic { get; set; } = string.Empty;

        public int snils { get; set; }

    }
}