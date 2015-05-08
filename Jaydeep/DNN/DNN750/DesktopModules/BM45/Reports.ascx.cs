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
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;
using DotNetNuke.Services.Localization;

namespace bhattji.Modules.XYZ70s
{
    public abstract partial class Reports : XYZ70ModuleBase
    {
        #region " Private Members "
        #endregion

        #region " Public Methods "

        #endregion

        #region " Event Handlers "

        private void Page_Init(object sender, EventArgs e)
        {
            try
            {
                //Dim objOI As New OptionsInfo(ModuleId)
                string ReportType = "itemdetails";
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["ReportType"]))
                        ReportType = Request.QueryString["ReportType"].ToLower();                   
                }
                catch
                {
                }

                XYZ70ModuleBase MyReport;
                switch (ReportType)
                {
                    case "itemdetails":
                        MyReport = (Details)LoadControl(ControlPath + "Details.ascx");
                        MyReport.ID = "Details";
                        //ModuleConfiguration.ModuleTitle = "XYZ Details";
                        break;

                    default: //"itemdetails"
                        MyReport = (Details)LoadControl(ControlPath + "Details.ascx");
                        MyReport.ID = "Details";
                        //ModuleConfiguration.ModuleTitle = "XYZ Details";
                        break;
                }
                ModuleConfiguration.ModuleTitle = Localization.GetString(MyReport.ID + "Title", LocalResourceFile);
                MyReport.ModuleConfiguration = ModuleConfiguration;

                if (AJAX.IsInstalled())
                {
                    AJAX.RegisterScriptManager();

                    Panel pnlBhattji = new Panel();
                    //pnlBhattji.ID = "pnlBhattji";
                    pnlBhattji.Style.Add(HtmlTextWriterStyle.Position, "relative");
                    pnlBhattji.Controls.Add(MyReport);

                    //AJAX.WrapUpdatePanelControl(pnlBhattji, True) 
                    UpdatePanel AjaxPanel = new UpdatePanel();
                    //AjaxPanel.ID = "updtpnlBhattji";
                    AjaxPanel.UpdateMode = UpdatePanelUpdateMode.Conditional;
                    AjaxPanel.ContentTemplateContainer.Controls.Add(pnlBhattji);

                    Controls.Add(AjaxPanel);
                }
                else
                {
                    Controls.Add(MyReport);
                }
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
            ////this.Load += new EventHandler(this.Page_Load);
            //this.Load += Page_Load;
        }

        #endregion

    } //Reports

} //bhattji.Modules.XYZ70s
