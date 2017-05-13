using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller
    {
        protected FabricsEntities db = new FabricsEntities();
        // GET: Base
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