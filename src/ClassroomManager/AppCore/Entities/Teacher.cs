using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCore.Entities
{
    public class Teacher : ContactInfo
    {
        public string Role { get; set; } = "Teacher";
        // Nav Props
        public List<Course> Courses { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Student> Students { get; set; }
    }
}