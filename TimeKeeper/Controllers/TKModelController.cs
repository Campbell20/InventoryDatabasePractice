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

namespace TimeKeeper.Controllers
{
    public class TKModelController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: TKModel
        public ActionResult Index(int id)
        {
            ViewBag.EmployeeId = id;
            return View(db.TKModels.Where(x => x.Employees.Id == 1).ToList());
        }

        // GET: TKModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKModel tKModel = db.TKModels.Find(id);
            if (tKModel == null)
            {
                return HttpNotFound();
            }
            return View(tKModel);
        }

        // GET: TKModel/Create
        public ActionResult Create(int id)
        {
            TKModel model = new TKModel();
            model.Employees = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: TKModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClockedInOut")] TKModel tKModel)
        {
            if (ModelState.IsValid)
            {
                //Get the employee information
                var employeeResult = db.Employees.Where(x => x.Id == tKModel.Id).FirstOrDefault();
                //Assign the result to the tkModel
                tKModel.Employees = employeeResult;

                db.TKModels.Add(tKModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tKModel);
        }

        // GET: TKModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKModel tKModel = db.TKModels.Find(id);
            if (tKModel == null)
            {
                return HttpNotFound();
            }
            return View(tKModel);
        }

        // POST: TKModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hours")] TKModel tKModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tKModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tKModel);
        }

        // GET: TKModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKModel tKModel = db.TKModels.Find(id);
            if (tKModel == null)
            {
                return HttpNotFound();
            }
            return View(tKModel);
        }

        // POST: TKModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TKModel tKModel = db.TKModels.Find(id);
            db.TKModels.Remove(tKModel);
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
