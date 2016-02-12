using WebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Repositories
{
    public interface IEmployeeRepository
    {
        EmployeeModel GetEmployeeById(EmployeeModel employeeModel);
        
        List<EmployeeModel> GetAllEmployee();

        EmployeeModel UpdateEmployeeById(EmployeeModel employeeModel);

    }
}
