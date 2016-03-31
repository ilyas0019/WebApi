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
    public abstract class BaseApiController : ApiController
    {

        MongoClient mongoClient;
        MongoDatabase database;
        MongoCollection collection;
        public string CollectionName { get; set; }

        public BaseApiController()
        {
            mongoClient = new MongoClient(Settings.Default.MongoConnectionString);
            database = mongoClient.GetServer().GetDatabase(Settings.Default.MongoDatabase);
        }


        public BaseApiController(string connectionString, string mongoDBName)
        {
            mongoClient = new MongoClient(connectionString);
            database = mongoClient.GetServer().GetDatabase(mongoDBName);
        }

        protected virtual T GetDataFromCollection<T>(IMongoQuery query)
        {
            mongoClient = GetServerState();
            collection = database.GetCollection<T>(CollectionName);
            var result = collection.FindAs<T>(query).ToList().FirstOrDefault();
            mongoClient.GetServer().Disconnect();
            return result;
        }


        protected virtual T SaveDataToCollection<T>(T objMongo, IMongoQuery query)
        {
            mongoClient = GetServerState();
            collection = database.GetCollection<T>(CollectionName);
            collection.Remove(query);
            collection.Update(query, Update.Replace(objMongo), UpdateFlags.Upsert);
            mongoClient.GetServer().Disconnect();
            return objMongo;
        }

        private MongoClient GetServerState()
        {
            if (mongoClient.GetServer().State == MongoServerState.Disconnected)
            {
                mongoClient.GetServer().Connect();
            }
            return mongoClient;
        }
    }
}
