using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities
{
    public class Teacher : ContactInfo
    {
        [Required]
        [StringLength(25)]
        public string Role { get; set; } = "Teacher";

        //Navigation Properties
        //Child 1
        public List<Course> Courses { get; set; }
        //Child 2
        public List<Lesson> Lessons { get; set; }
    }
}