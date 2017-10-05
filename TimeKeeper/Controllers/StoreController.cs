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
    public class StoreController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Store
        public ActionResult Index()
        {
            return View(db.Stores.ToList());
        }

        // GET: Store/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = db.Stores.Find(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,IsActive")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(storeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storeModel);
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = db.Stores.Find(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // POST: Store/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,IsActive")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storeModel);
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = db.Stores.Find(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoreModel storeModel = db.Stores.Find(id);
            db.Stores.Remove(storeModel);
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
