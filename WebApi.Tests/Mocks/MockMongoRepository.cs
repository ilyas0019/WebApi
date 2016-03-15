using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Core.Repositories;

namespace WebApi.Tests.Controllers
{
    class MockMongoRepository: IMongoDBRepository
    {

        string IMongoDBRepository.ConnecionString
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void IMongoDBRepository.GetPageState(Core.Models.MongoModel objMongo)
        {
            throw new NotImplementedException();
        }

        void IMongoDBRepository.SavePageState(Core.Models.MongoModel objMongo)
        {
            throw new NotImplementedException();
        }
    }
}
