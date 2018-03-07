using Newtonsoft.Json;

namespace App.Core.Entities
{
    public class LessonSection : BaseEntity
    {
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string PublishStatus { get; set; }
        public string ImageUrl { get; set; }

        //Navigation Properties
        //Parent
        public long LessonId { get; set; }
        [JsonIgnore]
        public Lesson Lesson { get; set; }
    }
}