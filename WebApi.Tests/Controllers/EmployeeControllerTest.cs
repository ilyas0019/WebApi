using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApi.Core;
using WebApi.Core.Controllers;
using WebApi.Core.Entities;
using Microsoft.Practices.Unity;
using System.Web.Http.Dependencies;
using System.Net.Http;
using WebApi.Core.Repositories;
using WebApi.Tests.Mocks;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Net;
using WebApi.Core.BaseClasses;
using WebApi.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Common;

namespace WebApi.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private IEmployeeRepository mockEmployeeRepository;
        //private IMongoDBRepository mockmongoRepository;

        EmployeeModel empDetail;
        MongoModel mongoModel;

        public void TestSetup()
        {
            mockEmployeeRepository = new MockEmployeeRepository();
            empDetail = new EmployeeModel();
        }

        public void TestSetupController(BaseApiController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }

        [TestMethod]
        public void GetDetails()
        {
            TestSetup();
            var controller = new EmployeeController(mockEmployeeRepository, mockmongoRepository);
            TestSetupController(controller);
            HttpResponseMessage result = controller.GetDetails(empDetail);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetAllEmployee()
        {
            TestSetup();
            var controller = new EmployeeController(mockEmployeeRepository, mockmongoRepository);
            TestSetupController(controller);
            HttpResponseMessage result = controller.GetAllEmployee(empDetail);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void UpdateDetails()
        {
            var emp = new EmployeeModel { ID = 1, Name = "Updated", Hobbies="Testing" };
            TestSetup();
            var controller = new EmployeeController(mockEmployeeRepository, mockmongoRepository);
            TestSetupController(controller);
            HttpResponseMessage result = controller.UpdateEmployeeById(emp);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }
    }

}
