using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult ViewAllProducts(string sort)
        {
            var model = new ViewModels.ProductFromCategoryViewModel();
            using (var db = new Models.ModelDB())
            {
                model.ProductList.AddRange(db.Products.Select(x => new ViewModels.ProductFromCategoryViewModel.ProductListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Category_Id = x.Category_id
                }));

            }
            SortProducts(sort, model);
            return View(model);
        }
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
        [Authorize(Roles ="Admin, Manager")]
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
        [Authorize(Roles = "Admin, Manager")]
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
        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Edit(int id)
        {
            using (var db = new Models.ModelDB())
            {
                var editProduct = db.Products.FirstOrDefault(p => p.Id == id);
                var model = new ViewModels.CreateOrEditProductViewModel
                {
                    Id = editProduct.Id,
                    Name = editProduct.Name,
                    Description = editProduct.Description,
                    Price = editProduct.Price,
                    Category_Id = editProduct.Category_id

                };
                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Edit(ViewModels.CreateOrEditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new Models.ModelDB())
            {
                var editProduct = db.Products.FirstOrDefault(x => x.Id == model.Id);
                editProduct.Name = model.Name;
                editProduct.Price = model.Price;
                editProduct.Description = model.Description;
                editProduct.Category_id = model.Category_Id;
                db.SaveChanges();
            }


            return RedirectToAction($"Index/{model.Category_Id}");
        }

        [HttpGet]
        public ActionResult Search(string search, string sort)
        {
            using (var db = new Models.ModelDB())
            {
                var model = new ViewModels.ProductFromCategoryViewModel
                {
                    Search = search
                };
                model.ProductList.AddRange(db.Products.ToList().Select(r => new ViewModels.ProductFromCategoryViewModel.ProductListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Price = r.Price,
                    Description = r.Description,
                    Category_Id = r.Category_id
                }).Where(c => c.Name.ToLower().Contains(model.Search.ToLower()) || c.Description.ToLower().Contains(model.Search.ToLower()))
                    );
                SortProducts(sort, model);
                return View(model);
            }
        }

        public void SortProducts(string sort, ViewModels.ProductFromCategoryViewModel model)
        {
            model.SortName = String.IsNullOrEmpty(sort) ? "namedes" : "";
            model.SortPrice = sort == "price" ? "pricedes" : "price";
                switch (sort)
                {
                    case "namedes":
                        model.ProductList = model.ProductList.OrderByDescending(s => s.Name).ToList();
                        break;
                    case "price":
                    model.ProductList = model.ProductList.OrderBy(s => s.Price).ToList();
                        break;
                    case "pricedes":
                    model.ProductList = model.ProductList.OrderByDescending(s => s.Price).ToList();
                        break;
                    default:
                    model.ProductList = model.ProductList.OrderBy(s => s.Name).ToList();
                        break;
            }
        }
        public ActionResult ViewDescription(int id)
        {
            using (var db = new Models.ModelDB())
            {
                var editProduct = db.Products.FirstOrDefault(p => p.Id == id);
                var model = new ViewModels.ProductFromCategoryViewModel.ProductListViewModel
                {
                    Id = editProduct.Id,
                    Name = editProduct.Name,
                    Description = editProduct.Description,
                    Price = editProduct.Price,
                    Category_Id = editProduct.Category_id

                };
                return View(model);
            }
        }
    }
}