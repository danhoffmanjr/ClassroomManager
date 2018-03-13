using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities
{
    public class LessonSection : BaseEntity
    {
        [Required]
        [StringLength(150)]
        [Display(Name ="Section Header")]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Section Publish Status")]
        public string PublishStatus { get; set; }

        public string ImageUrl { get; set; }

        //Navigation Properties
        //Parent
        public long LessonId { get; set; }
        [JsonIgnore]
        public Lesson Lesson { get; set; }
    }
}