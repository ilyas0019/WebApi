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
using System.Web.Script.Serialization;
using System.IO;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using System.Text;
using MongoDB.Bson;
using WebApi.Core.Properties;

namespace WebApi.Core.Controllers
{
    public class AppConfigController : BaseApiController
    {

        private static string connectionString = Settings.Default.MongoConnectionString;
        private static string mongoDBName = Settings.Default.MongoDatabase;

        public AppConfigController(): base (connectionString,mongoDBName)
        {
            CollectionName = "systems.js";
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
                appModel = GetDataFromCollection<AppModel>(mgQuery);
                appModel.value = null;
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
