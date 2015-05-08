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
//using bhattji.Modules.XYZ70s.Business;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Framework;

namespace bhattji.Modules.XYZ70s
{

    public abstract partial class Views : XYZ70ModuleBase, IActionable
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

        XYZ70ModuleBase GetViewControl(string ControlSrc)
        {
            XYZ70ModuleBase MyPMB;
            switch (ControlSrc.ToLower())
            {
                case "viewcategories":
                    MyPMB = (ViewCategories)LoadControl(ControlPath + "ViewCategories.ascx");
                    MyPMB.ID = "ViewCategories";
                    break;

                case "grid":
                    MyPMB = (ViewGrid)LoadControl(ControlPath + "ViewGrid.ascx");
                    MyPMB.ID = "ViewGrid";
                    break;

                case "catalog":
                    MyPMB = (ViewCat)LoadControl(ControlPath + "ViewCat.ascx");
                    MyPMB.ID = "ViewCat";
                    break;

                case "jukes":
                    MyPMB = (ViewJukes)LoadControl(ControlPath + "ViewJukes.ascx");
                    MyPMB.ID = "ViewJukes";
                    break;

                case "thumbs":
                    MyPMB = (ViewThumbs)LoadControl(ControlPath + "ViewThumbs.ascx");
                    MyPMB.ID = "ViewThumbs";
                    break;

                case "tabs":
                    MyPMB = (ViewTabs)LoadControl(ControlPath + "ViewTabs.ascx");
                    MyPMB.ID = "ViewTabs";
                    break;

                default:
                    //"list"
                    MyPMB = (ViewList)LoadControl(ControlPath + "ViewList.ascx");
                    MyPMB.ID = "ViewList";
                    break;
            }
            ModuleConfiguration.ModuleTitle = Localization.GetString(MyPMB.ID + "Title", LocalResourceFile);
            MyPMB.ModuleConfiguration = ModuleConfiguration;

            return MyPMB;
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

                string ViewType = "viewcontrol";
                if (!string.IsNullOrEmpty(Request.QueryString["ViewType"]))
                    ViewType = Request.QueryString["ViewType"].ToLower();

                //XYZ70ModuleBase MyView = new XYZ70ModuleBase();
                //switch (ViewType)
                //{
                //    case "viewcategories":
                //        MyView = (ViewCategories)LoadControl(ControlPath + "ViewCategories.ascx");
                //        MyView.ID = "ViewCategories";
                //        break;
                //    default:
                //        //"viewcontrol"
                //        switch (objOI.ViewControl.ToUpper())
                //        {
                //            case "GRID":
                //                MyView = (ViewGrid)LoadControl(ControlPath + "ViewGrid.ascx");
                //                MyView.ID = "ViewGrid";
                //                break;

                //            case "CATALOG":
                //                MyView = (ViewCat)LoadControl(ControlPath + "ViewCat.ascx");
                //                MyView.ID = "ViewCat";
                //                break;

                //            case "JUKES":
                //                MyView = (ViewJukes)LoadControl(ControlPath + "ViewJukes.ascx");
                //                MyView.ID = "ViewJukes";
                //                break;

                //            case "THUMBS":
                //                MyView = (ViewThumbs)LoadControl(ControlPath + "ViewThumbs.ascx");
                //                MyView.ID = "ViewThumbs";
                //                break;

                //            case "TABS":
                //                MyView = (ViewTabs)LoadControl(ControlPath + "ViewTabs.ascx");
                //                MyView.ID = "ViewTabs";
                //                break;

                //            default:
                //                //"LIST"
                //                MyView = (ViewList)LoadControl(ControlPath + "ViewList.ascx");
                //                MyView.ID = "ViewList";
                //                break;

                //        }
                //        break;
                //}

                string ControlSrc = objOI.ViewControl;
                if (ViewType.ToLower() == "viewcategories")
                    ControlSrc = "ViewCategories";
                XYZ70ModuleBase MyView = GetViewControl(ControlSrc);
                //ModuleConfiguration.ModuleTitle = Localization.GetString(MyView.ID + "Title", LocalResourceFile);
                //MyView.ModuleConfiguration = ModuleConfiguration;

                if (AJAX.IsInstalled())
                {
                    AJAX.RegisterScriptManager();

                    Panel pnlBhattji = new Panel();
                    //pnlBhattji.ID = "pnlBhattji";
                    pnlBhattji.Style.Add(HtmlTextWriterStyle.Position, "relative");
                    pnlBhattji.Controls.Add(MyView);

                    //AJAX.WrapUpdatePanelControl(pnlBhattji, True) 
                    UpdatePanel AjaxPanel = new UpdatePanel();
                    //AjaxPanel.ID = "updtpnlBhattji";
                    AjaxPanel.UpdateMode = UpdatePanelUpdateMode.Conditional;
                    AjaxPanel.ContentTemplateContainer.Controls.Add(pnlBhattji);
                    Controls.Add(AjaxPanel);
                }
                else
                {
                    Controls.Add(MyView);
                }

                if (!Page.IsPostBack)
                {
                }
                //Not Page.IsPostBack Then
            }

            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
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
        }

        #endregion

        #region " Optional Interfaces "

        ModuleActionCollection IActionable.ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.ContentOptions, LocalResourceFile), ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                Actions.Add(GetNextActionID(), Localization.GetString("ManageCategories", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditCat"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                Actions.Add(GetNextActionID(), Localization.GetString("ManageZipcodes", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditZip"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
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

}//bhattji.Modules.XYZ70s
