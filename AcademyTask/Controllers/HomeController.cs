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

        public ActionResult Index()
        {
            var CurrentUserId = User.Identity.GetUserId();
            IEnumerable<ApplicationUser> users = context.Users;

            ViewBag.CurrentUserId = CurrentUserId;
            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        public PartialViewResult AddFriend(ApplicationUser first_user, ApplicationUser second_user)
        {
            Console.WriteLine("Success!");
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult RemoveFriend(ApplicationUser first_user, ApplicationUser second_user)
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Subscribe(ApplicationUser first_user, ApplicationUser second_user)
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult UnSubscribe(ApplicationUser first_user, ApplicationUser second_user)
        {
            return PartialView();
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