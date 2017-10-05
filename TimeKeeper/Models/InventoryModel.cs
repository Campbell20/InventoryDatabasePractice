using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TimeKeeper.Models
{
    public class InventoryModel
    {
        //id number tied to each item
        public int Id { get; set; }

        // name of each item 
        public string Name { get; set; }

        //user created description of each item
        public string Description { get; set; }

        //upc code of each item
        public int UPCNumber { get; set; }

        //shipping weight
        public int Weight { get; set; }

        //Amount of item in store
        public int AmountOnHand { get; set; }

        // is item orderable?
        public bool IsActive { get; set; }

        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        public virtual StoreModel Stores { get; set; }


    }
}