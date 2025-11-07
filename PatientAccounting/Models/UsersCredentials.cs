using System;
using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class UsersCredentials
    {
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string username { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string password_hash { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string salt { get; set; } = string.Empty;

        [Required]
        public bool active { get; set; }

        [Required]
        public DateTime created_date { get; set; }

        public DateTime? last_login { get; set; }

        [Required]
        public int id_users_role { get; set; }

        public int? id_patient { get; set; }

        public int? id_doctor { get; set; }
    }
}