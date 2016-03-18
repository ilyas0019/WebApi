using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApi.Core.Repositories;

namespace WebApi.Core.BaseClasses
{
    public class BaseApiController : ApiController
    {
        public BaseApiController(IEmployeeRepository iEmployee) 
        {

        }
    }
}
