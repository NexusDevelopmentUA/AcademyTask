using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AcademyTask.Models
{
    public class Friends
    {
        public int ID { get; set; }
        []
        public ApplicationUser First_user { get; set; }
        public ApplicationUser Second_user { get; set; }
        public string Relationships { get; set; }
    }
}