using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Models.ViewModel
{
    /// <summary>
    /// 這是一個精簡的產品ViewModel
    /// </summary>
    public class ProductLiteVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Stock { get; set; }

    }
   
}