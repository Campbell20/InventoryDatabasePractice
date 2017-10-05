using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeKeeper.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string EmployeeFirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("[A-z]{3,50}", ErrorMessage = "Use letters only please.")]
        public string EmployeeLastName { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        
        

        public bool IsActive { get; set; }


    }
}