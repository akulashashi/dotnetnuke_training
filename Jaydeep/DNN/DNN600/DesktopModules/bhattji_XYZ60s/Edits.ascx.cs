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

namespace bhattji.Modules.XYZ60s
{
    public abstract partial class Edits : XYZ60ModuleBase
    {
        #region " Private Members "
        #endregion

        #region " Public Methods "

        XYZ60ModuleBase GetEditControl(string ControlSrc)
        {
            XYZ60ModuleBase MyPMB;
            switch (ControlSrc.ToLower())
            {
                case "editcat":
                    MyPMB = (ViewCategories)LoadControl(ControlPath + "ViewCategories.ascx");
                    MyPMB.ID = "ViewCategories";
                    //ModuleConfiguration.ModuleTitle = "Edit Categories";
                    break;
                case "editzip":
                    MyPMB = (ViewZipCodes)LoadControl(ControlPath + "ViewZipCodes.ascx");
                    MyPMB.ID = "ViewZipCodes";
                    //ModuleConfiguration.ModuleTitle = "Edit ZipCodes";
                    break;
                default: //"edititem", "EditItem"
                    MyPMB = (EditItem)LoadControl(ControlPath + "EditItem.ascx");
                    MyPMB.ID = "EditItem";
                    //ModuleConfiguration.ModuleTitle = "Edit XYZ60";
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
                //Dim objOI As New OptionsInfo(ModuleId)
                string EditType = "edititem";
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["EditType"]))
                        EditType = Request.QueryString["EditType"].ToLower();
                }
                catch
                {
                }

                //XYZ60ModuleBase MyEdit;
                //switch (EditType.ToLower())
                //{
                //    case "editcat":
                //        MyEdit = (ViewCategories)LoadControl(ControlPath + "ViewCategories.ascx");
                //        MyEdit.ID = "ViewCategories";
                //        //ModuleConfiguration.ModuleTitle = "Edit Categories";
                //        break;
                //    case "editzip":
                //        MyEdit = (ViewZipCodes)LoadControl(ControlPath + "ViewZipCodes.ascx");
                //        MyEdit.ID = "ViewZipCodes";
                //        //ModuleConfiguration.ModuleTitle = "Edit ZipCodes";
                //        break;
                //    default: //"edititem", "EditItem"
                //        MyEdit = (EditItem)LoadControl(ControlPath + "EditItem.ascx");
                //        MyEdit.ID = "EditItem";
                //        //ModuleConfiguration.ModuleTitle = "Edit XYZ60";
                //        break;
                //}
                XYZ60ModuleBase MyEdit = GetEditControl(EditType);
                //ModuleConfiguration.ModuleTitle = Localization.GetString(MyEdit.ID + "Title", LocalResourceFile);
                //MyEdit.ModuleConfiguration = ModuleConfiguration;
                Controls.Add(MyEdit);
                //if (AJAX.IsInstalled())
                //{
                //    AJAX.RegisterScriptManager();

                //    Panel pnlBhattji = new Panel();
                //    //pnlBhattji.ID = "pnlBhattji";
                //    pnlBhattji.Style.Add(HtmlTextWriterStyle.Position, "relative");
                //    pnlBhattji.Controls.Add(MyEdit);

                //    //AJAX.WrapUpdatePanelControl(pnlBhattji, True) 
                //    UpdatePanel AjaxPanel = new UpdatePanel();
                //    //AjaxPanel.ID = "updtpnlBhattji";
                //    AjaxPanel.UpdateMode = UpdatePanelUpdateMode.Conditional;
                //    AjaxPanel.ContentTemplateContainer.Controls.Add(pnlBhattji);

                //    Controls.Add(AjaxPanel);
                //}
                //else
                //{
                //    Controls.Add(MyEdit);
                //}
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

    } //Edits

} //bhattji.Modules.XYZ60s
