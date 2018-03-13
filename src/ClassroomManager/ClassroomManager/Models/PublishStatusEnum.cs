using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomManager.Models
{
    public enum PublishStatusEnum
    {
        [Display(Name ="Draft")]
        Draft,
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Publish")]
        Publish,
        [Display(Name = "Private")]
        Private
    }
}