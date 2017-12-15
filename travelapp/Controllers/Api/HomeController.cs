using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace travelapp.Controllers.App
{
    [RoutePrefix("/api/home")]
    public class HomeController : ApiController
    {
        [Route(""), HttpPost]
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Posting");
        }

    }
}
