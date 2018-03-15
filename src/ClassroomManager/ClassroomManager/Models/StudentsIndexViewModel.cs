using App.Core.Entities;
using System.Collections.Generic;

namespace App.Web.Models
{
    public class StudentsIndexViewModel
    {
        public Student Student { get; set; }
        public List<Student> Students { get; set; }
        public string UserId { get; set; }
        public string TeacherId { get; set; }
    }
}