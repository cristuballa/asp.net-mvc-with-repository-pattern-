using System.Net;
using System.Web.Mvc;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;

namespace WebMVC.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IUnitOfWork unitOfWork = new UnitOfWork();
        // GET: Products
        public ActionResult Index()
        {
            return View(unitOfWork.Products.GetAll());
        }


        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = unitOfWork.Products.GetbyId(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Barcode,StockNo,UnitPrice,Unit,WholesalePrice1,WholesalePrice2,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Products.Add(product);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = unitOfWork.Products.GetbyId(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Barcode,StockNo,UnitPrice,Unit,WholesalePrice1,WholesalePrice2,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Products.Update(product);
                unitOfWork.Complete();
                
                return RedirectToAction("Index");

            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product =unitOfWork.Products.GetbyId(id);
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
            Product product =unitOfWork.Products.GetbyId(id);
            unitOfWork.Products.Remove(product);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
