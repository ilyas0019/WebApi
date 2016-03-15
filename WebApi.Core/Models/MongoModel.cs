using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Core.Models
{
    public class MongoModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string User { get; set; }
        public string Page { get; set; }
        public string PageVM { get; set; }
        public string SessionID { get; set; }
    }
}