﻿using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class FormController : BaseController
    {
        private FabricsEntities db = new FabricsEntities();
        // GET: Form
        public ActionResult Index()
        {
            ViewData.Model = db.Product.Take(10);
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewData.Model = db.Product.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            var product = db.Product.Find(id);
            //if(ModelState.IsValid)
            if (TryUpdateModel(product, includeProperties: new string[] {"ProductName" }))
            {

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            product = db.Product.Find(id);
            return View(product);
        }
    }
}