using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities
{
    public class Teacher : ContactInfo
    {
        public string Role { get; set; } = "Teacher";
        // Nav Props
        [InverseProperty("Course")]
        public List<Course> Courses { get; set; }
        [InverseProperty("Lesson")]
        public List<Lesson> Lessons { get; set; }
    }
}