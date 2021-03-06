﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities
{
    public class Course : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(25)]
        public string Status { get; set; } = "0";

        //Navigation Properties
        //Parent
        public long TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
        //Child
        public List<Lesson> Lessons { get; set; }
    }
}