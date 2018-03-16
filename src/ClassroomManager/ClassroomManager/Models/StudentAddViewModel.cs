using App.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace App.Web.Models
{
    public class StudentAddViewModel
    {
        public Student Student { get; set; }
        public IFormFile StudentPic { get; set; }
    }
}