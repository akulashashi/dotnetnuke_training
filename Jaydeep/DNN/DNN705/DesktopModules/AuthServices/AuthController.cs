using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using DotNetNuke.Security.Membership;
using DotNetNuke.Entities.Users;

namespace AuthServices
{
    public class AuthController : DnnApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Login(string Uid, string Pwd)
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

    }
}
