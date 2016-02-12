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
            return new EmployeeModel { ID = 1, Name = "Iliyas", Hobbies = "Chess and videos games" };
        }

        public EmployeeModel UpdateEmployeeById(EmployeeModel employeeModel)
        {
            return employeeModel;
        }


        public List<EmployeeModel> GetAllEmployee()
        {
            var listOfEmp=new List<EmployeeModel>();
            listOfEmp.Add(new EmployeeModel { ID = 1, Name = "Test Robert", Hobbies = "Chess and videos games" });
            listOfEmp.Add(new EmployeeModel { ID = 2, Name = "Test John", Hobbies = "Chess and videos games" });
            listOfEmp.Add(new EmployeeModel { ID = 3, Name = "Test Michelle", Hobbies = "Chess and videos games" });
            listOfEmp.Add(new EmployeeModel { ID = 4, Name = "Test Albert", Hobbies = "Chess and videos games" });
            return listOfEmp;
        }
    }
}
