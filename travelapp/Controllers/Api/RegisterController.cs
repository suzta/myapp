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
        [Route, HttpPost]
        public HttpResponseMessage Register(RegisterUser model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                model.ModifiedBy = "admin";
                RegisterUserService svc = new RegisterUserService();
                int id = svc.Insert(model);
                ItemResponse<int> resp = new ItemResponse<int>();
                resp.Item = id;
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{email}/"), HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage login(string email)
        {
            try
            {
                RegisterUserService svc = new RegisterUserService();
                ItemResponse<bool> resp = new ItemResponse<bool>();
                resp.Item = svc.Login(email);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
