using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int id)
        {
            var model = new ViewModels.ProductFromCategoryViewModel();

            using (var db = new Models.ModelDB())
            {
                model.CategoryId = id;
                model.ProductList.AddRange(db.Products.Select(x => new ViewModels.ProductFromCategoryViewModel.ProductListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Category_Id = x.Category_id
                }).Where(x => x.Category_Id == id));


                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            var model = new ViewModels.CreateOrEditProductViewModel();
            using (var db = new Models.ModelDB())
            {
                model.Category_Id = (int)id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ViewModels.CreateOrEditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Models.ModelDB())
            {
                var prod = new Models.Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Category_id = model.Category_Id,
                };

                db.Products.Add(prod);
                db.SaveChanges();
                return RedirectToAction($"Index/{model.Category_Id}");
            }
        }
    }
}