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
    [RoutePrefix("api/register")]
    public class RegisterController : ApiController
    {
        //[HttpPost]
        //[Route]
        //public HttpResponseMessage Post(People model)
        //{
        //    model.ModifiedBy = "admin";
        //    PeopleService svc = new PeopleService();
        //    int id = svc.Insert(model);
        //    ItemResponse<int> response = new ItemResponse<int>();
        //    response.Item = id;
        //    return Request.CreateResponse(HttpStatusCode.OK, response);
        //}

        [HttpGet]
        [Route("get")]
        public HttpResponseMessage Get()
        {
            PeopleService svc = new PeopleService();
            ItemsResponse<People> resp = new ItemsResponse<People>();
            resp.Items = svc.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
    }
}