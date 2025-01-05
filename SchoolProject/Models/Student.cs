using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public string StudentName { get; set; }
        public bool IsActive { get; set; }
        [Range(18,40)]
        public int StudentAge { get; set; }
    }
}
