using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.Models.ViewModel;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Unknow()
        {
            return View();
        }
        public ActionResult PartialAbout()
        {
            ViewBag.Message = "Your application description page.";
            if (Request.IsAjaxRequest())
            {
                return PartialView("About");
            }
            else
            {
                return View("About");
            }
        }
        public ActionResult SomeAction()
        {
            //Response.Write("<script>alert('建立成功!'); location.href='/';</script>");
                       //return "<script>alert('建立成功!'); location.href='/';</script>";
                       //return Content("<script>alert('建立成功!'); location.href='/';</script>");
            return PartialView("SuccessRedirect","/");
        }
        public ActionResult GetFile()
        {
            //return File(Server.MapPath("~/film_20170419074.jpg"),"image/jpg");
            return File(Server.MapPath("~/film_20170419074.jpg"), "image/jpg","NewName.jpg");
        }
        public ActionResult GetJson()
        {
            db.Configuration.LazyLoadingEnabled = false;
            
            var data = db.Product.AsQueryable().Take(5);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}