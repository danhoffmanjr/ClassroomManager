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
        Draft = 1,
        [Display(Name = "Pending")]
        Pending = 2,
        [Display(Name = "Publish")]
        Publish = 0,
        [Display(Name = "Private")]
        Private = 3
    }
}