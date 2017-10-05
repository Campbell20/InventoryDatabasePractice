using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeKeeper.Data;
using TimeKeeper.ViewModels;

namespace TimeKeeper.Controllers
{
    public class InventoryManagementController : Controller
    {

        private EmployeeContext db = new EmployeeContext();

        // GET: InventoryManagement
        public ActionResult Index()
        {
            var InventoryResults = from A in db.InventoryModels
                                   join B in db.Stores
                                   on A.StoreId equals B.Id
                                   select new InventoryManagementViewModel
                                   {
                                       ItemName = A.Name,
                                       ItemDescription = A.Description,
                                       ItemUPC = A.UPCNumber,
                                       ItemStockAmount = A.AmountOnHand,
                                       StoreName = B.Name
                                    
                                   };

            return View(InventoryResults);
        }
    }
}