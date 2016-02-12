using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Core.Models;

namespace WebApi.Core.Entities
{
    public interface IAPIResponse
    {
       List<EmployeeModel> Result { get; set; }
    }
}
