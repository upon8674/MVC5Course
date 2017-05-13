using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.Models.ViewModel;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();
        private FabricsEntities db = new FabricsEntities();

        // GET: Products
        public ActionResult Index(bool Active = true)
        {
            //var data = db.Product
            //var data = repo.All()
            //    .Where(p => p.Active.HasValue && p.Active.Value == Active)
            //    .OrderByDescending(p => p.ProductId).Take(10);
            
            var data = repo.GetProduct列表頁所有資料(Active, showAll: false);
            ViewData.Model = data;

            ViewData["ppp"] = data;
            ViewBag.qqq = data;

            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.GetOneDataByProductId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();

                //db.Product.Add(product);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.GetOneDataByProductId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                
                repo.Update(product);
                repo.UnitOfWork.Commit();
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.GetOneDataByProductId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.GetOneDataByProductId(id);
            repo.Delete(product);
            repo.UnitOfWork.Commit();



            //Product product = db.Product.Find(id);
            //db.Product.Remove(product);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        //public ActionResult ListProducts( FormCollection form)
        //{
        //    //var data = db.Product
        //    //   .Where(p => p.Active == true)
        //    var data = repo.GetProduct列表頁所有資料(true)
        //        .Select(p => new ProductLiteVM()
        //        {
        //            ProductId = p.ProductId,
        //            ProductName = p.ProductName,
        //            Price = p.Price,
        //            Stock = p.Stock
        //        });
        //        //.Take(10);
        //    return View(data);
        //}


        
        //public ActionResult ListProducts(string q,int stock_b=0,int stock_e= 0)
            public ActionResult ListProducts(SearchKeyWordViewModel VM)
        {
            var data = repo.GetProduct列表頁所有資料(true);

            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(VM.ProductName))
                {
                    data = data.Where(p => p.ProductName.Contains(VM.ProductName));
                }
                //if (!String.IsNullOrEmpty(VM.Stock_b + "")&&!String.IsNullOrEmpty(VM.Stock_e + ""))
                //{
                data = data.Where(p => (p.Stock >= VM.Stock_b && p.Stock <= VM.Stock_e));
                //}

            }
            ViewData.Model = data
                .Select(p => new ProductLiteVM()
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Stock = p.Stock
                });

            return View();
        }
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(
        //    [Bind(Include ="ProductName, ...")] 另一種限制傳入參數的方法
        ProductLiteVM data)
        {
            if (ModelState.IsValid)
            {
                TempData["msg"] = data.ProductName + "商品新增成功";
                return RedirectToAction("ListProducts");

            }
            return View();
        }
    }
}
