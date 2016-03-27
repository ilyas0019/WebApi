using Microsoft.Practices.Unity;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApi.Core.Properties;
using WebApi.Core.Repositories;

namespace WebApi.Core.BaseClasses
{
    public class BaseApiController : ApiController
    {

        protected T GetPageState<T>(IMongoQuery query)
        {
            MongoDatabase database = new MongoClient(Settings.Default.MongoConnectionString).GetServer().GetDatabase(Settings.Default.MongoDatabase);
            MongoCollection collection = database.GetCollection<T>("pages-collection");
            var result = collection.FindAs<T>(query).ToList().FirstOrDefault();
            return result;
        }


        protected T SavePageState<T>(T objMongo, IMongoQuery query)
        {
            MongoDatabase database = new MongoClient(Settings.Default.MongoConnectionString).GetServer().GetDatabase(Settings.Default.MongoDatabase);
            MongoCollection collection = database.GetCollection<T>("pages-collection");
            collection.Remove(query);
            collection.Update(query, Update.Replace(objMongo), UpdateFlags.Upsert);
            return objMongo;
        }

    }
}
