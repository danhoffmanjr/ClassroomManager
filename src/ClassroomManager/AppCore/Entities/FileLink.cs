using Newtonsoft.Json;

namespace App.Core.Entities
{
    public class FileLink : BaseEntity
    {
        public string FileUrl { get; set; }

        //Navigation Properties
        //Parent
        public long LessonId { get; set; }
        [JsonIgnore]
        public Lesson Lesson { get; set; }
    }
}