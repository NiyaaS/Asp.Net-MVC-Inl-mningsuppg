using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModels
{
    public class CategoryIndexViewModel
    {
        
        public CategoryIndexViewModel()
        {
            Categorys = new List<CategoryListViewModel>();
        }
        public class CategoryListViewModel
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
        public List<CategoryListViewModel> Categorys { get; set; }
    }
}