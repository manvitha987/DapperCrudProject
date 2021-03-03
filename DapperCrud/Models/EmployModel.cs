using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperCrud.Models
{
    public class EmployModel
    {
        public int EmployID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

    }
}