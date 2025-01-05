﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public string CourseName { get; set; }
        [Range(5, 25)]
        public int CourseCapacity { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
