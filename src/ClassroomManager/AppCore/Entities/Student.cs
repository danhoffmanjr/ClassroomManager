using AppCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities
{
    public class Student : ContactInfo
    {
        public string Role { get; set; } = "Student";
        public string GradeLevel { get; set; }

        // Nav Props
        public long TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }//In the future prob want a many to many relationship with Teachers and Students
        //need to create a many to many relationship with students and lessons
    }
}
