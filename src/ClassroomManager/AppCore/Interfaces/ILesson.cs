using AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Interfaces
{
    public interface ILesson
    {
        string Title { get; set; }
        string Summary { get; set; }
        string Subject { get; set; }
        string PublishStatus { get; set; }
        List<LessonSection> Sections { get; set; }
        List<FileLink> Attachments { get; set; }
        List<Assignment> Assignments { get; set; }
        List<Student> Students { get; set; }

        long TeacherId { get; set; }
        Teacher Teacher { get; set; }
    }
}
