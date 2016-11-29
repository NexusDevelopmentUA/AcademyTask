using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyTask.Models
{
    public class Friends
    {
        public int Id { get; set; }
        public ApplicationUser First_user { get; set; }
        public ApplicationUser Second_user { get; set; }
        public string Relationships { get; set; }
    }
}