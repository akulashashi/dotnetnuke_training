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
using System.Drawing;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke;
//using bhattji.Modules.XYZ70s.Business;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;

namespace bhattji.Modules.XYZ70s
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

    public abstract partial class ViewList : XYZ70ModuleBase
	{


		#region " Private Members "

		private OptionsInfo objOI;

		#endregion

		#region " Methods "

		private void InitEveryTime()
		{
			//Bind the ObjectDataSource everytime, even on Postback
			SetODS();
		}

		private void InitFirstTime()
        {
            hypFrom.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom);
            hypTo.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo);
            //txtFrom.Attributes.Add("OnClick", (DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom)));
            //txtTo.Attributes.Add("OnClick", (DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo)));

			divSearch.Visible = !objOI.HideSearch;
			hypEditCategory.Visible = IsEditable;
			if (hypEditCategory.Visible) hypEditCategory.NavigateUrl = EditUrl("EditType", "EditCat"); 

			SetGridView();

			BindCategories();
			//BindSearchData()
		}

		private void SetODS()
		{
			{
				odsXYZ70s.DataObjectTypeName = "bhattji.Modules.XYZ70s.XYZ70Info";
				odsXYZ70s.TypeName = "bhattji.Modules.XYZ70s.XYZ70sController";
                odsXYZ70s.SelectMethod = "GetXYZ70s";
				odsXYZ70s.DeleteMethod = "DeleteXYZ70";
			} //odsXYZ70s
		} //SetODS

		public void SetGridView()
		{
			{
				gdvViewList.PageSize = objOI.PagerSize;
				gdvViewList.AllowPaging = objOI.PagerSize > 0;
				gdvViewList.Columns[0].Visible = IsEditable;
				//Remove the First column if the User is not Admin

                if (!string.IsNullOrEmpty(objOI.GridCss)) gdvViewList.CssClass = objOI.GridCss;
                if (!string.IsNullOrEmpty(objOI.HeaderCss)) gdvViewList.HeaderStyle.CssClass = objOI.HeaderCss;
                if (!string.IsNullOrEmpty(objOI.RowCss)) gdvViewList.RowStyle.CssClass = objOI.RowCss;
                if (!string.IsNullOrEmpty(objOI.AltRowCss)) gdvViewList.AlternatingRowStyle.CssClass = objOI.AltRowCss;
                if (!string.IsNullOrEmpty(objOI.SelRowCss)) gdvViewList.SelectedRowStyle.CssClass = objOI.RowCss;
                if (!string.IsNullOrEmpty(objOI.EditRowCss)) gdvViewList.EditRowStyle.CssClass = objOI.EditRowCss;
                if (!string.IsNullOrEmpty(objOI.PagerCss)) gdvViewList.PagerStyle.CssClass = objOI.PagerCss;
                if (!string.IsNullOrEmpty(objOI.FooterCss)) gdvViewList.FooterStyle.CssClass = objOI.FooterCss;
                //if (!string.IsNullOrEmpty(objOI.BackColor))
                //{
                //    try {
                //        gdvViewList.RowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.BackColor);
                //    }
                //    catch {
                //    }
                //}
                //if (!string.IsNullOrEmpty(objOI.AltColor))
                //{
                //    try {
                //        gdvViewList.AlternatingRowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.AltColor);
                //    }
                //    catch {
                //    }
                //}

                //if (!string.IsNullOrEmpty(objOI.SelectedColor))
                //{
                //    try {
                //        gdvViewList.AlternatingRowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.SelectedColor);
                //    }
                //    catch {
                //    }
                //}
                //if (!string.IsNullOrEmpty(objOI.HeaderBackColor))
                //{
                //    try {
                //        gdvViewList.HeaderStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
                //        gdvViewList.FooterStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
                //    }
                //    catch {
                //    }
                //}
                //if (!string.IsNullOrEmpty(objOI.PagerBackColor))
                //{
                //    try {
                //        gdvViewList.PagerStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.PagerBackColor);
                //    }
                //    catch {
                //    }
                //}
			}
			//gdvViewList

		}

		public void BindCategories()
		{
			{
				ddlCategories.DataValueField = "ItemId";
				ddlCategories.DataTextField = "Category";
				ddlCategories.DataSource = (new CategoriesController()).GetAllCategories();
				ddlCategories.DataBind();

				//.Visible = .Items.Count > 1
				ddlCategories.Items.Insert(0, new ListItem(Localization.GetString("AllCategory", LocalResourceFile), "-1"));
			}
		}

		public void ResetViewStates()
		{
			ViewState.Remove("odsXYZ70s");
			ViewState.Remove("gdvViewList");
			odsXYZ70s.DataBind();
			gdvViewList.DataBind();
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

		private void odsXYZ70s_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
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

		private void gdvViewList_RowCreated(object sender, GridViewRowEventArgs e)
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
                else if (e.Row.RowType == DataControlRowType.DataRow && !string.IsNullOrEmpty((new OptionsInfo(ModuleId)).HighLightColor))
                {
                    //e.Row.Attributes.Add("onMouseOver", "this.className='MouseOverClass'");
                    //if (e.Row.RowState == DataControlRowState.Normal)
                    //    e.Row.Attributes.Add("onMouseOut", "this.className='ItemCssClass'");
                    //else
                    //    e.Row.Attributes.Add("onMouseOut", "this.className='AltItemCssClass'");

                    // when mouse is over the row, save original color to new attribute, and change it to highlight yellow color
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='" + (new OptionsInfo(ModuleId)).HighLightColor + "'");
                    // when mouse leaves the row, change the bg color to its original value    
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                }
			}
			catch (Exception exc) {
				//Module failed to RowCreated
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		private void gdvViewList_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try {
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					HyperLink hypEditItem = (HyperLink)e.Row.FindControl("hypEditItem");
					HyperLink hypThumb = (HyperLink)e.Row.FindControl("hypThumb");
					HyperLink hypTitle = (HyperLink)e.Row.FindControl("hypTitle");
					HyperLink hypRatings = (HyperLink)e.Row.FindControl("hypRatings");
					HyperLink hypPrint = (HyperLink)e.Row.FindControl("hypPrint");
					HyperLink hypMoreLink = (HyperLink)e.Row.FindControl("hypMoreLink");
					ImageButton imbDelete = (ImageButton)e.Row.FindControl("imbDelete");

                    //int _ItemId = Null.NullInteger; _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId));
                    int _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), Null.NullInteger));
                    //int _ModuleId = Null.NullInteger; _ModuleId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ModuleID"), _ModuleId));
                    int _ModuleId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ModuleID"), Null.NullInteger));
                    string _Title = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Title"));
					string _MediaSrc = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MediaSrc"));
					string _MediaSrc2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MediaSrc2"));
					string _NavURL = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NavURL"));
                    //bool _NewWindow = Null.NullBoolean; _NewWindow = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "NewWindow"), _NewWindow));
                    bool _NewWindow = Null.NullBoolean; _NewWindow = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "NewWindow"), Null.NullBoolean));
                    //bool _TrackClicks = Null.NullBoolean; _TrackClicks = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "TrackClicks"), _TrackClicks));
                    bool _TrackClicks = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "TrackClicks"), Null.NullBoolean));
                    //DateTime _DisplayDate = Null.NullDate; _DisplayDate = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DisplayDate"), _DisplayDate));
                    DateTime _DisplayDate = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DisplayDate"), Null.NullDate));
                    //int _RatingAverage = Null.NullInteger; _RatingAverage = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "RatingAverage"), _RatingAverage));
                    int _RatingAverage = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "RatingAverage"), Null.NullInteger));

					if ((hypEditItem != null))
					{
						{
							hypEditItem.Visible = IsEditable && objOI.IsItemEditable(_ModuleId);
							if (hypEditItem.Visible)
							{
								hypEditItem.NavigateUrl = EditUrl("ItemID", _ItemId.ToString());
								hypEditItem.ToolTip = Localization.GetString("Edit");
								hypEditItem.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypEditItem
					}


					if ((imbDelete != null))
					{
						{
							imbDelete.Visible = hypEditItem.Visible && objOI.DeleteFromGrid;
							if (imbDelete.Visible)
							{
								//.NavigateUrl = EditUrl("ItemID", _ItemId)
								imbDelete.ToolTip = "Delete";
								imbDelete.Attributes.Add("onmouseover", "window.status=this.title; return true");
								imbDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");
							}
						}
						//imbDelete
					}

					if ((hypThumb != null))
					{
						{
							hypThumb.Visible = true;
							//CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String) <> String.Empty 'Not objOI.ShowListingOnly
							if (hypThumb.Visible)
							{
                                hypThumb.ImageUrl = GetThumbImg((string)(string.IsNullOrEmpty(_MediaSrc) ? "" : objOI.LinkClickUrlLegacy(_MediaSrc)), (string)(string.IsNullOrEmpty(_MediaSrc2) ? "" : objOI.LinkClickUrlLegacy(_MediaSrc2)), Convert.ToInt16(string.IsNullOrEmpty(objOI.ThumbnailWidth) ? "32" : objOI.ThumbnailWidth));
								hypThumb.NavigateUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemDetails", "Item=XYZ70");
								hypThumb.ToolTip = _Title;
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
								//.Text = _Title
								hypTitle.Text = objOI.GetDatedTitle(_Title, _DisplayDate.ToShortDateString());
								hypTitle.NavigateUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemDetails", "Item=XYZ70");
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
								hypRatings.ImageUrl = ControlPath + "ratings/default/" + _RatingAverage.ToString() + ".gif";
								hypRatings.NavigateUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemRatings", "Item=XYZ70");
								//If objOI.RatingsInNewWindow Then
								hypRatings.Target = "_blank";
								//Open the Rating Window in New Window
								//End If 'objOI.RatingsInNewWindow Then
								hypRatings.ToolTip = "Ratings '" + _Title + "'";
								hypRatings.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypRatings
					}

					if ((hypPrint != null))
					{
						{
							hypPrint.Visible = true;
							if (hypPrint.Visible)
							{
								string PrintUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemDetails", "Item=XYZ70");

								if (PrintUrl.EndsWith(".aspx"))
								{
									hypPrint.NavigateUrl = PrintUrl + "?dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container";
								}
								else
								{
									hypPrint.NavigateUrl = PrintUrl + "&dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container";
								}

								hypPrint.Target = "_blank";
								hypPrint.ToolTip = Localization.GetString("Print", LocalResourceFile);
								hypPrint.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypPrint
					}

					if ((hypMoreLink != null))
					{
						{
							hypMoreLink.Visible = (!objOI.HideTextLink) && (!string.IsNullOrEmpty(_NavURL));
							if (hypMoreLink.Visible)
							{
								hypMoreLink.NavigateUrl = DotNetNuke.Common.Globals.LinkClick(_NavURL, TabId, ModuleId, _TrackClicks);
								if (_NewWindow)
								{
									hypMoreLink.Target = "_blank";
								}
								hypMoreLink.Attributes.Add("onmouseover", "window.status=this.title; return true");
							}
						}
						//hypMoreLink
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
            //odsXYZ70s.Selecting += new ObjectDataSourceSelectingEventHandler(odsXYZ70s_Selecting);
            //gdvViewList.RowCreated += new GridViewRowEventHandler(gdvViewList_RowCreated);
            //gdvViewList.RowDataBound += new GridViewRowEventHandler(gdvViewList_RowDataBound);
            //ddlCategories.SelectedIndexChanged += new EventHandler(ddlCategories_SelectedIndexChanged);
            //btnSearch.Click += new EventHandler(btnSearch_Click);
            ////this.Load += new EventHandler(this.Page_Load);
            odsXYZ70s.Selecting += odsXYZ70s_Selecting;
            gdvViewList.RowCreated += gdvViewList_RowCreated;
            gdvViewList.RowDataBound += gdvViewList_RowDataBound;
            ddlCategories.SelectedIndexChanged += ddlCategories_SelectedIndexChanged;
            btnSearch.Click += btnSearch_Click;
            //this.Load += Page_Load;            
        }

        #endregion


	} //ViewList

} //bhattji.Modules.XYZ70s
