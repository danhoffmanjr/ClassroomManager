using App.Core.Entities;
using System.Collections.Generic;

namespace App.Web.Models
{
    public class LessonsIndexViewModel
    {
        public Lesson Lesson { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}