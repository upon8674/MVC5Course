using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
    public abstract class BaseController : Controller
    {
        protected FabricsEntities db = new FabricsEntities();
        // GET: Base
        [LocalOnly]
        public ActionResult Debug()
        {
            return Content("Hello");
        }

        //當找不到已存在的路徑時 自動改到home 的 index
        //protected override void HandleUnknownAction(string actionName)
        //{
        //    this.RedirectToAction("Index", "Home").ExecuteResult(this.ControllerContext);
        //}
    }
}