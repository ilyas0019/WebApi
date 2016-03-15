using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.CData.MongoDB;
using System.Linq;
using System.Web;
using WebApi.Core.Models;
using WebApi.Core.Properties;

namespace WebApi.Core.Repositories
{
    public class MongoDBRepository : IMongoDBRepository
    {
        MongoCollection<MongoModel> collection;

        public MongoDBRepository()
        {
            MongoClient client = new MongoClient(Settings.Default.MongoConnectionString);
            MongoDatabase database = client.GetServer().GetDatabase(Settings.Default.MongoDatabase);
            collection = database.GetCollection<MongoModel>("pagecollection");
        }

        public MongoModel GetPageState(MongoModel objMongo)
        {
            var filer =new MongoFilter{ User ="1"};
                    
            var query=Query<MongoModel>.EQ(x=> x.User,filer.User);

            var result = collection.Find(query).ToList().FirstOrDefault();

            return result;
        }

        public void SavePageState(MongoModel objMongo)
        {

            objMongo.User = "1";
            objMongo.Page = "2";
            objMongo.PageVM = "3";
            objMongo.SessionID = "4";

            collection.Insert(objMongo);

        }
    }
}