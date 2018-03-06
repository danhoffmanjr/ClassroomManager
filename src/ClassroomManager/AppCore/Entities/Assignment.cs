using AppCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities
{
    public class Assignment : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PublishStatus { get; set; }
        public string ImageUrl { get; set; }
        public FileLink Attachment { get; set; }
        public decimal Grade { get; set; }
        // Nav Props
        public long LessonId { get; set; }
        [JsonIgnore]
        public Lesson Lesson { get; set; }
    }
}