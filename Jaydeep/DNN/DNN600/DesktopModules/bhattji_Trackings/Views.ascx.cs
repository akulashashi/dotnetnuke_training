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
using System.Web.UI.WebControls;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;

// <img src="http://tbs.tradedoubler.com/report?organization=1954300&event=323606&orderNumber=NSC&orderValue=10000&currency=SEK" height="0" width="0" border="0"/>

// <img src="http://tbl.tradedoubler.com/report?organization=1954300&event=323676&leadNumber=Offert&orderValue=1" height="0" width="0" border="0"/>

namespace bhattji.Modules.Trackings
{

    public abstract partial class Views : TrackingModuleBase, IActionable
    {

        #region " private Members "

        //void RegisterJS()
        //{
        //    //Put user code to initialize the page here
        //    //string RattleImageJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JbRattleImage.js\"></SCRIPT>";
        //    //if ((!Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")))
        //    //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RattleImageJS", RattleImageJS);
        //    if ((!Page.ClientScript.IsClientScriptIncludeRegistered("RattleImageJS")))
        //        Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "RattleImageJS", ControlPath + "js/JbRattleImage.js");

        //    //string JB_ActiveContentJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JB_ActiveContent.js\"></SCRIPT>";
        //    //if ((!Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")))
        //    //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS);
        //    if ((!Page.ClientScript.IsClientScriptIncludeRegistered("JB_ActiveContentJS")))
        //        Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "JB_ActiveContentJS", ControlPath + "js/JB_ActiveContent.js");
        //}


        //private void RenderTracking(HtmlTextWriter htw, OptionsInfo objOI)
        //{
        //    switch (objOI.TrackType.ToLower())
        //    {
        //        case "sl":
        //            RenderSaleLead(htw, objOI);
        //            break;
        //        default:
        //            RenderSalePixel(htw, objOI);
        //            break;
        //    }
        //}

        string TrackingURL()
        {
            OptionsInfo objOI = new OptionsInfo(ModuleId);
            
            string organizationId = string.IsNullOrEmpty(Request.QueryString["organization"])
                ? objOI.OrgId//"1954300"
                : Request.QueryString["organization"];

            string orderValue = string.IsNullOrEmpty(Request.QueryString["orderValue"])
                ? "10000"
                : Request.QueryString["orderValue"];

            string productName = string.IsNullOrEmpty(Request.QueryString["productName"])
                ? objOI.ProductName.Replace(" ","")//"KURSID"
                : Request.QueryString["productName"].Replace(" ", "");

            switch (objOI.EventId)
            {
                case "323676":
                case "323696":
                    string leadNumber = string.IsNullOrEmpty(Request.QueryString["leadNumber"])
                        ? DateTime.Now.ToString("yyMMddHHmmss")//DateTime.Now.ToString().Replace(" ", "").Replace("/", "").Replace("-", "").Replace(":", "").Replace("AM", "").Replace("PM", "")
                        : Request.QueryString["leadNumber"];

                    return "http://tbl.tradedoubler.com/report?organization=" + organizationId + "&event=" + objOI.EventId + "&leadNumber=" + productName + leadNumber + "&orderValue=" + orderValue;
                                   
                default://323606
                    string orderNumber = string.IsNullOrEmpty(Request.QueryString["orderNumber"])
                        ? DateTime.Now.ToString("yyMMddHHmmss")//DateTime.Now.ToString().Replace(" ", "").Replace("/", "").Replace("-", "").Replace(":", "").Replace("AM", "").Replace("PM", "")
                        : Request.QueryString["orderNumber"];

                    string currency = string.IsNullOrEmpty(Request.QueryString["currency"])
                        ? objOI.Currency//"SEK"
                        : Request.QueryString["currency"];

                    return "http://tbs.tradedoubler.com/report?organization=" + organizationId + "&event=323606&orderNumber=" + productName + orderNumber + "&orderValue=" + orderValue + "&currency=" + currency;
            }
            //if (objOI.TrackType.ToLower() == "sl")
            //{
            //    //string eventId = string.IsNullOrEmpty(Request.QueryString["event"])
            //    //    ? objOI.EventId//"323606"
            //    //    : Request.QueryString["event"];

            //    string orderNumber = string.IsNullOrEmpty(Request.QueryString["orderNumber"])
            //        ? DateTime.Now.ToString("yyMMddHHmmss")//DateTime.Now.ToString().Replace(" ", "").Replace("/", "").Replace("-", "").Replace(":", "").Replace("AM", "").Replace("PM", "")
            //        : Request.QueryString["orderNumber"];

            //    string currency = string.IsNullOrEmpty(Request.QueryString["currency"])
            //        ? objOI.Currency//"SEK"
            //        : Request.QueryString["currency"];

            //    return "http://tbs.tradedoubler.com/report?organization=" + organizationId + "&event=323606&orderNumber=" + orderNumber + "&orderValue=" + orderValue + "&currency=" + currency;            
            //}
            //else
            //{
            //    //string eventId = string.IsNullOrEmpty(Request.QueryString["event"])
            //    //    ? objOI.EventId//"323676"
            //    //    : Request.QueryString["event"];

            //    string leadNumber = string.IsNullOrEmpty(Request.QueryString["leadNumber"])
            //        ? DateTime.Now.ToString("yyMMddHHmmss")//DateTime.Now.ToString().Replace(" ", "").Replace("/", "").Replace("-", "").Replace(":", "").Replace("AM", "").Replace("PM", "")
            //        : Request.QueryString["leadNumber"];

            //    if (objOI.TrackType.ToLower() == "lei")
            //        return "http://tbl.tradedoubler.com/report?organization=" + organizationId + "&event=323696&leadNumber=" + leadNumber + "&orderValue=" + orderValue;
            //    else
            //        return "http://tbl.tradedoubler.com/report?organization=" + organizationId + "&event=323676&leadNumber=" + leadNumber + "&orderValue=" + orderValue;
            //}
        }
        #endregion

        #region " Event Handlers "

        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Web.UI.HtmlControls.HtmlImage trackerImg = new System.Web.UI.HtmlControls.HtmlImage();
                trackerImg.Src = TrackingURL();
                trackerImg.Width = 0;
                trackerImg.Height = 0;

                Controls.Add(trackerImg);
                //Image trackerImg = new Image();
                //trackerImg.ImageUrl = TrackingURL();
                //trackerImg.Width = 0;
                //trackerImg.Height = 0;

                //Controls.Add(trackerImg);
                //trackerImg.Src = TrackingURL();
            }
        }

        //protected override void Render(HtmlTextWriter htw)
        //{
        //    htw.AddAttribute(HtmlTextWriterAttribute.Src, TrackingURL());
        //    htw.AddAttribute(HtmlTextWriterAttribute.Width, "0");
        //    htw.AddAttribute(HtmlTextWriterAttribute.Height, "0");
        //    htw.AddAttribute(HtmlTextWriterAttribute.Border, "0");

        //    htw.RenderBeginTag(HtmlTextWriterTag.Img);
        //    htw.RenderEndTag();//Img
        //}

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
                //Actions.Add(GetNextActionID(), Localization.GetString("ManageCategories", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditCat"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID(), Localization.GetString("ManageZipcodes", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditZip"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID, "Edit Alts", Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl("ItemId", "1", "EditAlt"), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
                /*
                OptionsInfo objOI = new OptionsInfo(ModuleId,TabId);
                if (IsEditable || (new OptionsInfo(ModuleId, TabId)).CanAdd) Actions.Add(GetNextActionID(), "Add", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanAlter) Actions.Add(GetNextActionID(), "Alter", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanApprove) Actions.Add(GetNextActionID(), "Approve", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanDelete) Actions.Add(GetNextActionID(), "Delete", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanSelfEdit) Actions.Add(GetNextActionID(), "SelfEdit", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Add", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Alter", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Approve", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Delete", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "SelfEdit", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                */
                return Actions;
            }
        }

        #endregion

    }//Views

}//bhattji.Modules.Trackings
