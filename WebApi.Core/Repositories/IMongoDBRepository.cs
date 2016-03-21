using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Core.Repositories;

namespace WebApi.Core.Repositories
{
    public interface IMongoDBRepository<T>
    {

        T GetPageState(IMongoQuery query);
        void SavePageState(T objMongo, IMongoQuery query);

    }
}
