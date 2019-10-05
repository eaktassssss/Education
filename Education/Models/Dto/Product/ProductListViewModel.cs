using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Models.Dto.Product
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}