using WebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Repositories
{
    public interface IMongoDBRepository
    {

        MongoModel GetPageState(MongoModel objMongo);
        
        void SavePageState(MongoModel objMongo);
        
    }
}
