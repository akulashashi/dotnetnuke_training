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

using System.Web.UI.WebControls;
using System;
using System.Collections;
using System.Web.UI;
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Services.Exceptions;
using bhattji.Modules.SalesReps.Business;

namespace bhattji.Modules.SalesReps
{

	/// -----------------------------------------------------------------------------
	/// <summary>
	/// The Links Class provides the UI for displaying the Links
	/// </summary>
	///
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[bhattji]	9/23/2004	Moved Links to a separate Project
	///		[bhattji]	10/20/2004	Removed ViewOptions from Action menu
	/// </history>
	/// -----------------------------------------------------------------------------
    public abstract partial class ViewTabs : DotNetNuke.Entities.Modules.PortalModuleBase
	{

		#region " Properties "
		public DotNetNuke.Framework.CDefault BasePage {
			get { return (DotNetNuke.Framework.CDefault)this.Page; }
		}
		#endregion

		#region " Private Members "

        private OptionsInfo objOI;

		#endregion

		#region " Methods "


		#endregion

		#region " Event Handlers "

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// Page_Load runs when the control is loaded
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[bhattji]	9/23/2004	Moved Links to a separate Project
		/// </history>
		/// -----------------------------------------------------------------------------
		private void Page_Load(object sender, EventArgs e)
		{
			try {
				//Sample code to get data
				objOI = new OptionsInfo(ModuleId);
				//Dim ph As PlaceHolder = CType(Me.BasePage.FindControl("phDNNHead"), PlaceHolder)
				PlaceHolder ph = (PlaceHolder)this.BasePage.FindControl("CSS");

				if ((ph != null))
				{
					Literal lit = new Literal();
					//lit.Text = "<link type=""text/css"" rel=""StyleSheet"" href=""" & ModulePath & "css/" & "tab-webfx.css"" />"
					//lit.Text = "<link type=""text/css"" rel=""StyleSheet"" href=""" & ModulePath & "css/tab.luna.css"" />"
					lit.Text = "<link type=\"text/css\" rel=\"StyleSheet\" href=\"" + ModulePath + "css/" + objOI.TabCss + "\" />";
                    lit.Text += "<script type=\"text/javascript\" src=\"" + ModulePath + "js/tabpane.js\"></script>";
                   
					ph.Controls.Add(lit);
				}

				//RenderTabbedPage()

				if (!Page.IsPostBack)
				{
				}
				//Not Page.IsPostBack Then
			}

			catch (Exception exc) {
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}
		//Page_Load

		protected override void Render(HtmlTextWriter writer)
		{
            //SalesRepInfo objSalesRep;
			ArrayList al = (ArrayList)(new SalesRepsController()).GetModuleSalesReps(ModuleId);
			//Dim al As List(Of SalesRepInfo) = (New SalesRepsController).GetModuleSalesReps("")

			{
				writer.AddAttribute(HtmlTextWriterAttribute.Id, "TabPane" + ModuleId.ToString());
				writer.AddAttribute(HtmlTextWriterAttribute.Class, "tab-pane");
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
                foreach (SalesRepInfo objSalesRep in al)
                {
					writer.AddAttribute(HtmlTextWriterAttribute.Id, "TabPage" + objSalesRep.ItemId.ToString());
					writer.AddAttribute(HtmlTextWriterAttribute.Class, "tab-page");
					writer.RenderBeginTag(HtmlTextWriterTag.Div);

					writer.AddAttribute(HtmlTextWriterAttribute.Class, "tab");
					writer.RenderBeginTag(HtmlTextWriterTag.A);
					//.Write(" " & objSalesRep.Title & " ")
					writer.Write(objSalesRep.Title);
					writer.RenderEndTag();
					//</A>

					if (IsEditable)
					{
						writer.AddAttribute(HtmlTextWriterAttribute.Href, EditUrl("ItemId", objSalesRep.ItemId.ToString()));
						//.AddAttribute(HtmlTextWriterAttribute.Title, "Edit this Item: " & objSalesRep.Title & ", ItemId: " & objSalesRep.ItemId.ToString())
						writer.AddAttribute(HtmlTextWriterAttribute.Title, "Edit this Item: '" + objSalesRep.Title + "'");
						writer.AddAttribute("onmouseover", "window.status=this.title; return true");
						writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.AddAttribute(HtmlTextWriterAttribute.Src, Globals.AddHTTP(Globals.GetDomainName(Request) + "~/images/edit.gif"));
						writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
						writer.RenderBeginTag(HtmlTextWriterTag.Img);
						writer.RenderEndTag();
						//</Img>
						writer.RenderEndTag();
						//</A>
					}
					if (objSalesRep.MediaSrc != string.Empty)
					{
						bhattjiMedia MyMedia = new bhattjiMedia();
                        MyMedia.Src = objOI.LinkClickUrlLegacy(objSalesRep.MediaSrc);
						MyMedia.MediaWidth = objSalesRep.MediaWidth;
						MyMedia.MediaHeight = objSalesRep.MediaHeight;
						MyMedia.MediaAlign = objSalesRep.MediaAlign;
						MyMedia.AltText = objSalesRep.Description;
                        MyMedia.NavigateUrl = objOI.LinkClickUrlLegacy(objSalesRep.NavURL);

						writer.Write(MyMedia.ToString());
					}

					writer.Write(objSalesRep.Details);

					writer.RenderEndTag();
					//</Div>
				}
				//objTabbedPage
				writer.RenderEndTag();
				//</Div>
			}
			//writer
		}
		//Render

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
	//ViewTabs

}
//bhattji.Modules.SalesReps
