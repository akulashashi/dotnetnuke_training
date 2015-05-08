using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using DotNetNuke.Security.Membership;
using DotNetNuke.Entities.Users;

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
        public HttpResponseMessage Auth(string Uid, string Pwd)
        {
            //return Request.CreateResponse(HttpStatusCode.OK, "Hello " + Id + " " + Id2 + " !!!");
            UserLoginStatus loginStatus = UserLoginStatus.LOGIN_FAILURE;

            //Validate User and set login information to the UserInfo object
            UserInfo objUserInfo = UserController.ValidateUser(0, Uid,
            Pwd, "DNN", "", PortalSettings.PortalName, "127.0.0.1", ref loginStatus);

            //Check validation then login
            if (loginStatus == UserLoginStatus.LOGIN_SUCCESS || loginStatus == UserLoginStatus.LOGIN_SUPERUSER)
            {
                //bool isPersistent = false;

                ////User login  
                //UserController.UserLogin(this.PortalId, objUserInfo, PortalSettings.PortalName, this.Request.UserHostAddress, isPersistent);
                //this.Response.Write("Login success");
                return Request.CreateResponse(HttpStatusCode.OK, "Success"); 

            }
            else
            {
                //this.Response.Write("Login failure");
                return Request.CreateResponse(HttpStatusCode.OK, "Faliure"); 
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloName(string Id, string Id2, string Id3)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello " + Id + " " + Id3 + " " + Id2 + " !!!");
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
