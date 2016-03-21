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
    public class MongoDBRepository<T> where T : class //, IMongoDBRepository<T>
    {

        public MongoCollection<T> collection;

        public MongoDBRepository()
        {
            MongoClient client = new MongoClient(Settings.Default.MongoConnectionString);
            MongoDatabase database = client.GetServer().GetDatabase(Settings.Default.MongoDatabase);
            collection = database.GetCollection<T>("pages-collection");
        }


        public T GetPageState(IMongoQuery query)
        {
            var result = collection.Find(query).ToList().FirstOrDefault();
            return result;
        }


        public void SavePageState(T objMongo, IMongoQuery query)
        {
            collection.Update(query, Update.Replace(objMongo), UpdateFlags.Upsert);
        }

    }
}