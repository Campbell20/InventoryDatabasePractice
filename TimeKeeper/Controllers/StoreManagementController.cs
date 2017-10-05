using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeKeeper.Data;
using TimeKeeper.ViewModels;

namespace TimeKeeper.Controllers
{
    public class StoreManagementController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: StoreManagement
        public ActionResult Index()
        {

            var Results = from A in db.TKModels
                          join B in db.Employees
                          on A.Employees.Id equals B.Id
                          select new StoreMangementViewModel
                          {
                              Name = A.Employees.EmployeeFirstName,
                              Description = A.Employees.EmployeeLastName,
                              FirstName = B.EmployeeFirstName,
                              LastName = B.EmployeeLastName



                          };
            return View(Results);
        }
    }
}