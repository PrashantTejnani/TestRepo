using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prashant_WebApi_Test.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JoiningDate { get; set; }
        public decimal salary { get; set; }
        public int DepartmentId { get; set; }
    }
}