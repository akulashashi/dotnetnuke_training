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

namespace bhattji.Modules.SalesReps
{

    public abstract partial class Edits : DotNetNuke.Entities.Modules.PortalModuleBase
	{

		#region " Private Members "
		#endregion

		#region " Public Methods "

		#endregion

		#region " Event Handlers "

		private void Page_Load(object sender, EventArgs e)
		{
			try {
				//Dim objOI As New OptionsInfo(ModuleId)
				string EditType = "edititem";
				try {
					if (((Request.QueryString["EditType"] != null)) && (Request.QueryString["EditType"] != ""))
					{
						EditType = Request.QueryString["EditType"].ToLower();
					}
				}
				catch {
				}

				//Select Case EditType
				//    Case "editalt"
				//        Dim MyEditAlt As EditAlt = CType(LoadControl(ModulePath & "EditAlt.ascx"), EditAlt)
				//        With MyEditAlt
				//            '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditAlt.ascx")
				//            .ModuleConfiguration = ModuleConfiguration
				//            .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditAlt.ascx")
				//        End With 'MyEditAlt
				//        Controls.Add(MyEditAlt)

				//    Case Else '"edititem", "EditItem"
				//        Dim MyEditItem As EditItem = CType(LoadControl(ModulePath & "EditItem.ascx"), EditItem)
				//        With MyEditItem
				//            '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
				//            .ModuleConfiguration = ModuleConfiguration
				//            .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
				//        End With 'MyEditItem
				//        Controls.Add(MyEditItem)
				//End Select

				DotNetNuke.Entities.Modules.PortalModuleBase MyEdit;
				switch (EditType.ToLower()) {
					case "editcat":
						MyEdit = (ViewCategories)LoadControl(ModulePath + "ViewCategories.ascx");
						MyEdit.ID = "ViewCategories";
						break;
					case "editzip":
						MyEdit = (ViewZipCodes)LoadControl(ModulePath + "ViewZipCodes.ascx");
						MyEdit.ID = "ViewZipCodes";
						break;
					default:
						//"edititem", "EditItem"
						MyEdit = (EditItem)LoadControl(ModulePath + "EditItem.ascx");
						MyEdit.ID = "EditItem";
						break;
				}
				MyEdit.ModuleConfiguration = ModuleConfiguration;
				Controls.Add(MyEdit);
			}

			//Dim MyEditItem As EditItem = CType(LoadControl(ModulePath & "EditItem.ascx"), EditItem)
			//With MyEditItem
			//    '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
			//    .ModuleConfiguration = ModuleConfiguration
			//    .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
			//End With 'MyEditItem
			//Controls.Add(MyEditItem)

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

	}
	//Edits

}
//bhattji.Modules.SalesReps
