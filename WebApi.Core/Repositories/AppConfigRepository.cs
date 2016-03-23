using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.CData.MongoDB;
using System.Linq;
using System.Web;
using WebApi.Core.BaseClasses;
using WebApi.Core.Models;
using WebApi.Core.Properties;

namespace WebApi.Core.Repositories
{
    public class AppConfigRepository<T>
    {

        public MongoCollection<T> collection;

        public AppConfigRepository()
        {
            MongoClient client = new MongoClient(Settings.Default.MongoConnectionString);
            MongoDatabase database = client.GetServer().GetDatabase(Settings.Default.MongoDatabase);
            collection = database.GetCollection<T>("system.js");
        }


        public T GetSystemStoredProcedureName(IMongoQuery query)
        {
            var result = collection.Find(query).ToList().FirstOrDefault();
            return result;
        }


    }
}