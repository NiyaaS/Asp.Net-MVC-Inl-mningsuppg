using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Product
    {
        public Product()
        {
            CategoryList = new List<Category>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Category_id { get; set; }
        //public Category Category { get; set;}
        public List<Category> CategoryList { get; set; }
    }
}