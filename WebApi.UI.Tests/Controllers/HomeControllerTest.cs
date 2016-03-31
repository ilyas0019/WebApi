using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApi.UI;
using WebApi.UI.Controllers;

namespace WebApi.UI.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [TestCase]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

    }
}
