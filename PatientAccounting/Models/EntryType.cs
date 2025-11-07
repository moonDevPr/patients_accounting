using System.ComponentModel.DataAnnotations;

namespace PatientsAccounting.Models
{
    public class EntryType
    {
        public int id { get; set; }

        [Required]
        [MaxLength(75)]
        public string title { get; set; } = string.Empty;
    }
}