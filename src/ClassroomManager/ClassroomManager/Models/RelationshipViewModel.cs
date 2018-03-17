using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models
{
    public class RelationshipViewModel
    {
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}