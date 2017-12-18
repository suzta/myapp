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
        [RoutePrefix("api/scraping")]
    public class WebScrapingController : ApiController
    {

        [Route("getall"), HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<WebScraping> res = new List<WebScraping>();
                WebScrapingService svc = new WebScrapingService();

                res = svc.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("save"), HttpPost]
        public HttpResponseMessage Post(WebScraping model)
        {
            try
            {
                WebScrapingService svc = new WebScrapingService();
                int id = svc.Post(model);
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = id;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
