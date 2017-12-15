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
    [RoutePrefix("/api/register")]
    public class RegisterController : ApiController
    {
        [Route("/post"), HttpPost]
        public HttpResponseMessage Post(People model)
        {
            model.ModifiedBy = "admin";
            PeopleService svc = new PeopleService();
            int id = svc.Insert(model);
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = id;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
