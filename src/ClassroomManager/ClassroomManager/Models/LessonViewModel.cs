using App.Core.Entities;
using System.Collections.Generic;

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
    }
}