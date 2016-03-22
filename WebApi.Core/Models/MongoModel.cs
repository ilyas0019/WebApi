using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Core.BaseClasses;

namespace WebApi.Core.Models
{
    public class MongoModel//: IMongoEntity
    {
        public string _id { get; set; }
        public string UserId { get; set; }
        public string Page { get; set; }
        public string PageVM { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}