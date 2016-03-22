using WebApi.Core.Models;
using WebApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Tests.Mocks
{
    class MockEmployeeRepository : IEmployeeRepository
    {

        public EmployeeModel GetEmployeeById(EmployeeModel employeeModel)
        {
            return new EmployeeModel { ID = 1, Name = "Iliyas" };
        }

        public EmployeeModel UpdateEmployeeById(EmployeeModel employeeModel)
        {
            return employeeModel;
        }


        public List<EmployeeModel> GetAllEmployee()
        {
            var listOfEmp = new List<EmployeeModel>();
            listOfEmp.Add(new EmployeeModel { ID = 1, Name = "Test Robert" });
            listOfEmp.Add(new EmployeeModel { ID = 2, Name = "Test John" });
            listOfEmp.Add(new EmployeeModel { ID = 3, Name = "Test Michelle" });
            listOfEmp.Add(new EmployeeModel { ID = 4, Name = "Test Albert" });
            return listOfEmp;
        }
    }
}
