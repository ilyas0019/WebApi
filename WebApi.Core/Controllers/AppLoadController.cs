using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Core.BaseClasses;
using WebApi.Core.Entities;
using WebApi.Core.Repositories;
using System.Net.Http;
using System.Net;
using WebApi.Core.Models;
using System.Web.Helpers;
using System.Net.Http.Formatting;
using MongoDB.Driver.Builders;
using System.Web.SessionState;

namespace WebApi.Core.Controllers
{
    public class AppLoadController : BaseApiController
    {
        private readonly AppRepository<AppModel> appRepository;

        public AppLoadController()
        {
            appRepository = new AppRepository<AppModel>();
        }


        [HttpGet]
        [ActionName("GetApplicationConfig")]
        public HttpResponseMessage GetApplicationConfig(AppModel appModel)
        {
            try
            {
                var mgQuery = Query.And(
                       Query<MongoModel>.EQ(e => e._id, "loaddata")
                   );

                appModel = appRepository.GetSystemStoredProcedureName(mgQuery);

                return Request.CreateResponse<AppModel>(HttpStatusCode.OK, appModel);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex);
            }
        }


        private HttpResponseMessage ErrorMessage(Exception ex)
        {
            return Request.CreateResponse<ApplicationException>(HttpStatusCode.ExpectationFailed, new ApplicationException { Source = ex.Message });
        }

      
    }
}
