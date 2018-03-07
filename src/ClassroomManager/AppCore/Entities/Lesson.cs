using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities
{
    public class Lesson : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [Required]
        [StringLength(50)]
        public string PublishStatus { get; set; }

        public string ImageUrl { get; set; }

        //Navigation Properties
        //Parent 1
        public long TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
        //Parent 2
        public long CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        //Child 1
        public List<LessonSection> Sections { get; set; }
        //Child 2
        public List<FileLink> Attachments { get; set; }
        //Child 3
        public List<Assignment> Assignments { get; set; }
        //Many-to-many with Student.cs
        public List<StudentLesson> StudentLessons { get; set; }
    }
}