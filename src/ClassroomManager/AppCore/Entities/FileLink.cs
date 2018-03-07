using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities
{
    public class FileLink : BaseEntity
    {
        [Required]
        public string FileUrl { get; set; }

        //Navigation Properties
        //Parent
        public long LessonId { get; set; }
        [JsonIgnore]
        public Lesson Lesson { get; set; }
    }
}