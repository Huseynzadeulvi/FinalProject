using JobProject.Models;
using JobProject.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var categories = db.Categories.
                SqlQuery("select Categories.Id,CategoryName,CategoryIcon,count(Vakansiyas.Id) as say " +
                " from Categories inner join Vakansiyas on Vakansiyas.CategoryId=Categories.Id " +
                " group by Categories.Id,Categories.CategoryName,Categories.categoryIcon").
                ToList();

            var elanlar = db.Elans.
                SqlQuery("select * from Elans").
                ToList();

            var vm = new HomeIndexViewModel
            {
                Elan = elanlar,
                Category = categories
            };
            return View(vm);
        }

        public ActionResult Category()
        {
            var model = db.Categories.ToList();
            return View(model);
        }

        public ActionResult NewPostJob()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPostJob(Elan elan)
        {
            db.Elans.Add(elan);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Vacancies(int? id)
        {
            var vakansiya = db.Vakansiyas.FirstOrDefault(v => v.CategoryId == id);

            return View(vakansiya);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string jobTitle, string city)
        {
            var elan = db.Elans.Where(v => v.Title.ToUpper().Contains(jobTitle.ToUpper())
                                           || v.Location.ToUpper().Contains(city.ToUpper())).ToList();

            return View(elan);
        }

        [Authorize]
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var myElans = db.Elans.Where(e => e.UserId == userId).ToList();
            return View(myElans);
        }
    }
}