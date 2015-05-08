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

using DotNetNuke.Services.Localization;
using System.Web.UI.WebControls;
using System;
using System.Drawing;
using System.ComponentModel;
using DotNetNuke.Services.Exceptions;
using System.Web.UI;
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
    public abstract partial class ViewThumbs : DotNetNuke.Entities.Modules.PortalModuleBase
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

			SetViewThumbs();

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

		public void SetViewThumbs()
		{
			{

				if (objOI.ThumbColumns > 0) lstViewThumbs.RepeatColumns = objOI.ThumbColumns; 

				if (objOI.BackColor != string.Empty)
				{
					try {
						lstViewThumbs.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.BackColor);
					}
					catch {
					}
				}


				if (objOI.HeaderBackColor != string.Empty)
				{
					try {
						lstViewThumbs.HeaderStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
						lstViewThumbs.FooterStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
					}
					catch {
					}
				}
			}
			//lstViewThumbs

		}

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

		public void ResetViewStates()
		{
			ViewState.Remove("odsSalesReps");
			ViewState.Remove("lstViewThumbs");
			odsSalesReps.DataBind();
			lstViewThumbs.DataBind();
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

		protected string GetMarquee()
		{
			return objOI.MarqueeStart;
		}

		protected string GetMarqueeEnd()
		{
			return objOI.MarqueeEnd;
		}

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

		private void lstViewThumbs_ItemDataBound(object sender, DataListItemEventArgs e)
		{
			try {
				HyperLink hypEditItem = (HyperLink)e.Item.FindControl("hypEditItem");
				HyperLink hypTitle = (HyperLink)e.Item.FindControl("hypTitle");
				PlaceHolder phtSalesRepDescription = (PlaceHolder)e.Item.FindControl("phtSalesRepDescription");
				HyperLink hypRatings = (HyperLink)e.Item.FindControl("hypRatings");
				HyperLink hypMoreLink = (HyperLink)e.Item.FindControl("hypMoreLink");

				if ((hypEditItem != null))
				{
					{
						hypEditItem.Visible = IsEditable;
						if (hypEditItem.Visible)
						{
							hypEditItem.NavigateUrl = EditUrl("ItemID", (string)DataBinder.Eval(e.Item.DataItem, "ItemID"));
							hypEditItem.Attributes.Add("onmouseover", "window.status=this.title; return true");
						}
					}
					//hypEditItem
				}

				if ((hypTitle != null))
				{
					{
						hypTitle.Visible = true;
						//Not objOI.ShowListingOnly
						if (hypTitle.Visible)
						{
							hypTitle.Text = (string)DataBinder.Eval(e.Item.DataItem, "Title");
							hypTitle.NavigateUrl = EditUrl("ItemID", (string)DataBinder.Eval(e.Item.DataItem, "ItemID"), "ItemDetails", "Item=SalesRep");
							//.CssClass = "SubHead"
							hypTitle.ToolTip = hypTitle.Text;
							hypTitle.Attributes.Add("onmouseover", "window.status=this.title; return true");
						}
					}
					//hypTitle
				}

				if ((phtSalesRepDescription != null))
				{
					{
						phtSalesRepDescription.Visible = ((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc") != string.Empty);
						if (phtSalesRepDescription.Visible)
						{
							bhattjiMedia hypThumb = new bhattjiMedia();
							if ((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc") != string.Empty)
							{
								hypThumb.Src = objOI.LinkClickUrlLegacy((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc"));
								//Select Case System.IO.Path.GetExtension(hypThumb.Src).ToLower()
								//    Case ".swf", ".flv"
								//        'ID = "bhattjiFlashPlayer" & ModuleId.ToString()
								//        hypThumb.MMType = "Flash"
								//        'FlashUrl = Src
								//        If objOI.ThumbHeight <> String.Empty Then
								//            hypThumb.MMHeight = objOI.ThumbHeight
								//        End If
								//    Case ".gif", ".jpg", ".jpeg", ".jpe"
								//        'ID = "bhattjiQuickTimePlayer" & ModuleId.ToString()
								//        hypThumb.MMType = "Image"
								//        If objOI.DynamicThumb Then
								//            hypThumb.Src = GetThumbSrc(hypThumb.Src)
								//        End If
								//        'VideoUrl = Src
								//    Case Else '".wmv"
								//        'ID = "bhattjiWindowsMediaPlayer" & ModuleId.ToString()
								//        hypThumb.MMType = "Video"
								//        'VideoUrl = Src
								//End Select
								switch (objOI.MediaType(hypThumb.Src).ToLower()) {
									case "image":
										if (objOI.DynamicThumb)
										{
											hypThumb.Src = GetThumbImg((string)((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc") != string.Empty ? objOI.LinkClickUrlLegacy((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc")) : ""), (string)((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc2") != string.Empty ? objOI.LinkClickUrlLegacy((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc2")) : ""));
										}
										else
										{
											if (objOI.ThumbWidth != string.Empty) hypThumb.MediaWidth = objOI.ThumbWidth; 
										}

										break;
									default:
										if (objOI.ThumbWidth != string.Empty) hypThumb.MediaWidth = objOI.ThumbWidth; 
										if (objOI.ThumbHeight != string.Empty) hypThumb.MediaWidth = objOI.ThumbHeight; 
										break;
								}
							}
							else
							{
								hypThumb.Src = GetThumbImg((string)((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc") != string.Empty ? objOI.LinkClickUrlLegacy((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc")) : ""), (string)((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc2") != string.Empty ? objOI.LinkClickUrlLegacy((string)DataBinder.Eval(e.Item.DataItem, "MediaSrc2")) : ""));
							}
							//hypThumb.MediaAlign = ImageAlign
							hypThumb.NavigateUrl = EditUrl("ItemID", (string)DataBinder.Eval(e.Item.DataItem, "ItemID"), "ItemDetails", "Item=SalesRep");
							hypThumb.AltText = (string)DataBinder.Eval(e.Item.DataItem, "Title");
							hypThumb.Transition = objOI.Transition;
							hypThumb.RattleImage = objOI.RattleImage;

							phtSalesRepDescription.Controls.Add(hypThumb);
						}
					}
					//phtSalesRepDescription
				}

				if ((hypRatings != null))
				{
					{
						hypRatings.Visible = objOI.ShowRatings;
						if (hypRatings.Visible)
						{
							hypRatings.ImageUrl = ModulePath + "ratings/default/" + (string)DataBinder.Eval(e.Item.DataItem, "RatingAverage") + ".gif";
							hypRatings.NavigateUrl = EditUrl("ItemID", (string)DataBinder.Eval(e.Item.DataItem, "ItemID"), "ItemRatings", "Item=SalesRep");
							//If objOI.RatingsInNewWindow Then
							hypRatings.Target = "_blank";
							//Open the Rating Window in New Window
							//End If 'objOI.RatingsInNewWindow Then
							hypRatings.ToolTip = "Ratings '" + (string)DataBinder.Eval(e.Item.DataItem, "Title") + "'";
							hypRatings.Attributes.Add("onmouseover", "window.status=this.title; return true");
						}
					}
					//hypRatings
				}


				if ((hypMoreLink != null))
				{
					{
						hypMoreLink.Visible = (!objOI.HideTextLink) & ((string)DataBinder.Eval(e.Item.DataItem, "NavURL") != string.Empty);
						if (hypMoreLink.Visible)
						{
							//.NavigateUrl = LinkClickUrlLegacy(CType(DataBinder.Eval(e.Item.DataItem, "NavURL"), String))
							hypMoreLink.NavigateUrl = DotNetNuke.Common.Globals.LinkClick((string)DataBinder.Eval(e.Item.DataItem, "NavURL"), TabId, ModuleId, (bool)DataBinder.Eval(e.Item.DataItem, "TrackClicks"));
							if ((bool)DataBinder.Eval(e.Item.DataItem, "NewWindow"))
							{
								hypMoreLink.Target = "_blank";
							}
							hypMoreLink.Attributes.Add("onmouseover", "window.status=this.title; return true");
						}
					}
					//hypMoreLink
				}
			}

			catch (Exception exc) {
				//Module failed to ItemDataBound
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		private void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnSearch_Click(sender, e);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			//BindSearchData()
			ResetViewStates();
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
            odsSalesReps.Selecting += new ObjectDataSourceSelectingEventHandler(odsSalesReps_Selecting);
            lstViewThumbs.ItemDataBound += new DataListItemEventHandler(lstViewThumbs_ItemDataBound);
            ddlCategories.SelectedIndexChanged += new EventHandler(ddlCategories_SelectedIndexChanged);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            //this.Load += new EventHandler(this.Page_Load);

        }

        #endregion

	}
	//ViewThumbs

}
//bhattji.Modules.SalesReps
