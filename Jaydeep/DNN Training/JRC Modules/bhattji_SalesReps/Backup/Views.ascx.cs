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
using bhattji.Modules.SalesReps.Business;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;


namespace bhattji.Modules.SalesReps
{

    public abstract partial class Views : DotNetNuke.Entities.Modules.PortalModuleBase, DotNetNuke.Entities.Modules.IActionable
	{

		#region " Methods "

		private void RegisterJS()
		{
			string RattleImageJS = "<SCRIPT type=\"text/javascript\" src=\"" + ModulePath + "js/JbRattleImage.js\"></SCRIPT>";
			if ((!Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")))
			{
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RattleImageJS", RattleImageJS);
			}
			string JB_ActiveContentJS = "<SCRIPT type=\"text/javascript\" src=\"" + ModulePath + "js/JB_ActiveContent.js\"></SCRIPT>";
			if ((!Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")))
			{
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS);
			}
		}

		#endregion

		#region " Event Handlers "

		private void Page_Load(object sender, EventArgs e)
		{
			try {
				//Always get the Options Object First
				OptionsInfo objOI = new OptionsInfo(ModuleId);

				//Register Common JavaScripts
				RegisterJS();

				DotNetNuke.Entities.Modules.PortalModuleBase MyView = new DotNetNuke.Entities.Modules.PortalModuleBase();

				string ViewType = "viewcontrol";
				if (((Request.QueryString["ViewType"] != null)) && (Request.QueryString["ViewType"] != ""))
				{
					ViewType = Request.QueryString["ViewType"].ToLower();
				}
				switch (ViewType) {
					case "viewcategories":
						MyView = (ViewCategories)LoadControl(ModulePath + "ViewCategories.ascx");
						MyView.ID = "ViewCategories";
						break;
					default:
						//"viewcontrol"
						switch (objOI.ViewControl.ToUpper()) {
							case "GRID":
								MyView = (ViewGrid)LoadControl(ModulePath + "ViewGrid.ascx");
								MyView.ID = "ViewGrid";
								break;

							case "CATALOG":
								MyView = (ViewCat)LoadControl(ModulePath + "ViewCat.ascx");
								MyView.ID = "ViewCat";
								break;

							case "JUKES":
								MyView = (ViewJukes)LoadControl(ModulePath + "ViewJukes.ascx");
								MyView.ID = "ViewJukes";
								break;

							case "THUMBS":
								MyView = (ViewThumbs)LoadControl(ModulePath + "ViewThumbs.ascx");
								MyView.ID = "ViewThumbs";
								break;

							case "TABS":
								MyView = (ViewTabs)LoadControl(ModulePath + "ViewTabs.ascx");
								MyView.ID = "ViewTabs";
								break;

							default:
								//"LIST"
								MyView = (ViewList)LoadControl(ModulePath + "ViewList.ascx");
								MyView.ID = "ViewList";
								break;

						}
						break;
				}

				MyView.ModuleConfiguration = ModuleConfiguration;
				Controls.Add(MyView);

				if (!Page.IsPostBack)
				{
				}
				//Not Page.IsPostBack Then
			}

			catch (Exception exc) {
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

        }

        #endregion

		#region " Optional Interfaces "

		DotNetNuke.Entities.Modules.Actions.ModuleActionCollection DotNetNuke.Entities.Modules.IActionable.ModuleActions {
			get {
				DotNetNuke.Entities.Modules.Actions.ModuleActionCollection Actions = new DotNetNuke.Entities.Modules.Actions.ModuleActionCollection();
				//Dim objOI As New OptionsInfo(ModuleId)
				//If objOI.OnlyHostCanEdit Then
				//    Actions.Add(GetNextActionID, Localization.GetString(Entities.Modules.Actions.ModuleActionType.AddContent, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), False, DotNetNuke.Security.SecurityAccessLevel.Host, True, False)
				//    Actions.Add(GetNextActionID, Localization.GetString(Entities.Modules.Actions.ModuleActionType.ContentOptions, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), False, DotNetNuke.Security.SecurityAccessLevel.Host, True, False)
				//Else
				//    Actions.Add(GetNextActionID, Localization.GetString(Entities.Modules.Actions.ModuleActionType.AddContent, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
				//    Actions.Add(GetNextActionID, Localization.GetString(Entities.Modules.Actions.ModuleActionType.ContentOptions, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
				//End If
				Actions.Add(GetNextActionID(), Localization.GetString(DotNetNuke.Entities.Modules.Actions.ModuleActionType.AddContent, LocalResourceFile), DotNetNuke.Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
				Actions.Add(GetNextActionID(), Localization.GetString(DotNetNuke.Entities.Modules.Actions.ModuleActionType.ContentOptions, LocalResourceFile), DotNetNuke.Entities.Modules.Actions.ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
				Actions.Add(GetNextActionID(), Localization.GetString("ManageCategories", LocalResourceFile), DotNetNuke.Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditCat"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
				Actions.Add(GetNextActionID(), Localization.GetString("ManageZipcodes", LocalResourceFile), DotNetNuke.Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditZip"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
				//Actions.Add(GetNextActionID, "Edit Alts", Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl("ItemId", "1", "EditAlt"), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
				return Actions;
			}
		}

		#endregion

	}//Views

}//bhattji.Modules.SalesReps
