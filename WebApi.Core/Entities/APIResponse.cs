using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Core.Models;

namespace WebApi.Core.Entities
{
    public class APIResponse : IAPIResponse
    {
       public List<EmployeeModel> Result { get; set; }
    }
}