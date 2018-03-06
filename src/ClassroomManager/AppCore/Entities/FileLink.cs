using AppCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities
{
    public class FileLink : BaseEntity
    {
        public string FilePath { get; set; }

        public long LessonId { get; set; }
        [JsonIgnore]
        public Lesson Lesson { get; set; }
    }
}
