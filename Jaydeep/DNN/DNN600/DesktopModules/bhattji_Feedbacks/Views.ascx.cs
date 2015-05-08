// Copyright (c) 2002-2005
// by Jaydeep Bhatt, Vision Consultants. ( http://www.bhattji.com )
//
// Permission is hereby granted, to the person obtaining a copy of this software legaly and associated 
// documentation files (the "Software"), to deal in the Software with restriction, including with limitation 
// the rights to use, copy, modify, merge, PublishDate, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
//

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using bhattji.Modules.Feedbacks.Business;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Framework;

namespace bhattji.Modules.Feedbacks
{

    public abstract partial class Views : FeedbackModuleBase, IActionable
    {

        #region " Methods "

        private void RegisterJS()
        {
            //Put user code to initialize the page here
            //string RattleImageJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JbRattleImage.js\"></SCRIPT>";
            //if ((!Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")))
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RattleImageJS", RattleImageJS);
            if ((!Page.ClientScript.IsClientScriptIncludeRegistered("RattleImageJS")))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "RattleImageJS", ControlPath + "js/JbRattleImage.js");

            //string JB_ActiveContentJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JB_ActiveContent.js\"></SCRIPT>";
            //if ((!Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")))
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS);
            if ((!Page.ClientScript.IsClientScriptIncludeRegistered("JB_ActiveContentJS")))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "JB_ActiveContentJS", ControlPath + "js/JB_ActiveContent.js");
        }

        private void SetCaptcha()
        {
            Random rnd = new Random();
            int A = rnd.Next(1, 10); // creates a number between 1 and 9
            int B = rnd.Next(1, 10); // creates a number between 1 and 9

            string R = (A + B).ToString();

            lblAnswer.Text = A.ToString() + " + " + B.ToString() + " = ";
            valAnswer1.ValueToCompare = R;

            valAnswer.ErrorMessage = "Please enter number '" + R + "'";
            valAnswer1.ErrorMessage = valAnswer.ErrorMessage;
        }

        private void SubcribeToRole(string SubscriptionRole)
        {
            DotNetNuke.Entities.Users.UserInfo user = DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo();

            if (!user.IsInRole(SubscriptionRole))
                (new DotNetNuke.Security.Roles.RoleController()).AddUserRole(
                    PortalId,
                    user.UserID,
                    GetRoleId(SubscriptionRole),
                    DotNetNuke.Common.Utilities.Null.NullDate,
                    DotNetNuke.Common.Utilities.Null.NullDate);
        
        }

        private int GetRoleId(string roleName)
        {

            DotNetNuke.Security.Roles.RoleController oDnnRoleController = new DotNetNuke.Security.Roles.RoleController();
            if (oDnnRoleController.GetRoleByName(PortalId, roleName) == null)
            {
                DotNetNuke.Security.Roles.RoleInfo oRole = new DotNetNuke.Security.Roles.RoleInfo();
                oRole.PortalID = PortalId;
                oRole.RoleName = roleName;
                oRole.IsPublic = true;
                oRole.AutoAssignment = false;
                oRole.RoleGroupID = -1;
                oDnnRoleController.AddRole(oRole);
            }

            return oDnnRoleController.GetRoleByName(PortalId, roleName).RoleID;
        }

        /*** SUB FUNCTION TO SEND EMAIL ***/
        private void SendMail()
        {
            OptionsInfo objOI=new OptionsInfo(ModuleId);
            string strFrom = txtEmail.Text;
            string strTo = objOI.EmailTo;//"jibhatt@gmail.com";
            string strCC = objOI.EmailCc;//"jibhatt@yahoo.com";
            string strBCC = objOI.EmailBcc;//"jibhatt@bhattji.com";
            string strSubject = "An Email from website by " + txtName.Text;
            if (!string.IsNullOrEmpty(txtCompany.Text)) strSubject += " of "+txtCompany.Text;
            string strBody = "Name: " + txtName.Text;
            if (!string.IsNullOrEmpty(txtCompany.Text)) strBody += "<br/>Company: " + txtCompany.Text;
            if (!string.IsNullOrEmpty(txtPhone.Text)) strBody += "<br/>Phone: " + txtPhone.Text;
            strBody += "<br/>Email: " + txtEmail.Text;

            strBody += "<br/><br/>" + txtComments.Text.Replace((char)13, (char)167).Replace("§", "<br/>");
            //string strBody = txtComments.Text;
            /*** Get the host settings information***/
            System.Collections.Generic.Dictionary<string, string> hostSettings = DotNetNuke.Entities.Controllers.HostController.Instance.GetSettingsDictionary();

            /*** Set the SMTP server details ***/
            string strSMTP = hostSettings["SMTPServer"];
            string strAuth = hostSettings["SMTPAuthentication"];
            string strUser = hostSettings["SMTPUsername"];
            string strPwd = hostSettings["SMTPPassword"];

            /*** This is the actual built in function from DNN Framework. ***/
            DotNetNuke.Services.Mail.Mail.SendMail(strFrom, strTo, strCC, strBCC, 
                                                   DotNetNuke.Services.Mail.MailPriority.Normal, 
                                                   strSubject, DotNetNuke.Services.Mail.MailFormat.Html, 
                                                   System.Text.Encoding.UTF8, strBody, "",
                                                   strSMTP, strAuth, strUser, strPwd);
        }

        #endregion

        #region " Event Handlers "

        private void Page_Init(object sender, EventArgs e)
        {
            try
            {
                //Always get the Options Object First
                OptionsInfo objOI = new OptionsInfo(ModuleId);

                //Register Common JavaScripts
                RegisterJS();


                if (!Page.IsPostBack)
                {
                    SetCaptcha();
                }
                //Not Page.IsPostBack Then
            }

            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void lnbSend_Click(object sender, EventArgs e)
        {
            if (chkSubscribe.Checked)
                SubcribeToRole(new OptionsInfo(ModuleId).SubscriptionRole);

            try {
                SendMail();
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Hi " + txtName.Text + ", your eMail has been succesfully submitted";
            }
            catch {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Hi " + txtName.Text + ", your eMail could not be submitted";
            }

            
        }

        #endregion

        #region " Web Form Designer generated code "
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            //this.Load += new EventHandler(this.Page_Load);
            //this.Load += Page_Load;
            lnbSend.Click += lnbSend_Click;
        }

        #endregion

        #region " Optional Interfaces "

        ModuleActionCollection IActionable.ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                //Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.ContentOptions, LocalResourceFile), ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);

                return Actions;
            }
        }

        #endregion

    }//Views

}//bhattji.Modules.Feedbacks
