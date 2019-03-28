using System.Net;
using System.Web.Mvc;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;

namespace WebMVC.Controllers
{
    public class EmployeesController : Controller
    {
 
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();
        // GET: Employees
        public ActionResult Index()
        {
            return View(unitOfWork.Employees.GetAll());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitOfWork.Employees.GetbyId(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ContactNo")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Employees.Add(employee);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitOfWork.Employees.GetbyId(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ContactNo")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Employees.Update(employee);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitOfWork.Employees.GetbyId(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = unitOfWork.Employees.GetbyId(id);
            unitOfWork.Employees.Remove(employee);
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
