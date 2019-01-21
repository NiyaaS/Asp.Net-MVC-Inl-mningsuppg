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
        public ActionResult Create()
        {
            var model = new ViewModels.CreateOrEditViewModel();
            return View(model);
        }

        [HttpPost]
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

        //[HttpGet]
        //public ActionResult Search(string SearchProduct, string SearchDescription)
        //{
        //    using (var db = new Models.ModelDB())
        //    {
        //        var model = new ViewModels.ProductFromCategoryViewModel
        //        {
        //            SearchProduct = SearchProduct,
        //            SearchDescription = SearchDescription
        //        };
        //        model.ProductList.AddRange(db.Products.ToList().Select(r => new ViewModels.ProductFromCategoryViewModel.ProductListViewModel
        //        {
        //           Id = r.Id,
        //           Name = r.Name,
        //           Price = r.Price,
        //           Description = r.Description,
        //           //CategoryName = r.


        //        }).Where(c => Matches(c, SearchProduct, SearchDescription)
        //            ));

        //        return View("Index", model);
        //    }
        //}

        //bool Matches(ViewModels.ProductFromCategoryViewModel.ProductListViewModel search, string SearchProduct, string SearchDescription)
        //{
        //    if (!string.IsNullOrEmpty(SearchProduct))
        //    {
        //        SearchProduct = SearchProduct.ToLower();
        //        if (!search.Name.ToLower().Contains(SearchProduct)) return false;
        //    }
        //    if (!string.IsNullOrEmpty(SearchDescription))
        //    {
        //        if (!search.ToString().Contains(SearchDescription)) return false;
        //    }
        //    return true;
        //}
        //public ActionResult Search(string q)
        //{
        //    return View();
        //}
        //public ActionResult CreateProduct()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    using (var db = new Models.ModelDB())
        //    {
        //        var newCategory = new Models.Category
        //        {
        //            Name = model.Name
        //        };
        //        db.Categories.Add(newCategory);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}