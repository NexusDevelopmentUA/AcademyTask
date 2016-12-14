using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcademyTask.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AcademyTask.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        SQL_repository sql = new SQL_repository();


        public ActionResult Index()
        {
            var CurrentUserId = User.Identity.GetUserId();
            IEnumerable<ApplicationUser> users = context.Users;
            IEnumerable<Friends> friends = context.Friends;

            ViewBag.Relationships = friends;
            ViewBag.CurrentUserId = CurrentUserId;
            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        public string AddFriend(string second_user_id)
        {
            var first_user_id = User.Identity.GetUserId();
            ApplicationUser first_user = context.Users.Find(first_user_id);
            ApplicationUser second_user = context.Users.Find(second_user_id);

            //Friends record = context.Friends.Find(first_user_id, second_user_id);
            try
            {
                sql.SQL_Query("UPDATE Friends SET Relationships '" + "friends" + "' WHERE First_user='" + first_user + "', Second_user='" + second_user + "'");
                context.Friends.Add(new Friends { First_user = second_user, Second_user = first_user, Relationships = "friend" });
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "Added";
        }
        [HttpPost]
        public string RemoveFriend(string second_user_id)
        {
            var first_user_id = User.Identity.GetUserId();
            ApplicationUser first_user = context.Users.Find(first_user_id);
            ApplicationUser second_user = context.Users.Find(second_user_id);
            try
            {
                sql.SQL_Query("DELETE * FROM Friends WHERE First_user='" + first_user + "', Second_user='" + second_user + "'");
                
                if(sql.SQL_Query("UPDATE Friends SET Relationships '" + "subscriber" + "' WHERE First_user='" + first_user + "', Second_user='" + second_user + "'")!="Success")
                {
                    Console.WriteLine("Already removed");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "Removed";
        }
        [HttpPost]
        public string Subscribe(string second_user_id)
        {
            var first_user_id = User.Identity.GetUserId();
            ApplicationUser first_user = context.Users.Find(first_user_id);
            ApplicationUser second_user = context.Users.Find(second_user_id);
            if (first_user_id == null) return "Log In first!";
            else
            {
                context.Friends.Add(new Friends { First_user = first_user, Second_user = second_user, Relationships = "subsriber" });
                context.SaveChanges();
            }
            return "Subscribed";
        }
        [HttpPost]
        public string UnSubscribe(string second_user_id)
        {
            var first_user_id = User.Identity.GetUserId();
            ApplicationUser first_user = context.Users.Find(first_user_id);
            ApplicationUser second_user = context.Users.Find(second_user_id);
            sql.SQL_Query("DELETE * FROM Friends WHERE First_user='" + first_user + "', Second_user='" + second_user + "'");
            return "Unsubsribed";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}