using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModels
{
    public class ProductFromCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string SearchProduct { get; set; }
        public string SearchDescription { get; set; }

        public ProductFromCategoryViewModel()
        {
            ProductList = new List<ProductListViewModel>();
        }
        public class ProductListViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }

            public int Category_Id { get; set; }
        }
    
        public List<ProductListViewModel> ProductList { get; set; }
    }
}