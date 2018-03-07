using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities
{
    public class Student : ContactInfo
    {
        [Required]
        [StringLength(25)]
        public string Role { get; set; } = "Student";

        [Required]
        [StringLength(25)]
        public string GradeLevel { get; set; }

        //Navigation Properties
        //Parent
        public long TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }//In the future prob want a many to many relationship with Teachers and Students
        //Many-to-many with Lesson.cs
        public List<StudentLesson> StudentLessons { get; set; }
    }
}