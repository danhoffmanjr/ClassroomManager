using App.Core.Interfaces;
using AppCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities
{
    public class Lesson : BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Subject { get; set; }
        public string PublishStatus { get; set; }
        public string ImageUrl { get; set; }
        public List<LessonSection> Sections { get; set; }
        public List<FileLink> Attachments { get; set; }
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