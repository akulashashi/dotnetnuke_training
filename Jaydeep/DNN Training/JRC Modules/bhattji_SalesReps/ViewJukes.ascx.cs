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
using DotNetNuke;
using bhattji.Modules.SalesReps.Business;
using System.Web.UI;
using DotNetNuke.Services.Localization;
using System;
using System.Drawing;
using System.ComponentModel;
using DotNetNuke.Services.Exceptions;

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
	///

    public abstract partial class ViewJukes : DotNetNuke.Entities.Modules.PortalModuleBase
	{


		#region " Private Members "

		private OptionsInfo objOI;

		#endregion

		#region " Methods "

		private void InitEveryTime()
		{
			//this needs to execute always, even on Postback, to the client script code is registred in InvokePopupCal
			hypCalandarFromDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom);
			hypCalandarToDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo);

			//Bind the ObjectDataSource everytime, even on Postback
			SetODS();
		}

		private void InitFirstTime()
		{
			tblSearch.Visible = !objOI.HideSearch;
			hypEditCategory.Visible = IsEditable;
			if (hypEditCategory.Visible) hypEditCategory.NavigateUrl = EditUrl("EditType", "EditCat"); 

			SetGridView();

			BindCategories();
			//BindSearchData()
		}

		private void SetODS()
		{
			{
				odsSalesReps.DataObjectTypeName = "bhattji.Modules.SalesReps.Business.SalesRepInfo";
				odsSalesReps.TypeName = "bhattji.Modules.SalesReps.Business.SalesRepsController";
                odsSalesReps.SelectMethod = "GetSalesReps()";
				odsSalesReps.DeleteMethod = "DeleteSalesRep()";
			}
			//odsSalesReps
		}
		//SetODS

		public void SetGridView()
		{
			{
				gdvViewJukes.PageSize = objOI.PagerSize;
				gdvViewJukes.AllowPaging = objOI.PagerSize > 0;
				//.Columns(.Columns.Count - 1).Visible = IsEditable 'Remove the last column if the User is not Admin
				gdvViewJukes.Columns[0].Visible = IsEditable;
				//Remove the First column if the User is not Admin

				if (objOI.BackColor != string.Empty)
				{
					try {
						gdvViewJukes.RowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.BackColor);
					}
					catch {
					}
				}
				if (objOI.AltColor != string.Empty)
				{
					try {
						gdvViewJukes.AlternatingRowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.AltColor);
					}
					catch {
					}
				}

				if (objOI.HeaderBackColor != string.Empty)
				{
					try {
						gdvViewJukes.HeaderStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
						gdvViewJukes.FooterStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
					}
					catch {
					}
				}
				if (objOI.PagerBackColor != string.Empty)
				{
					try {
						gdvViewJukes.PagerStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.PagerBackColor);
					}
					catch {
					}
				}
			}
			//gdvViewJukes

		}
		//SetGridView

		public void BindCategories()
		{
			{
				ddlCategories.DataValueField = "ItemId";
				ddlCategories.DataTextField = "Category";
				ddlCategories.DataSource = (new Business.CategoriesController()).GetAllCategories();
				ddlCategories.DataBind();

				//.Visible = .Items.Count > 1
				ddlCategories.Items.Insert(0, new ListItem(Localization.GetString("AllCategory", LocalResourceFile), "-1"));
			}
		}
		//BindCategories

		public void ResetViewStates()
		{
			ViewState.Remove("odsSalesReps");
			ViewState.Remove("gdvViewJukes");
			odsSalesReps.DataBind();
			gdvViewJukes.DataBind();
		}

        public string GetThumbImg(string MediaFile1)
        {
            return GetThumbImg(MediaFile1, "", -1);
        }
        public string GetThumbImg(string MediaFile1, string MediaFile2)
        {
            return GetThumbImg(MediaFile1, MediaFile2, -1);
        }
        public string GetThumbImg(string MediaFile1, string MediaFile2, int Width)
        {
            return objOI.GetThumbUrl(MediaFile1, ModulePath + "img/Thumb.aspx", ModulePath + "img/NoImage.jpg", MediaFile2, Width);
        }
        //GetThumbImg 

		//Function LinkClickUrlLegacy(ByVal Link As String) As String
		//    Dim strLink As String = Link

		//    Select Case GetURLType(strLink)
		//        Case DotNetNuke.Entities.Tabs.TabType.Tab  'TabType.Tab
		//            strLink = DotNetNuke.Common.Globals.ApplicationPath & "/" & glbDefaultPage & "?tabid=" & Link
		//        Case DotNetNuke.Entities.Tabs.TabType.File 'TabType.File
		//            Dim _portalSettings As DotNetNuke.Entities.Portals.PortalSettings = DotNetNuke.Entities.Portals.PortalController.GetCurrentPortalSettings
		//            strLink = _portalSettings.HomeDirectory & Link
		//    End Select

		//    Return strLink
		//End Function 'LinkClickUrlLegacy

		//Function GetThumbSrc(ByVal FileName As String, Optional ByVal Width As Integer = -1) As String
		//    Dim W As Integer = Width
		//    If W < 0 Then
		//        Try
		//            W = Integer.Parse(objOI.ThumbWidth)
		//        Catch
		//            'W = 32 'The default width specified in the Thumb.aspx file will be used
		//        End Try
		//    End If

		//    Dim strFileName As String '= FileName
		//    If FileName.StartsWith("http") Then
		//        strFileName = FileName
		//    Else
		//        strFileName = HttpContext.Current.Server.MapPath(FileName) 'HttpServerUtility.MapPath(FileName) ' Server.MapPath(FileName)
		//    End If

		//    If W < 0 Then
		//        Return ModulePath & "img/Thumb.aspx?filename=" & strFileName
		//    Else
		//        Return ModulePath & "img/Thumb.aspx?width=" & W.ToString() & "&filename=" & strFileName
		//    End If

		//End Function 'GetThumbSrc

		//Function MediaType(ByVal MediaFilename As String) As String
		//    Select Case System.IO.Path.GetExtension(MediaFilename).ToLower()
		//        Case ".gif", ".jpg", ".jpeg", ".jpe"
		//            Return "Image"
		//        Case ".swf"
		//            Return "Flash"
		//        Case ".wmv", ".mpeg", ".mpg", ".mov"
		//            Return "Movie"
		//        Case Else
		//            Return "Unknown"
		//    End Select
		//End Function

		//Function IsImageFile(ByVal Filename As String) As Boolean
		//    Return MediaType(Filename).ToLower() = "image"
		//End Function

		//Function GetThumbUrl(ByVal MediaFile1 As String, Optional ByVal MediaFile2 As String = "", Optional ByVal Width As Integer = -1) As String
		//    If (MediaFile1 <> "") AndAlso (IsImageFile(MediaFile1)) Then
		//        Return GetThumbSrc(MediaFile1, Width)
		//    ElseIf (MediaFile2 <> "") AndAlso (IsImageFile(MediaFile2)) Then
		//        Return GetThumbSrc(MediaFile2, Width)
		//    Else
		//        Return GetThumbSrc(ModulePath & "img/NoImage.jpg", Width)
		//    End If
		//End Function

		protected string GetMarquee()
		{
			return objOI.MarqueeStart;
		}
		//GetMarquee

		protected string GetMarqueeEnd()
		{
			return objOI.MarqueeEnd;
		}
		//GetMarqueeEnd

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
		///
		private void Page_Load(object sender, EventArgs e)
		{
			try {
				//Always get the Options Object First
				objOI = new OptionsInfo(ModuleId);
				//This is must since it is being used in RowBound Method

				InitEveryTime();

				if (!Page.IsPostBack)
				{
					InitFirstTime();
				}
			}

			catch (Exception exc) {
				//Module failed to load
				Exceptions.ProcessModuleLoadException(this, exc);
			}

		}

		private void odsSalesReps_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
		{
			e.InputParameters["SearchText"] = txtSearch.Text;
			e.InputParameters["SearchOn"] = rblSearchOn.SelectedValue;
			e.InputParameters["FromDate"] = txtFrom.Text;
			e.InputParameters["ToDate"] = txtTo.Text;

			e.InputParameters["StartsWith"] = (rblSearchType.SelectedIndex < 1).ToString();
			e.InputParameters["NoOfItems"] = objOI.NoOfItems.ToString();
			if (((ddlCategories.SelectedValue != null)) && (ddlCategories.SelectedValue != ""))
			{
				e.InputParameters["CategoryId"] = ddlCategories.SelectedValue;
			}
			else
			{
				e.InputParameters["CategoryId"] = "-1";
			}

			e.InputParameters["ModuleId"] = ModuleId.ToString();
			e.InputParameters["PortalId"] = PortalId.ToString();
			e.InputParameters["ItemsScope"] = objOI.ItemsScope.ToString();
		}

		private void gdvViewJukes_RowCreated(object sender, GridViewRowEventArgs e)
		{
			try {
				if (e.Row.RowType == DataControlRowType.Header)
				{
					HyperLink hypAddItem = (HyperLink)e.Row.FindControl("hypAddItem");
					if ((hypAddItem != null))
					{
						{
							hypAddItem.Visible = IsEditable;
							if (hypAddItem.Visible)
							{
								hypAddItem.NavigateUrl = EditUrl();
								hypAddItem.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypAddItem
					}
				}
			}
			catch (Exception exc) {
				//Module failed to RowCreated
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		private void gdvViewJukes_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try {
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					HyperLink hypEditItem = (HyperLink)e.Row.FindControl("hypEditItem");
					HyperLink hypThumb = (HyperLink)e.Row.FindControl("hypThumb");
					HyperLink hypTitle = (HyperLink)e.Row.FindControl("hypTitle");
					HyperLink hypRatings = (HyperLink)e.Row.FindControl("hypRatings");
					HyperLink hypMoreLink = (HyperLink)e.Row.FindControl("hypMoreLink");
					ImageButton imbDelete = (ImageButton)e.Row.FindControl("imbDelete");


					if ((hypEditItem != null))
					{
						{
							hypEditItem.Visible = IsEditable;
							if (hypEditItem.Visible)
							{
								hypEditItem.NavigateUrl = EditUrl("ItemID", (string)DataBinder.Eval(e.Row.DataItem, "ItemID"));
								hypEditItem.ToolTip = Localization.GetString("Edit");
								hypEditItem.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypEditItem
					}


					if ((hypThumb != null))
					{
						{
							hypThumb.Visible = true;
							//CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String) <> String.Empty 'Not objOI.ShowListingOnly
							if (hypThumb.Visible)
							{
								//.ImageUrl = GetThumbSrc(LinkClickUrlLegacy(CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String)))
								//Dim strImageFilename As String = ModulePath & "img/NoImage.jpg"
								//If CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String) <> String.Empty Then
								//    strImageFilename = LinkClickUrlLegacy(CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String))
								//    Select Case System.IO.Path.GetExtension(strImageFilename).ToLower()
								//        Case ".jpg", ".jpe", ".jpeg", ".gif"
								//        Case Else
								//            strImageFilename = ModulePath & "img/NoImage.jpg"
								//            If CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc2"), String) <> String.Empty Then
								//                strImageFilename = LinkClickUrlLegacy(CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc2"), String))
								//                Select Case System.IO.Path.GetExtension(strImageFilename).ToLower()
								//                    Case ".jpg", ".jpe", ".jpeg", ".gif"
								//                    Case Else
								//                        strImageFilename = ModulePath & "img/NoImage.jpg"
								//                End Select
								//            End If
								//    End Select
								//    'Else
								//    '    strImageFilename = ModulePath & "NoImage.jpg"
								//End If
								//.ImageUrl = GetThumbSrc(strImageFilename)
								hypThumb.ImageUrl = GetThumbImg((string)((string)DataBinder.Eval(e.Row.DataItem, "MediaSrc") != string.Empty ? objOI.LinkClickUrlLegacy((string)DataBinder.Eval(e.Row.DataItem, "MediaSrc")) : ""), (string)((string)DataBinder.Eval(e.Row.DataItem, "MediaSrc2") != string.Empty ? objOI.LinkClickUrlLegacy((string)DataBinder.Eval(e.Row.DataItem, "MediaSrc2")) : ""));
								//If (CType(DataBinder.Eval(e.Item.DataItem, "MediaSrc"), String) <> String.Empty) And (System.IO.Path.GetExtension()) Then
								//    .ImageUrl = GetThumbSrc(LinkClickUrlLegacy(CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String)))
								//Else
								//    .ImageUrl = GetThumbSrc(ModulePath & "NoImage.jpg")
								//End If
								hypThumb.NavigateUrl = EditUrl("ItemID", (string)DataBinder.Eval(e.Row.DataItem, "ItemID"), "ItemDetails", "Item=SalesRep");
								//.CssClass = "SubHead"
								hypThumb.ToolTip = (string)DataBinder.Eval(e.Row.DataItem, "Title");
								hypThumb.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypThumb
					}

					if ((hypTitle != null))
					{
						{
							hypTitle.Visible = true;
							//Not objOI.ShowListingOnly
							if (hypTitle.Visible)
							{
								//.Text = CType(DataBinder.Eval(e.Row.DataItem, "Title"), String)
								hypTitle.Text = objOI.GetDatedTitle((string)DataBinder.Eval(e.Row.DataItem, "Title"), ((DateTime)DataBinder.Eval(e.Row.DataItem, "DisplayDate")).ToShortDateString());
								hypTitle.NavigateUrl = EditUrl("ItemID", (string)DataBinder.Eval(e.Row.DataItem, "ItemID"), "ItemDetails", "Item=SalesRep");
								//.CssClass = "SubHead"
								hypTitle.ToolTip = hypTitle.Text;
								hypTitle.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypTitle
					}

					if ((hypRatings != null))
					{
						{
							hypRatings.Visible = objOI.ShowRatings;
							if (hypRatings.Visible)
							{
								hypRatings.ImageUrl = ModulePath + "ratings/default/" + (string)DataBinder.Eval(e.Row.DataItem, "RatingAverage") + ".gif";
								hypRatings.NavigateUrl = EditUrl("ItemID", (string)DataBinder.Eval(e.Row.DataItem, "ItemID"), "ItemRatings", "Item=SalesRep");
								//If objOI.RatingsInNewWindow Then
								hypRatings.Target = "_blank";
								//Open the Rating Window in New Window
								//End If 'objOI.RatingsInNewWindow Then
								hypRatings.ToolTip = "Ratings '" + (string)DataBinder.Eval(e.Row.DataItem, "Title") + "'";
								hypRatings.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypRatings
					}

					if ((hypMoreLink != null))
					{
						{
							hypMoreLink.Visible = (!objOI.HideTextLink) & ((string)DataBinder.Eval(e.Row.DataItem, "NavURL") != string.Empty);
							if (hypMoreLink.Visible)
							{
								//.NavigateUrl = LinkClickUrlLegacy(CType(DataBinder.Eval(e.Row.DataItem, "NavURL"), String))
								hypMoreLink.NavigateUrl = DotNetNuke.Common.Globals.LinkClick((string)DataBinder.Eval(e.Row.DataItem, "NavURL"), TabId, ModuleId, (bool)DataBinder.Eval(e.Row.DataItem, "TrackClicks"));
								if ((bool)DataBinder.Eval(e.Row.DataItem, "NewWindow"))
								{
									hypMoreLink.Target = "_blank";
								}
								hypMoreLink.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypMoreLink
					}

					if ((imbDelete != null))
					{
						{
							imbDelete.Visible = IsEditable & objOI.DeleteFromGrid;
							if (imbDelete.Visible)
							{
								//.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
								imbDelete.ToolTip = "Delete";
								imbDelete.Attributes.Add("onmouseover", "window.status=this.title; return true");
								imbDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");
							}
						}
						//imbDelete
					}


				}
			}
			catch (Exception exc) {
				//Module failed to RowDataBound
				Exceptions.ProcessModuleLoadException(this, exc);
			}

		}

		private void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
		{
			//imbSearch_Click(sender, New System.Web.UI.ImageClickEventArgs(0, 0))
			btnSearch_Click(sender, e);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			//BindSearchData()
			ResetViewStates();
		}

		//Private Sub imbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearch.Click
		//    ResetViewStates()
		//End Sub

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
            odsSalesReps.Selecting += new ObjectDataSourceSelectingEventHandler(odsSalesReps_Selecting);
            gdvViewJukes.RowCreated += new GridViewRowEventHandler(gdvViewJukes_RowCreated);
            gdvViewJukes.RowDataBound += new GridViewRowEventHandler(gdvViewJukes_RowDataBound);
            ddlCategories.SelectedIndexChanged += new EventHandler(ddlCategories_SelectedIndexChanged);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            //this.Load += new EventHandler(this.Page_Load);

        }

        #endregion


	}
	//ViewJukes

}
//bhattji.Modules.SalesReps
