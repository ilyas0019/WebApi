using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Models
{
    public class AppModel
    {
        public string _id { get; set; }
        public BsonJavaScript value { get; set; }
    }
}
