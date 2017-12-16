using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using travelapp.models;
using travelapp.services;

namespace travelapp.Controllers.Api
{
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        [HttpPost]
        [Route]
        public HttpResponseMessage Post(People model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                model.ModifiedBy = "admin";
                PeopleService svc = new PeopleService();
                int id = svc.Insert(model);
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = id;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("get")]
        public HttpResponseMessage Get()
        {
            try
            {
                PeopleService svc = new PeopleService();
                ItemsResponse<People> resp = new ItemsResponse<People>();
                resp.Items = svc.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                PeopleService svc = new PeopleService();
                ItemResponse<People> resp = new ItemResponse<People>();
                resp.Item = svc.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Put(int id, People model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                PeopleService svc = new PeopleService();
                model.ModifiedBy = "admin";
                svc.Update(model);
                SuccessResponse response = new SuccessResponse();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                PeopleService svc = new PeopleService();
                svc.Delete(id);
                SuccessResponse resp = new SuccessResponse();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception msg)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, msg.Message);
            }
        }
    }
}