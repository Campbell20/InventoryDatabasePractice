using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeKeeper.Models
{
    public class TKModel
    {
        public int Id { get; set; }
        

        [DisplayName("Clock In/Out")]
        
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ClockedInOut
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                ClockedInOut = DateTime.Now;
            }
        }
        

        public virtual EmployeeModel Employees { get; set; }


    }
}