using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomManager.Models
{
    public enum GradeLevelEnum
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Continuing Education")]
        ContinuingEd = 1,
        [Display(Name = "College")]
        College = 2,
        [Display(Name = "High School Senior")]
        HSSenior = 3,
        [Display(Name = "High School Junior")]
        HSJunior = 4,
        [Display(Name = "High School Sophmore")]
        HSSophmore = 5,
        [Display(Name = "High School Freshman")]
        HSFreshman = 6,
        [Display(Name = "8th Grade")]
        Eighth = 7,
        [Display(Name = "7th Grade")]
        Seventh = 8,
        [Display(Name = "6th Grade")]
        Sixth = 9,
        [Display(Name = "5th Grade")]
        Fifth = 10,
        [Display(Name = "4th Grade")]
        Fourth = 11,
        [Display(Name = "3rd Grade")]
        Third = 12,
        [Display(Name = "2nd Grade")]
        Second = 13,
        [Display(Name = "1st Grade")]
        First = 14,
        [Display(Name = "Kindergarten")]
        Kindergarten = 15,
        [Display(Name = "Pre-school")]
        PreSchool = 16,
    }
}