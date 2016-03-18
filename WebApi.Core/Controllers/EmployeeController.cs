using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Core.BaseClasses;
using WebApi.Core.Entities;
using WebApi.Core.Repositories;
using System.Net.Http;
using System.Net;
using WebApi.Core.Models;
using System.Web.Helpers;
using System.Net.Http.Formatting;
using MongoDB.Driver.Builders;
using System.Web.SessionState;

namespace WebApi.Core.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly MongoDBRepository<MongoModel> mongoRepository;
        
        public EmployeeController(IEmployeeRepository prmEmployeeRepository) : base(prmEmployeeRepository)
        {
            this.employeeRepository = prmEmployeeRepository;
            mongoRepository = new MongoDBRepository<MongoModel>();
        }

        [HttpGet]
        [ActionName("GetDetails")]
        public HttpResponseMessage GetDetails(EmployeeModel empDetail)
        {
            try
            {
                return Request.CreateResponse<APIResponse>(HttpStatusCode.OK, new APIResponse { Result = null });
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex);
            }
        }

        [HttpPost]
        [ActionName("GetAllEmployee")]
        public HttpResponseMessage GetAllEmployee(EmployeeModel empDetail)
        {
            var allEmployee = employeeRepository.GetAllEmployee();
            try
            {
                return Request.CreateResponse<APIResponse>(HttpStatusCode.OK, new APIResponse { Result = allEmployee });
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex);
            }
        }

        [HttpPost]
        [ActionName("GetEmployeeById")]
        public HttpResponseMessage GetEmployeeById(EmployeeModel empDetail)
        {
            var emp = new List<EmployeeModel>();
            try
            {
                var employee = employeeRepository.GetEmployeeById(empDetail);
                emp.Add(employee);

                return Request.CreateResponse<APIResponse>(HttpStatusCode.OK, new APIResponse { Result = emp });
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex);
            }
        }

        [HttpPost]
        [ActionName("UpdateEmployeeById")]
        public HttpResponseMessage UpdateEmployeeById(EmployeeModel empDetail)
        {
            var emp = new List<EmployeeModel>();
            try
            {
                var employee = employeeRepository.UpdateEmployeeById(empDetail);
                emp.Add(employee);

                return Request.CreateResponse<APIResponse>(HttpStatusCode.OK, new APIResponse { Result = emp });
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex);
            }
        }



        [HttpPost]
        [ActionName("SavePageState")]
        public HttpResponseMessage SavePageState(MongoModel mongoModel)
        {
            try
            {
                var entityQuery = Query.And(
                      Query<MongoModel>.EQ(e => e.Id, "1"),
                      Query<MongoModel>.EQ(e => e.SessionID, (new SessionIDManager()).GetSessionID(HttpContext.Current))
                  );

                mongoModel.SessionID = (new SessionIDManager()).GetSessionID(HttpContext.Current);
                mongoRepository.SavePageState(mongoModel, entityQuery);

                return Request.CreateResponse<APIResponse>(HttpStatusCode.OK, new APIResponse { Result = null });
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex);
            }
        }


        [HttpGet]
        [ActionName("GetPageState")]
        public HttpResponseMessage GetPageState(int id)
        {
            
            try
            {

                var entityQuery = Query.And(
                      Query<MongoModel>.EQ(e => e.Id, id.ToString()),
                      Query<MongoModel>.EQ(e => e.SessionID, (new SessionIDManager()).GetSessionID(HttpContext.Current))
                  );

                var result = mongoRepository.GetPageState(entityQuery);

                return Request.CreateResponse<MongoModel>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex);
            }
        }

        private HttpResponseMessage ErrorMessage(Exception ex)
        {
            return Request.CreateResponse<ApplicationException>(HttpStatusCode.ExpectationFailed, new ApplicationException { Source = ex.Message });
        }
    }
}
