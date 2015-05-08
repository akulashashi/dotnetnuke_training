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
            if ((!Page.ClientScript.IsClientScriptIncludeRegistered("RattleImageJS")))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "RattleImageJS", ControlPath + "js/JbRattleImage.js");

            if ((!Page.ClientScript.IsClientScriptIncludeRegistered("JB_ActiveContentJS")))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "JB_ActiveContentJS", ControlPath + "js/JB_ActiveContent.js");
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
                Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.ContentOptions, LocalResourceFile), ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                return Actions;
            }
        }

        #endregion

    }//Views

}//bhattji.Modules.XYZ70s
