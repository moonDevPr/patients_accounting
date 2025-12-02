using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

// таблица Анализов
namespace PatientsAccounting.Models
{
    public class Positions
    {
        public int id { get; set; }

        [Required]
        [MaxLength(75)]
        public string title { get; set; } = string.Empty;

    }
}