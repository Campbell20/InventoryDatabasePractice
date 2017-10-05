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
    public class InventoryController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Inventory
        public ActionResult Index()
        {
            var inventoryModels = db.InventoryModels.Include(i => i.Stores);
            return View(inventoryModels.ToList());
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryModel inventoryModel = db.InventoryModels.Find(id);
            if (inventoryModel == null)
            {
                return HttpNotFound();
            }
            return View(inventoryModel);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,UPCNumber,Weight,AmountOnHand,IsActive,StoreId")] InventoryModel inventoryModel)
        {
            if (ModelState.IsValid)
            {
                db.InventoryModels.Add(inventoryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", inventoryModel.StoreId);
            return View(inventoryModel);
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryModel inventoryModel = db.InventoryModels.Find(id);
            if (inventoryModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", inventoryModel.StoreId);
            return View(inventoryModel);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,UPCNumber,Weight,AmountOnHand,IsActive,StoreId")] InventoryModel inventoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", inventoryModel.StoreId);
            return View(inventoryModel);
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryModel inventoryModel = db.InventoryModels.Find(id);
            if (inventoryModel == null)
            {
                return HttpNotFound();
            }
            return View(inventoryModel);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryModel inventoryModel = db.InventoryModels.Find(id);
            db.InventoryModels.Remove(inventoryModel);
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
