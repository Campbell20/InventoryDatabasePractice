using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TimeKeeper.Models
{
    public class StoreModel
    {
        //id of each store
        public int Id { get; set; }

        //name of each store
        public string Name { get; set; }

        //address of each store
        public string Address { get; set; }

        //is the store still open?
        public bool IsActive { get; set; }

        

    }
}