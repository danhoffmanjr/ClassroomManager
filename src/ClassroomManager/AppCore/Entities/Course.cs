using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCore.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        // Nav Props
        public long TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
        //public ICollection<Lesson> Lessons { get; set; }
        //public ICollection<Teacher> Teachers { get; set; }
        //public ICollection<Student> Students { get; set; }
    }
}
