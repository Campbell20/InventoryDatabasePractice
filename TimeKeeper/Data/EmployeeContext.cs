using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TimeKeeper.Models;

namespace TimeKeeper.Data
{
    public class EmployeeContext : DbContext
    {



    
            public EmployeeContext() : base("DefaultConnection")
            {

            }

            public DbSet<EmployeeModel> Employees { get; set; }
            public DbSet<TKModel> TKModels { get; set; }

            public DbSet<InventoryModel> InventoryModels { get; set; }
            public DbSet<StoreModel> Stores { get; set; }
    }
}