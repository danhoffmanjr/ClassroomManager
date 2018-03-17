using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models
{
    public class RelationshipViewModel
    {
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public bool AssignId {get; set;}
        public List<StudentLesson> StudentLessons { get; set; }
        public List<long> AssignedLessons { get; set; }
        public List<long> Selected { get; set; }
    }
}