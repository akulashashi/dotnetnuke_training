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
using DotNetNuke.Services.Localization;
using System;
using System.Drawing;
using System.ComponentModel;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Common.Utilities;
using System.Web.UI;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Common;

namespace bhattji.Modules.XYZ60s
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
    public abstract partial class ViewGrid : XYZ60ModuleBase
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
				odsXYZ60s.DataObjectTypeName = "bhattji.Modules.XYZ60s.XYZ60Info";
				odsXYZ60s.TypeName = "bhattji.Modules.XYZ60s.XYZ60sController";
                odsXYZ60s.SelectMethod = "GetXYZ60s";
				odsXYZ60s.DeleteMethod = "DeleteXYZ60";
			} //odsXYZ60s
		} //SetODS

		public void SetGridView()
		{
			{
				gdvViewGrid.PageSize = objOI.PagerSize;
				gdvViewGrid.AllowPaging = objOI.PagerSize > 0;
				//.Columns(.Columns.Count - 1).Visible = IsEditable 'Remove the last column if the User is not Admin
				gdvViewGrid.Columns[0].Visible = IsEditable;
				//Remove the First column if the User is not Admin

                if (!string.IsNullOrEmpty(objOI.GridCss)) gdvViewGrid.CssClass = objOI.GridCss;
                if (!string.IsNullOrEmpty(objOI.HeaderCss)) gdvViewGrid.HeaderStyle.CssClass = objOI.HeaderCss;
                if (!string.IsNullOrEmpty(objOI.RowCss)) gdvViewGrid.RowStyle.CssClass = objOI.RowCss;
                if (!string.IsNullOrEmpty(objOI.AltRowCss)) gdvViewGrid.AlternatingRowStyle.CssClass = objOI.AltRowCss;
                if (!string.IsNullOrEmpty(objOI.SelRowCss)) gdvViewGrid.SelectedRowStyle.CssClass = objOI.RowCss;
                if (!string.IsNullOrEmpty(objOI.EditRowCss)) gdvViewGrid.EditRowStyle.CssClass = objOI.EditRowCss;
                if (!string.IsNullOrEmpty(objOI.PagerCss)) gdvViewGrid.PagerStyle.CssClass = objOI.PagerCss;
                if (!string.IsNullOrEmpty(objOI.FooterCss)) gdvViewGrid.FooterStyle.CssClass = objOI.FooterCss;
                //if (objOI.BackColor != string.Empty)
                //{
                //    try {
                //        gdvViewGrid.RowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.BackColor);
                //    }
                //    catch {
                //    }
                //}
                //if (objOI.AltColor != string.Empty)
                //{
                //    try {
                //        gdvViewGrid.AlternatingRowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.AltColor);
                //    }
                //    catch {
                //    }
                //}

                //if (objOI.HeaderBackColor != string.Empty)
                //{
                //    try {
                //        gdvViewGrid.HeaderStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
                //        gdvViewGrid.FooterStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
                //    }
                //    catch {
                //    }
                //}
                //if (objOI.PagerBackColor != string.Empty)
                //{
                //    try {
                //        gdvViewGrid.PagerStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.PagerBackColor);
                //    }
                //    catch {
                //    }
                //}
			} //gdvViewGrid

		}

		public void BindCategories()
		{
			{
				ddlCategories.DataValueField = "ItemId";
				ddlCategories.DataTextField = "Category";
                ddlCategories.DataSource = (new CategoriesController()).GetSearchedCategories();
				ddlCategories.DataBind();
				ddlCategories.Items.Insert(0, new ListItem(Localization.GetString("AllCategory", LocalResourceFile), "-1"));
			}
		}

		public void ResetViewStates()
		{
			ViewState.Remove("odsXYZ60s");
			ViewState.Remove("gdvViewGrid");
			odsXYZ60s.DataBind();
			gdvViewGrid.DataBind();
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
            return objOI.GetThumbUrl(MediaFile1, ControlPath + "img/Thumb.aspx", ControlPath + "img/NoImage.jpg", MediaFile2, Width);
        } //GetThumbImg 

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

		private void odsXYZ60s_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
		{
			e.InputParameters["SearchText"] = txtSearch.Text;
			e.InputParameters["SearchOn"] = rblSearchOn.SelectedValue;
			e.InputParameters["FromDate"] = txtFrom.Text;
			e.InputParameters["ToDate"] = txtTo.Text;

			e.InputParameters["StartsWith"] = (rblSearchType.SelectedIndex < 1).ToString();
			e.InputParameters["NoOfItems"] = objOI.NoOfItems.ToString();
            if (!string.IsNullOrEmpty(ddlCategories.SelectedValue))
                e.InputParameters["CategoryId"] = ddlCategories.SelectedValue;
            else
                e.InputParameters["CategoryId"] = "-1";

			e.InputParameters["ModuleId"] = ModuleId.ToString();
			e.InputParameters["PortalId"] = PortalId.ToString();
			e.InputParameters["ItemsScope"] = objOI.ItemsScope.ToString();
		}

		private void gdvViewGrid_RowCreated(object sender, GridViewRowEventArgs e)
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
						} //hypAddItem
					}
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // when mouse is over the row, save original color to new attribute, and change it to highlight yellow color
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='" + objOI.HighLightColor + "'");
                    // when mouse leaves the row, change the bg color to its original value    
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                }
			}
			catch (Exception exc) {
				//Module failed to RowCreated
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		private void gdvViewGrid_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try {
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					HyperLink hypEditItem = (HyperLink)e.Row.FindControl("hypEditItem");
					HyperLink hypTitle = (HyperLink)e.Row.FindControl("hypTitle");
					HyperLink hypRatings = (HyperLink)e.Row.FindControl("hypRatings");
					PlaceHolder phtXYZ60Description = (PlaceHolder)e.Row.FindControl("phtXYZ60Description");
					HyperLink hypMoreLink = (HyperLink)e.Row.FindControl("hypMoreLink");
					ImageButton imbDelete = (ImageButton)e.Row.FindControl("imbDelete");

                    int _ItemId = Null.NullInteger; _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId));
                    int _ModuleId = Null.NullInteger; _ModuleId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ModuleID"), _ModuleId));
					string _Title = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Title"));
					string _MediaSrc = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MediaSrc"));
					string _MediaAlign = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MediaAlign"));
					string _Description = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Description"));
					string _MediaSrc2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MediaSrc2"));
					string _NavURL = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NavURL"));
                    bool _NewWindow = Null.NullBoolean; _NewWindow = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "NewWindow"), _NewWindow));
                    bool _TrackClicks = Null.NullBoolean; _TrackClicks = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "TrackClicks"), _TrackClicks));
                    DateTime _DisplayDate = Null.NullDate; _DisplayDate = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DisplayDate"), _DisplayDate));
                    int _RatingAverage = Null.NullInteger; _RatingAverage = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "RatingAverage"), _RatingAverage));

					if ((hypEditItem != null))
					{
						{
							hypEditItem.Visible = IsEditable;
							if (hypEditItem.Visible)
							{
								hypEditItem.NavigateUrl = EditUrl("ItemID", _ItemId.ToString());
								hypEditItem.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						} //hypEditItem
					}

					if ((hypTitle != null))
					{
						{
							hypTitle.Visible = true;
							//Not objOI.ShowListingOnly
							if (hypTitle.Visible)
							{
								//.Text = _Title
								hypTitle.Text = objOI.GetDatedTitle(_Title, _DisplayDate.ToShortDateString());
								hypTitle.NavigateUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemDetails", "Item=XYZ60");
								//.CssClass = "SubHead"
								hypTitle.ToolTip = hypTitle.Text;
								hypTitle.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						} //hypTitle
					}

					if ((hypRatings != null))
					{
						{
							hypRatings.Visible = objOI.ShowRatings;
							if (hypRatings.Visible)
							{
								hypRatings.ImageUrl = ControlPath + "ratings/default/" + _RatingAverage.ToString() + ".gif";
								hypRatings.NavigateUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemRatings", "Item=XYZ60");
								hypRatings.Target = "_blank";
								hypRatings.ToolTip = "Ratings '" + _Title + "'";
								hypRatings.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						} //hypRatings
					}

					string ImageAlign;
					switch (objOI.ImagePosition.ToLower()) {
						case "zr":
							if (e.Row.RowState == DataControlRowState.Normal)
							{
								ImageAlign = "Right";
							}
							else
							{
								ImageAlign = "Left";
							}

							break;
						case "zl":
							if (e.Row.RowState == DataControlRowState.Normal)
							{
								ImageAlign = "Left";
							}
							else
							{
								ImageAlign = "Right";
							}

							break;
						case "ar":
							ImageAlign = "Right";
							break;
						case "al":
							ImageAlign = "Left";
							break;
						default:
							ImageAlign = _MediaAlign;
							break;
					}

					if ((phtXYZ60Description != null))
					{
						{
							phtXYZ60Description.Visible = true;
							if (phtXYZ60Description.Visible)
							{
								bhattjiMedia hypThumb = new bhattjiMedia();
								if (_MediaSrc != string.Empty)
								{
									hypThumb.Src = objOI.LinkClickUrlLegacy(_MediaSrc);

									switch (objOI.MediaType(hypThumb.Src).ToLower()) {
										case "image":
											if (objOI.DynamicThumb)											
												hypThumb.Src = GetThumbImg((string)(string.IsNullOrEmpty(_MediaSrc) ? "": objOI.LinkClickUrlLegacy(_MediaSrc)), (string)(string.IsNullOrEmpty(_MediaSrc2)?"": objOI.LinkClickUrlLegacy(_MediaSrc2)));										
											else											
												if (!string.IsNullOrEmpty(objOI.ThumbWidth)) hypThumb.MediaWidth = objOI.ThumbWidth; 										

											break;
										default:
											if (!string.IsNullOrEmpty(objOI.ThumbWidth)) hypThumb.MediaWidth = objOI.ThumbWidth; 
											if (!string.IsNullOrEmpty(objOI.ThumbHeight)) hypThumb.MediaWidth = objOI.ThumbHeight; 
											break;
									}
								}
								else
								{
									hypThumb.Src = GetThumbImg((string)(_MediaSrc != string.Empty ? objOI.LinkClickUrlLegacy(_MediaSrc) : ""), (string)(_MediaSrc2 != string.Empty ? objOI.LinkClickUrlLegacy(_MediaSrc2) : ""));
								}
								hypThumb.MediaAlign = ImageAlign;
								hypThumb.NavigateUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemDetails", "Item=XYZ60");
								hypThumb.AltText = _Title;
								hypThumb.Transition = objOI.Transition;
								hypThumb.RattleImage = objOI.RattleImage;

								phtXYZ60Description.Controls.Add(hypThumb);

								Literal ltrXYZ60Description = new Literal();
								ltrXYZ60Description.Text = Server.HtmlDecode(_Description);

								phtXYZ60Description.Controls.Add(ltrXYZ60Description);
							}
						} //phtXYZ60Description
					}

					if ((hypMoreLink != null))
					{
						{
							hypMoreLink.Visible = (!objOI.HideTextLink) & (_NavURL != string.Empty);
							if (hypMoreLink.Visible)
							{
								hypMoreLink.NavigateUrl = Globals.LinkClick(_NavURL, TabId, ModuleId, _TrackClicks);
								if ((bool)DataBinder.Eval(e.Row.DataItem, "NewWindow"))
								{
									hypMoreLink.Target = "_blank";
								}
								hypMoreLink.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						} //hypMoreLink
					}

					if ((imbDelete != null))
					{
						{
							imbDelete.Visible = IsEditable & objOI.DeleteFromGrid;
							if (imbDelete.Visible)
							{
								imbDelete.ToolTip = "Delete";
								imbDelete.Attributes.Add("onmouseover", "window.status=this.title; return true");
								imbDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");
							}
						} //imbDelete
					}

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
            //odsXYZ60s.Selecting += new ObjectDataSourceSelectingEventHandler(odsXYZ60s_Selecting);
            //gdvViewGrid.RowCreated += new GridViewRowEventHandler(gdvViewGrid_RowCreated);
            //gdvViewGrid.RowDataBound += new GridViewRowEventHandler(gdvViewGrid_RowDataBound);
            //ddlCategories.SelectedIndexChanged += new EventHandler(ddlCategories_SelectedIndexChanged);
            //btnSearch.Click += new EventHandler(btnSearch_Click);
            ////this.Load += new EventHandler(this.Page_Load);
            odsXYZ60s.Selecting += odsXYZ60s_Selecting;
            gdvViewGrid.RowCreated += gdvViewGrid_RowCreated;
            gdvViewGrid.RowDataBound += gdvViewGrid_RowDataBound;
            ddlCategories.SelectedIndexChanged +=ddlCategories_SelectedIndexChanged;
            btnSearch.Click += btnSearch_Click;
            //this.Load += Page_Load;
        }

        #endregion


	} //ViewGrid

} //bhattji.Modules.XYZ60s
