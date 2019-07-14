using JobProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobProject.Controllers
{
    public class AdminController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        private object[] Id;
        // GET: Admin

        public ActionResult Index()
        {
            var model = db.Categories.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View("UpdateForm");
        }

        [HttpPost]
        public ActionResult Save(Category category)
        {

            if (category.Id == 0)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                var saveCategory = db.Categories.Find(category.Id);
                if (saveCategory == null)
                {
                    return HttpNotFound();
                }
                saveCategory.Id = category.Id;
                saveCategory.CategoryName = category.CategoryName;
                saveCategory.CategoryIcon = category.CategoryIcon;
            }
            db.SaveChanges();
            return RedirectToAction("Update/" + category.Id, "Admin");
        }

        public ActionResult Update(int Id)
        {
            var updateCategory = db.Categories.Find(Id);
            // var model = db.categories.Where(s => s.categoryId == Id).FirstOrDefault<category>();
            //  var model = db.categories.ToList();
            if (updateCategory == null)
            {
                return HttpNotFound();
            }

            return View("UpdateForm", updateCategory);
            // return Content(updateCategory.categoryId.ToString());
        }


        public ActionResult Delete(int Id)
        {
            var deleteCategory = db.Categories.Find(Id);
            if (deleteCategory == null)
            {
                return HttpNotFound();
            }
            db.Categories.Remove(deleteCategory);
            db.SaveChanges();
            return RedirectToAction("");

        }

        public ActionResult IndexVak()
        {
            var model = db.Vakansiyas.ToList();
            return View(model);
        }


        public ActionResult YeniVak()
        {
            var model = db.Categories.ToList();

            return View(model);
            //   return Content(rows);
        }

        [HttpPost]
        public ActionResult SaveVak(Vakansiya vakansiyalar)
        {

            if (vakansiyalar.Id == 0)
            {
                db.Vakansiyas.Add(vakansiyalar);
                db.SaveChanges();
                return RedirectToAction("IndexVak", "Admin");
            }
            else
            {
                var saveVak = db.Vakansiyas.Find(vakansiyalar.Id);
                if (saveVak == null)
                {
                    return HttpNotFound();
                }
                saveVak.Id = vakansiyalar.Id;
                saveVak.VakAd = vakansiyalar.VakAd;
                saveVak.VakSeher = vakansiyalar.VakSeher;
                saveVak.VakSirket = vakansiyalar.VakSirket;
                saveVak.VakMaas = vakansiyalar.VakMaas;
                saveVak.VakDate = vakansiyalar.VakDate;
                saveVak.VakHaqqinda = vakansiyalar.VakHaqqinda;
                saveVak.CategoryId = vakansiyalar.CategoryId;
            }
            db.SaveChanges();
            return RedirectToAction("UpdateVak/" + vakansiyalar.Id, "Admin");
        }

        public ActionResult UpdateVak(int Id)
        {
            var model = db.Vakansiyas.Find(Id);
            dynamic mymodel = new ExpandoObject();
            mymodel.Categories = GetCategories();
            mymodel.Vakansiyalars = GetVakansiyalars();

            // var model = db.categories.Where(s => s.categoryId == Id).FirstOrDefault<category>();
            //  var model = db.categories.ToList();
            if (mymodel == null)
            {
                return HttpNotFound();
            }

            return View("NewVak", mymodel);
            // return Content(model.vakAd.ToString());
        }
        public List<Category> GetCategories()
        {
            List<Category> categorys = new List<Category>();
            categorys = db.Categories.ToList();
            return categorys;

        }
        public List<Vakansiya> GetVakansiyalars()
        {
            List<Vakansiya> vakansiyalars = new List<Vakansiya>();
            vakansiyalars = db.Vakansiyas.ToList();
            return vakansiyalars;

        }
        public ActionResult DeleteVak(int Id)
        {
            var deleteVak = db.Vakansiyas.Find(Id);
            if (deleteVak == null)
            {
                return HttpNotFound();
            }
            db.Vakansiyas.Remove(deleteVak);
            db.SaveChanges();
            return RedirectToAction("IndexVak");

        }
    }
}