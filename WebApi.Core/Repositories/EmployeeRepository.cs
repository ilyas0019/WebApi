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
            return new EmployeeModel { ID = 1, Name = "Iliyas", Location = "India" };
        }

        List<EmployeeModel> IEmployeeRepository.GetAllEmployee()
        {
            List<EmployeeModel> listOfEmployee = new List<EmployeeModel>();

            listOfEmployee.Add(new EmployeeModel { ID = 1, Name = "Iliyas", Country="India", Department="Sofware", Location = "Offshore-India", Project="OMG", State="New Delhi", JDate=DateTime.Now.ToString()});
            listOfEmployee.Add(new EmployeeModel { ID = 8, Name = "Bunty", Country = "India", Department = "Sofware", Location = "Offshore-India", Project = "OMG", State = "New Delhi", JDate = DateTime.Now.ToString() }); 
            listOfEmployee.Add(new EmployeeModel { ID = 2, Name = "John", Country = "US", Department = "Sofware", Location = "On Site", Project = "OMG", State = "New Delhi", JDate = DateTime.Now.ToString() });
            listOfEmployee.Add(new EmployeeModel { ID = 3, Name = "Michele", Country = "US", Department = "Sofware", Location = "On Site", Project = "OMG", State = "New Delhi", JDate = DateTime.Now.ToString() });
            listOfEmployee.Add(new EmployeeModel { ID = 4, Name = "Robert", Country = "US", Department = "Sofware", Location = "Offshore-India", Project = "Airtel", State = "New Delhi", JDate = DateTime.Now.ToString() });
            listOfEmployee.Add(new EmployeeModel { ID = 5, Name = "Juan", Country = "India", Department = "Sofware", Location = "Offshore-India", Project = "OMG", State = "New Delhi", JDate = DateTime.Now.ToString() });
            listOfEmployee.Add(new EmployeeModel { ID = 6, Name = "Jeffery", Country = "US", Department = "Sofware", Location = "Offshore-India", Project = "OMG", State = "New Delhi", JDate = DateTime.Now.ToString() });
            listOfEmployee.Add(new EmployeeModel { ID = 7, Name = "Analda", Country = "US", Department = "Sofware", Location = "Offshore-India", Project = "OMG", State = "New Delhi", JDate = DateTime.Now.ToString() });
            listOfEmployee.Add(new EmployeeModel { ID = 9, Name = "Maria", Country = "India", Department = "Sofware", Location = "Offshore-India", Project = "OMG", State = "New Delhi", JDate = DateTime.Now.ToString() });
            listOfEmployee.Add(new EmployeeModel { ID = 10, Name = "Emie", Country = "India", Department = "Sofware", Location = "Offshore-India", Project = "OMG", State = "New Delhi", JDate = DateTime.Now.ToString() });


            return listOfEmployee;
        }

        EmployeeModel IEmployeeRepository.UpdateEmployeeById(EmployeeModel employeeModel)
        {
            return new EmployeeModel { ID = 10, Name = "John", Location = "India" };
        }
    }
}