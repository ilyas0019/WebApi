using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Core.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Project { get; set; }
        public string JDate { get; set; }
    }
}