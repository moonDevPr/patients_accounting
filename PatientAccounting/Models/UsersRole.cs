using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class UsersRole
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string role_name { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string description { get; set; } = string.Empty;
    }
}
