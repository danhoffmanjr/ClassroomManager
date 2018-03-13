using App.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassroomManager.Models
{
    public class LessonViewModel
    {
        public Lesson Lesson { get; set; }
        public LessonSection Section { get; set; }
        public long TeacherId { get; set; }
        public long CourseId { get; set; }
        public string UserId { get; set; }
        public List<LessonSection> Sections { get; set; }
        [Display(Name="Upload Image/File")]
        public IFormFile FileToUpload { get; set; }
    }
}