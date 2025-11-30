using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

// таблица Анализов
namespace PatientsAccounting.Models
{
    public class Analysis
    {
        public int id { get; set; }

        [Required]
        [MaxLength(75)]
        public string type { get; set; } = string.Empty;

    }
}