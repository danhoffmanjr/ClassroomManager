using AppCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities
{
    public class LessonSection : BaseEntity
    {
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string PublishStatus { get; set; }
        public string ImageUrl { get; set; }
        // Nav Props
        public long LessonId { get; set; }
        [JsonIgnore]
        public Lesson Lesson { get; set; }
    }
}
