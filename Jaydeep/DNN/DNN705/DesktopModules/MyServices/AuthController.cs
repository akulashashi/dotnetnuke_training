using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;

namespace MyServices
{
    public class AuthController : DnnApiController
    {

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Login(string Id1, string Id2)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello " + Id1 + " " + Id2 + " !!!");
        }

    }
}
