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
    [RoutePrefix("api/image")]
    public class ImageUploadController : ApiController
    {
        ImageService svc = new ImageService();
        [HttpPost, Route("file")]
        public HttpResponseMessage FilePost(EncodedImage encodedImage)
        {
            try
            {
                byte[] newBytes = Convert.FromBase64String(encodedImage.EncodedImageFile);

                Image model = new Image();
                model.UserFileName = "appimg";
                model.ByteArray = newBytes;
                model.Extension = encodedImage.FileExtension;
                model.SaveLocation = "Images";
                //model.UserId = 1;

                int fileId = svc.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, fileId);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
