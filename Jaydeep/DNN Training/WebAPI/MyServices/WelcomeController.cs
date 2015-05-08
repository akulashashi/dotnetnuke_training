using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;

namespace MyServices
{
    public class WelcomeController : DnnApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloName(string Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello " + Id + " !!!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloName(string Id, string Id2)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello " + Id + " " + Id2 + " !!!");
        }

        //This does not work, may be you can't have the same signature in same controller
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloFullNameWrong(string Firstname, string Lastname)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello " + Firstname + " " + Lastname + " !!!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloFullName(string Firstname, string Lastname, string Middlename)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello " + Firstname + " " + Middlename + " " + Lastname + " !!!");
        }
    }
}
