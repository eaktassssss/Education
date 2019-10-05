using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Education.Filters;
using Education.Models.Context;
using Education.Models.Dto.Product;

namespace Education.Controllers
{
    [CustomAuthenticationFilter]
    public class CacheController : Controller
    {
        private EducationContext context;

        public CacheController()
        {
            context=new EducationContext();
        }


        [OutputCache(Duration = 10,Location = OutputCacheLocation.Client)]
        public ActionResult GetProductsList()
        {
            var products = context.Products.Select(x => new ProductListViewModel()
            {
                 Id = x.Id,ProductName = x.ProductName,CategoryId =x.Category.Id,CategoryName = x.Category.Name
 
            }).ToList();
            return View(products);
        }

        [OutputCache(Duration = 15,VaryByParam = "categoryId")]
        public ViewResult GetProductByCategoryId(int categoryId, string productName)
        {
            var getProducts = context.Products.Where(x => x.CategoryId == categoryId && x.ProductName == productName);
            var products = getProducts.Select(x => new ProductListViewModel()
            {
                Id = x.Id,
                ProductName = x.ProductName,
                CategoryId = x.Category.Id,
                CategoryName = x.Category.Name

            }).ToList();
          return  View("GetProductsList", products);
        }
        
    }
}