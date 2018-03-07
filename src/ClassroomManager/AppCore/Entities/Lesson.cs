using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities
{
    public class Lesson : BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Subject { get; set; }
        public string PublishStatus { get; set; }
        public string ImageUrl { get; set; }
        [InverseProperty("Section")]
        public List<LessonSection> Sections { get; set; }
        [InverseProperty("Attachment")]
        public List<FileLink> Attachments { get; set; }
        [InverseProperty("Assignment")]
        public List<Assignment> Assignments { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }

        public long TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
        public long CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
    }
}