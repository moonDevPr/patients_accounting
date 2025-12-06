using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsAcounting.Models
{
    public class DepartmentPosition
    {
        public int id { get; set; }

        [Required]
        public int id_position_doctor { get; set; }

        [Required]
        public int id_hospital_department { get; set; }
    }
}
