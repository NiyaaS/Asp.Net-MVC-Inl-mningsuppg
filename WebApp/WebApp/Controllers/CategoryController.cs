using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var model = new ViewModels.CategoryIndexViewModel();
            using (var db = new Models.ModelDB())
            {
                model.Categorys.AddRange(db.Categories.Select(x => new ViewModels.CategoryIndexViewModel.CategoryListViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }
                ));

            }
            return View(model);
        }
        // GET Products

        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create()
        {
            var model = new ViewModels.CreateOrEditViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create(ViewModels.CreateOrEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Models.ModelDB())
            {
                var newCategory = new Models.Category
                {
                    Id = model.Id,
                    Name = model.Name
                };
                db.Categories.Add(newCategory);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Edit(int id)
        {
            using (var db = new Models.ModelDB())
            {
                var newCategory = db.Categories.FirstOrDefault(p => p.Id == id);
                var model = new ViewModels.CreateOrEditViewModel
                {
                    Name = newCategory.Name
                };
                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Edit(ViewModels.CreateOrEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new Models.ModelDB())
            {
                var editCategory = db.Categories.FirstOrDefault(x => x.Id == model.Id);
                editCategory.Name = model.Name;
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }


    }
}