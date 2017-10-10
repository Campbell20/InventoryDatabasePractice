using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeKeeper.Data;
using TimeKeeper.Models;
using PagedList.Mvc;
using PagedList;

namespace TimeKeeper.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Employee

            //The paramters will allow user to sort via first name or last name, and search with a filter, and display pages
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
       
          
            //This creates a tempary sorting order (which will be default if null)
            ViewBag.CurrentSort = sortOrder;
            
            //This checks to see if searchstring is null or not, and if searchstring IS NULL , then list page one
            if (searchString != null)
            {
                page = 1;
               
            }
            else
            {
                // if it's NOT NULL then assign the current filter to the searchstring paramter
                searchString = currentFilter;
            }

            // filter the values of teh database
            var Results = (IQueryable<EmployeeModel>)db.Employees;


            //assign searchstring to whatever the currentfilter is
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                Results = Results.Where(x => x.EmployeeFirstName.Contains(searchString)
                || x.EmployeeLastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "EmployeeFirstName":
                    Results = Results.OrderByDescending(x => x.EmployeeFirstName);
                    break;
                case "EmployeeLastName":
                    Results = Results.OrderByDescending(x => x.EmployeeLastName);
                    break;
                default:
                    Results = Results.OrderByDescending(x => x.Id);
                    break;
                
            }


            int pageSize = 6;
            int pageNumber = (page ?? 1);

            //return the results of the search
            return View(Results.ToPagedList(pageNumber, pageSize));

            //return View(db.Employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.Employees.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeFirstName,EmployeeLastName,BirthDate,IsActive")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employeeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeModel);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.Employees.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeFirstName,EmployeeLastName,IsActive")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.Employees.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeModel employeeModel = db.Employees.Find(id);
            db.Employees.Remove(employeeModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
