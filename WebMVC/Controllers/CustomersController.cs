using System.Net;
using System.Web.Mvc;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;

namespace WebMVC.Controllers
{
    public class CustomersController : Controller
    {
      

        private IUnitOfWork unitOfWork = new UnitOfWork();
        // GET: Customers
        public ActionResult Index()
        {
            return View(unitOfWork.Customers.GetAll());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = unitOfWork.Customers.GetbyId(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerName,ContactPerson,EmailAdd,ContactInfo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
               unitOfWork.Customers.Add(customer);
               unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = unitOfWork.Customers.GetbyId(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerName,ContactPerson,EmailAdd,ContactInfo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Customers.Update(customer);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = unitOfWork.Customers.GetbyId(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = unitOfWork.Customers.GetbyId(id);
            unitOfWork.Customers.Remove(customer);
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
