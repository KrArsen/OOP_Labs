using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Task_01.Data.Models;

public class Doctor
{
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode(true)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode(true)]
        public string Specialty { get; set; }
        
        public ICollection<Visitation> Visitations { get; set; }

}