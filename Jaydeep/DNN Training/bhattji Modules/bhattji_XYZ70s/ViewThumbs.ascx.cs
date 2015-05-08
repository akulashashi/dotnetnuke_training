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
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using DotNetNuke.Services.Exceptions;
using System.Web.UI;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using System.Data;
//using bhattji.Modules.XYZ70s.Business;

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
    public abstract partial class ViewThumbs : XYZ70ModuleBase
	{
       
		#region " Private Members "

		private OptionsInfo objOI;       
        protected System.Web.UI.WebControls.Repeater Repeater1;
        //protected SiteUtils.CollectionPager CollectionPager1;

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
            
			BindCategories();
			SetViewThumbs();

            BindListXYZ70s();
			//BindSearchData()
		}

		//private DataSet SetODS()
            private void SetODS()
		{
			{
				odsXYZ70s.DataObjectTypeName = "bhattji.Modules.XYZ70s.XYZ70Info";
				odsXYZ70s.TypeName = "bhattji.Modules.XYZ70s.XYZ70sController";
                odsXYZ70s.SelectMethod = "GetXYZ70s";
				odsXYZ70s.DeleteMethod = "DeleteXYZ70";
			}
			//odsXYZ70s
		}
		//SetODS

		public void SetViewThumbs()
		{
			{

                if (objOI.ThumbColumns > 0 && objOI.ThumbRows > 0) lstViewThumbs.RepeatColumns = objOI.ThumbColumns;

                if (!string.IsNullOrEmpty(objOI.GridCss)) lstViewThumbs.CssClass = objOI.GridCss;
                if (!string.IsNullOrEmpty(objOI.HeaderCss)) lstViewThumbs.HeaderStyle.CssClass = objOI.HeaderCss;
                if (!string.IsNullOrEmpty(objOI.RowCss)) lstViewThumbs.ItemStyle.CssClass = objOI.RowCss;
                if (!string.IsNullOrEmpty(objOI.AltRowCss)) lstViewThumbs.AlternatingItemStyle.CssClass = objOI.AltRowCss;
                if (!string.IsNullOrEmpty(objOI.SelRowCss)) lstViewThumbs.SelectedItemStyle.CssClass = objOI.RowCss;
                if (!string.IsNullOrEmpty(objOI.EditRowCss)) lstViewThumbs.EditItemStyle.CssClass = objOI.EditRowCss;
                if (!string.IsNullOrEmpty(objOI.FooterCss)) lstViewThumbs.FooterStyle.CssClass = objOI.FooterCss;
                //if (objOI.BackColor != string.Empty)
                //{
                //    try {
                //        lstViewThumbs.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.BackColor);
                //    }
                //    catch {
                //    }
                //}
                //if (objOI.HeaderBackColor != string.Empty)
                //{
                //    try {
                //        lstViewThumbs.HeaderStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
                //        lstViewThumbs.FooterStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
                //    }
                //    catch {
                //    }
                //}
			}
			//lstViewThumbs

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
			ViewState.Remove("lstViewThumbs");
			odsXYZ70s.DataBind();
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

        //public Repeater PublicRepeaterInUC
        //{
        //    get { return RepeaterInUC; }
        //    set { RepeaterInUC = value; }
        //}

        private void BindListXYZ70s()
        {
            int PageSize = objOI.NoOfThumb;//objOI.ThumbColumns * objOI.ThumbRows;//objOI.NoOfItems; //2; //ViewState("pageSize") 
            int _CurrentPage = 1;
            if (string.IsNullOrEmpty(Request.QueryString["currentpage"]))
                _CurrentPage =  1; 
            else
                _CurrentPage =Int32.Parse(Request.QueryString["currentpage"]);  

            //XYZ70sController objXYZ70s = new XYZ70sController();
            //List<XYZ70Info> lotXYZ70s = CBO.FillCollection<XYZ70Info>(objXYZ70s.GetAllXYZ70s());//(ModuleId);

            int CategoryId;
            try { CategoryId = Convert.ToInt16(ddlCategories.SelectedValue); }
            catch { CategoryId = -1; }

            //string SearchOn = rblSearchOn.SelectedValue != null ? rblSearchOn.SelectedValue : "Any";
            //List<XYZ70Info> lotXYZ70s = CBO.FillCollection<XYZ70Info>((new XYZ70sController()).GetXYZ70Commons(txtSearch.Text));//(ModuleId);

            List<XYZ70Info> lotXYZ70s = CBO.FillCollection<XYZ70Info>((new XYZ70sController()).GetXYZ70Commons(txtSearch.Text, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 1), PageSize * objOI.NoOfPages, txtFrom.Text, txtTo.Text, CategoryId, ModuleId, PortalId, objOI.ItemsScope));//(ModuleId);
            
            PagedDataSource objPagedDataSource = new PagedDataSource();
            objPagedDataSource.DataSource = lotXYZ70s;

            if (PageSize > 0)
            {
                objPagedDataSource.PageSize = PageSize;
                objPagedDataSource.CurrentPageIndex = _CurrentPage - 1;
                objPagedDataSource.AllowPaging = true;
            }

            //if (PageSize == 0 || lotXYZ70s.Count <= PageSize)
            //{
            //    PagingControl1.Visible = false;
            //}
            //else
            //{
            //    PagingControl1.Visible = true;
            //    {
            //        PagingControl1.TotalRecords = lotXYZ70s.Count;
            //        PagingControl1.PageSize = PageSize;
            //        PagingControl1.CurrentPage = _CurrentPage;
            //        PagingControl1.TabID = TabId;
            //    }
            //}
            PagingControl1.Visible = (PageSize > 0 && lotXYZ70s.Count > PageSize);
            if (PagingControl1.Visible) {
                    PagingControl1.TotalRecords = lotXYZ70s.Count;
                    PagingControl1.PageSize = PageSize;
                    PagingControl1.CurrentPage = _CurrentPage;
                    PagingControl1.TabID = TabId;
            }

            lstViewThumbs.DataSource = objPagedDataSource;
            lstViewThumbs.DataBind();
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
            try
            {
                HyperLink hypEditItem = (HyperLink)e.Item.FindControl("hypEditItem");
                HyperLink hypTitle = (HyperLink)e.Item.FindControl("hypTitle");
                PlaceHolder phtXYZ70Description = (PlaceHolder)e.Item.FindControl("phtXYZ70Description");
                HyperLink hypRatings = (HyperLink)e.Item.FindControl("hypRatings");
                HyperLink hypMoreLink = (HyperLink)e.Item.FindControl("hypMoreLink");

                int _ItemId = Null.NullInteger; _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Item.DataItem, "ItemID"), _ItemId));
                int _ModuleId = Null.NullInteger; _ModuleId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Item.DataItem, "ModuleID"), _ModuleId));
                string _Title = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Title"));
                string _MediaSrc = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "MediaSrc"));
                string _MediaSrc2 = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "MediaSrc2"));
                string _NavURL = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "NavURL"));
                bool _NewWindow = Null.NullBoolean; _NewWindow = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Item.DataItem, "NewWindow"), _NewWindow));
                bool _TrackClicks = Null.NullBoolean; _TrackClicks = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Item.DataItem, "TrackClicks"), _TrackClicks));
                DateTime _DisplayDate = Null.NullDate; _DisplayDate = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Item.DataItem, "DisplayDate"), _DisplayDate));
                int _RatingAverage = Null.NullInteger; _RatingAverage = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Item.DataItem, "RatingAverage"), _RatingAverage));

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


                if ((hypTitle != null))
                {
                    {
                        hypTitle.Visible = true;
                        //Not objOI.ShowListingOnly
                        if (hypTitle.Visible)
                        {
                            //.Text = _Title
                            hypTitle.Text = objOI.GetDatedTitle(_Title, _DisplayDate.ToShortDateString());
                            hypTitle.NavigateUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemDetails", "dnnprintmode=true");
                            //.CssClass = "SubHead"
                            hypTitle.ToolTip = hypTitle.Text;
                            hypTitle.Attributes.Add("onmouseover", "window.status=this.title; return true");
                        }
                    }
                    //hypTitle
                }

                if ((phtXYZ70Description != null))
                {
                    {
                        phtXYZ70Description.Visible = (_MediaSrc != string.Empty);
                        if (phtXYZ70Description.Visible)
                        {
                            bhattjiMedia hypThumb = new bhattjiMedia();
                            if (_MediaSrc != string.Empty)
                            {
                                hypThumb.Src = objOI.LinkClickUrlLegacy(_MediaSrc);
                              switch (objOI.MediaType(hypThumb.Src).ToLower())
                                {
                                    case "image":
                                        if (objOI.DynamicThumb)
                                        {
                                            hypThumb.Src = GetThumbImg((string)(_MediaSrc != string.Empty ? objOI.LinkClickUrlLegacy(_MediaSrc) : ""), (string)(_MediaSrc2 != string.Empty ? objOI.LinkClickUrlLegacy(_MediaSrc2) : ""));
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
                                hypThumb.Src = GetThumbImg((string)(_MediaSrc != string.Empty ? objOI.LinkClickUrlLegacy(_MediaSrc) : ""), (string)(_MediaSrc2 != string.Empty ? objOI.LinkClickUrlLegacy(_MediaSrc2) : ""));
                            }
                            hypThumb.NavigateUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemDetails", "dnnprintmode=true");
                            hypThumb.AltText = _Title;
                            hypThumb.Transition = objOI.Transition;
                            hypThumb.RattleImage = objOI.RattleImage;

                            phtXYZ70Description.Controls.Add(hypThumb);
                        }
                    }
                    //phtXYZ70Description
                }

                if ((hypRatings != null))
                {
                    {
                        hypRatings.Visible = objOI.ShowRatings;
                        if (hypRatings.Visible)
                        {
                            hypRatings.ImageUrl = ControlPath + "ratings/default/" + _RatingAverage.ToString() + ".gif";
                            hypRatings.NavigateUrl = EditUrl("ItemID", _ItemId.ToString(), "ItemRatings", "dnnprintmode=true");
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

                if ((hypMoreLink != null))
                {
                    {
                        hypMoreLink.Visible = (!objOI.HideTextLink) & (_NavURL != string.Empty);
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

            catch (Exception exc)
            {
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
            BindListXYZ70s();
			//ResetViewStates();
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
            //lstViewThumbs.ItemDataBound += new DataListItemEventHandler(lstViewThumbs_ItemDataBound);
            //ddlCategories.SelectedIndexChanged += new EventHandler(ddlCategories_SelectedIndexChanged);
            //btnSearch.Click += new EventHandler(btnSearch_Click);
            ////this.Load += new EventHandler(this.Page_Load);
            odsXYZ70s.Selecting += odsXYZ70s_Selecting;
            lstViewThumbs.ItemDataBound += lstViewThumbs_ItemDataBound;
            ddlCategories.SelectedIndexChanged += ddlCategories_SelectedIndexChanged;
            btnSearch.Click += btnSearch_Click;
            //this.Load += Page_Load;
        }

        #endregion

	} //ViewThumbs

} //bhattji.Modules.XYZ70s
