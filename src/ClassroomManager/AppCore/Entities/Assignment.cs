using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities
{
    public class Assignment : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(50)]
        public string PublishStatus { get; set; }

        public string ImageUrl { get; set; }

        public FileLink Attachment { get; set; }

        public decimal Grade { get; set; }

        //Navigation Properties
        //Parent
        public long LessonId { get; set; }
        [JsonIgnore]
        public Lesson Lesson { get; set; }
    }
}