using WebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Core.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeModel IEmployeeRepository.GetEmployeeById(EmployeeModel employeeModel)
        {
            return new EmployeeModel { ID = 1, Name = "Iliyas", Hobbies = "Chess" };
        }

        List<EmployeeModel> IEmployeeRepository.GetAllEmployee()
        {
            List<EmployeeModel> listOfEmployee = new List<EmployeeModel>();

            listOfEmployee.Add(new EmployeeModel { ID = 1, Name = "Iliyas", Hobbies = "Chess" });
            listOfEmployee.Add(new EmployeeModel { ID = 2, Name = "John", Hobbies = "Baseball" });
            listOfEmployee.Add(new EmployeeModel { ID = 3, Name = "Michele", Hobbies = "Yoga" });
            listOfEmployee.Add(new EmployeeModel { ID = 4, Name = "Robert", Hobbies = "Chess" });
            listOfEmployee.Add(new EmployeeModel { ID = 5, Name = "Juan", Hobbies = "Baseball" });
            listOfEmployee.Add(new EmployeeModel { ID = 6, Name = "Jeffery", Hobbies = "Yoga" });
            listOfEmployee.Add(new EmployeeModel { ID = 7, Name = "Analda", Hobbies = "Chess" });
            listOfEmployee.Add(new EmployeeModel { ID = 8, Name = "Marry", Hobbies = "Baseball" });
            listOfEmployee.Add(new EmployeeModel { ID = 9, Name = "Maria", Hobbies = "Yoga" });
            listOfEmployee.Add(new EmployeeModel { ID = 10, Name = "Emie", Hobbies = "Yoga" });


            return listOfEmployee;
        }

        EmployeeModel IEmployeeRepository.UpdateEmployeeById(EmployeeModel employeeModel)
        {
            return new EmployeeModel { ID = 10, Name = "John", Hobbies = "Baseball" };
        }
    }
}